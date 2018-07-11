// MIT License
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System;
using System.Collections;
using UnityEngine;
#if !UNITY_EDITOR && UNITY_WSA
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif
namespace HoloToolkit.Unity
{
    public delegate void ReturnValueCallback<TReturnValue>(TReturnValue returnValue);

    /// <summary>
    /// ApplicationViewManager ( For XAML UWP project) can switch app to Plan View, populate an Application View (New Window of UAP), 
    /// then navigate the Window root frame to a page. 
    /// After the page's logic called 'CallbackReturnValue' method, the newly created Application View will be closed, and the system will switch back to your Full3D view.
    /// The coroutine which was waiting the callback will get the return value.
    /// </summary>
    public class ApplicationViewManager : MonoBehaviour
    {
        private void Start()
        {
#if !UNITY_EDITOR && UNITY_WSA
            UnityEngine.WSA.Application.InvokeOnUIThread(
                () =>
                {
                    Full3DViewId = ApplicationView.GetForCurrentView().Id;
                }, true);
#endif
        }

#if !UNITY_EDITOR && UNITY_WSA
        static int Full3DViewId { get; set; }
        static System.Collections.Concurrent.ConcurrentDictionary<int, Action<object>> CallbackDictionary
            = new System.Collections.Concurrent.ConcurrentDictionary<int, Action<object>>();
#endif

        /// <summary>
        /// Call this method with Application View Dispatcher， or in Application View Thread, will return to Full3D View and close Application View
        /// </summary>
        /// <param name="returnValue">The return value of the XAML View Execution</param>
#if !UNITY_EDITOR && UNITY_WSA
        public static async void CallbackReturnValue(object returnValue)
        {
            var viewId = ApplicationView.GetForCurrentView().Id;
            var view = CoreApplication.GetCurrentView();
            if (CallbackDictionary.TryRemove(viewId, out var cb))
            {
                try
                {
                    cb(returnValue);
                }
                catch (Exception)
                {

                }
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(ApplicationViewManager.Full3DViewId).AsTask();
                view.CoreWindow.Close();
            }
        }
#else
        public static void CallbackReturnValue(object returnValue)
        {
        }
#endif
        /// <summary>
        /// Call this method in Unity App Thread can switch to Plan View, create and show a new XAML View. 
        /// </summary>
        /// <typeparam name="TReturnValue"></typeparam>
        /// <param name="xamlPageName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IEnumerator OnLaunchXamlView<TReturnValue>(string xamlPageName, Action<TReturnValue> callback, object pageNavigateParameter = null)
        {
            bool isCompleted = false;
#if !UNITY_EDITOR && UNITY_WSA
            object returnValue = null;
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            var dispt = newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //This happens when User switch view back to Main App manually 
                void CoreWindow_VisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
                {
                    if (args.Visible == false)
                    {
                        CallbackReturnValue(null);
                    }
                }
                newView.CoreWindow.VisibilityChanged += CoreWindow_VisibilityChanged;
                Frame frame = new Frame();
                var pageType = Type.GetType(Windows.UI.Xaml.Application.Current.GetType().AssemblyQualifiedName.Replace(".App,", $".{xamlPageName},"));
                var appv = ApplicationView.GetForCurrentView();
                newViewId = appv.Id;
                var cb = new Action<object>(rval =>
                {
                    returnValue = rval;
                    isCompleted = true;
                });
                frame.Navigate(pageType,pageNavigateParameter);
                CallbackDictionary[newViewId] = cb;
                Window.Current.Content = frame;
                Window.Current.Activate();

            }).AsTask();
            yield return new WaitUntil(() => dispt.IsCompleted || dispt.IsCanceled || dispt.IsFaulted);
            Task viewShownTask = null;
            UnityEngine.WSA.Application.InvokeOnUIThread(
                () =>
                {
                    viewShownTask = ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId).AsTask();
                },
                    true);
            yield return new WaitUntil(() => viewShownTask.IsCompleted || viewShownTask.IsCanceled || viewShownTask.IsFaulted);
            yield return new WaitUntil(() => isCompleted);
            try
            {
                if (returnValue is TReturnValue)
                {
                    callback?.Invoke((TReturnValue)returnValue);
                }
                else
                {
                    callback?.Invoke(default(TReturnValue));
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
#else
            isCompleted = true;
            yield return new WaitUntil(() => isCompleted);
#endif
        }
    }
}
