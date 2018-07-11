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

namespace HoloToolkit.Sharing {

public class UserPresenceManagerListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal UserPresenceManagerListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.UserPresenceManagerListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(UserPresenceManagerListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~UserPresenceManagerListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_UserPresenceManagerListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnUserPresenceChanged(User user) {
    if (SwigDerivedClassHasMethod("OnUserPresenceChanged", swigMethodTypes0)) SharingClientPINVOKE.UserPresenceManagerListener_OnUserPresenceChangedSwigExplicitUserPresenceManagerListener(swigCPtr, User.getCPtr(user)); else SharingClientPINVOKE.UserPresenceManagerListener_OnUserPresenceChanged(swigCPtr, User.getCPtr(user));
  }

  public UserPresenceManagerListener() : this(SharingClientPINVOKE.new_UserPresenceManagerListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnUserPresenceChanged", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateUserPresenceManagerListener_0(SwigDirectorOnUserPresenceChanged);
    SharingClientPINVOKE.UserPresenceManagerListener_director_connect(swigCPtr, swigDelegate0);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(UserPresenceManagerListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnUserPresenceChanged(global::System.IntPtr user) {
    OnUserPresenceChanged((user == global::System.IntPtr.Zero) ? null : new User(user, true));
  }

  public delegate void SwigDelegateUserPresenceManagerListener_0(global::System.IntPtr user);

  private SwigDelegateUserPresenceManagerListener_0 swigDelegate0;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(User) };
}

}
