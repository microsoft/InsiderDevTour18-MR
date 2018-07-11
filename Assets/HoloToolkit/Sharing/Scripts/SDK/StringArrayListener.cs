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

public class StringArrayListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal StringArrayListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.StringArrayListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(StringArrayListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~StringArrayListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_StringArrayListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnValueChanged(int index, XString newValue) {
    if (SwigDerivedClassHasMethod("OnValueChanged", swigMethodTypes0)) SharingClientPINVOKE.StringArrayListener_OnValueChangedSwigExplicitStringArrayListener(swigCPtr, index, XString.getCPtr(newValue)); else SharingClientPINVOKE.StringArrayListener_OnValueChanged(swigCPtr, index, XString.getCPtr(newValue));
  }

  public virtual void OnValueInserted(int index, XString value) {
    if (SwigDerivedClassHasMethod("OnValueInserted", swigMethodTypes1)) SharingClientPINVOKE.StringArrayListener_OnValueInsertedSwigExplicitStringArrayListener(swigCPtr, index, XString.getCPtr(value)); else SharingClientPINVOKE.StringArrayListener_OnValueInserted(swigCPtr, index, XString.getCPtr(value));
  }

  public virtual void OnValueRemoved(int index, XString value) {
    if (SwigDerivedClassHasMethod("OnValueRemoved", swigMethodTypes2)) SharingClientPINVOKE.StringArrayListener_OnValueRemovedSwigExplicitStringArrayListener(swigCPtr, index, XString.getCPtr(value)); else SharingClientPINVOKE.StringArrayListener_OnValueRemoved(swigCPtr, index, XString.getCPtr(value));
  }

  public StringArrayListener() : this(SharingClientPINVOKE.new_StringArrayListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnValueChanged", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateStringArrayListener_0(SwigDirectorOnValueChanged);
    if (SwigDerivedClassHasMethod("OnValueInserted", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateStringArrayListener_1(SwigDirectorOnValueInserted);
    if (SwigDerivedClassHasMethod("OnValueRemoved", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateStringArrayListener_2(SwigDirectorOnValueRemoved);
    SharingClientPINVOKE.StringArrayListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(StringArrayListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnValueChanged(int index, global::System.IntPtr newValue) {
    OnValueChanged(index, (newValue == global::System.IntPtr.Zero) ? null : new XString(newValue, true));
  }

  private void SwigDirectorOnValueInserted(int index, global::System.IntPtr value) {
    OnValueInserted(index, (value == global::System.IntPtr.Zero) ? null : new XString(value, true));
  }

  private void SwigDirectorOnValueRemoved(int index, global::System.IntPtr value) {
    OnValueRemoved(index, (value == global::System.IntPtr.Zero) ? null : new XString(value, true));
  }

  public delegate void SwigDelegateStringArrayListener_0(int index, global::System.IntPtr newValue);
  public delegate void SwigDelegateStringArrayListener_1(int index, global::System.IntPtr value);
  public delegate void SwigDelegateStringArrayListener_2(int index, global::System.IntPtr value);

  private SwigDelegateStringArrayListener_0 swigDelegate0;
  private SwigDelegateStringArrayListener_1 swigDelegate1;
  private SwigDelegateStringArrayListener_2 swigDelegate2;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(int), typeof(XString) };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(int), typeof(XString) };
  private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(int), typeof(XString) };
}

}
