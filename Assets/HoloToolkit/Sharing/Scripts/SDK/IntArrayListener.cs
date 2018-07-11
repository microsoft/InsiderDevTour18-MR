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

public class IntArrayListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal IntArrayListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.IntArrayListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IntArrayListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~IntArrayListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_IntArrayListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnValueChanged(int index, int newValue) {
    if (SwigDerivedClassHasMethod("OnValueChanged", swigMethodTypes0)) SharingClientPINVOKE.IntArrayListener_OnValueChangedSwigExplicitIntArrayListener(swigCPtr, index, newValue); else SharingClientPINVOKE.IntArrayListener_OnValueChanged(swigCPtr, index, newValue);
  }

  public virtual void OnValueInserted(int index, int value) {
    if (SwigDerivedClassHasMethod("OnValueInserted", swigMethodTypes1)) SharingClientPINVOKE.IntArrayListener_OnValueInsertedSwigExplicitIntArrayListener(swigCPtr, index, value); else SharingClientPINVOKE.IntArrayListener_OnValueInserted(swigCPtr, index, value);
  }

  public virtual void OnValueRemoved(int index, int value) {
    if (SwigDerivedClassHasMethod("OnValueRemoved", swigMethodTypes2)) SharingClientPINVOKE.IntArrayListener_OnValueRemovedSwigExplicitIntArrayListener(swigCPtr, index, value); else SharingClientPINVOKE.IntArrayListener_OnValueRemoved(swigCPtr, index, value);
  }

  public IntArrayListener() : this(SharingClientPINVOKE.new_IntArrayListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnValueChanged", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateIntArrayListener_0(SwigDirectorOnValueChanged);
    if (SwigDerivedClassHasMethod("OnValueInserted", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateIntArrayListener_1(SwigDirectorOnValueInserted);
    if (SwigDerivedClassHasMethod("OnValueRemoved", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateIntArrayListener_2(SwigDirectorOnValueRemoved);
    SharingClientPINVOKE.IntArrayListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(IntArrayListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnValueChanged(int index, int newValue) {
    OnValueChanged(index, newValue);
  }

  private void SwigDirectorOnValueInserted(int index, int value) {
    OnValueInserted(index, value);
  }

  private void SwigDirectorOnValueRemoved(int index, int value) {
    OnValueRemoved(index, value);
  }

  public delegate void SwigDelegateIntArrayListener_0(int index, int newValue);
  public delegate void SwigDelegateIntArrayListener_1(int index, int value);
  public delegate void SwigDelegateIntArrayListener_2(int index, int value);

  private SwigDelegateIntArrayListener_0 swigDelegate0;
  private SwigDelegateIntArrayListener_1 swigDelegate1;
  private SwigDelegateIntArrayListener_2 swigDelegate2;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(int), typeof(int) };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(int), typeof(int) };
  private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(int), typeof(int) };
}

}
