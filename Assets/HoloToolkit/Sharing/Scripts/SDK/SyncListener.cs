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

public class SyncListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal SyncListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.SyncListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SyncListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~SyncListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_SyncListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnSyncChangesBegin() {
    if (SwigDerivedClassHasMethod("OnSyncChangesBegin", swigMethodTypes0)) SharingClientPINVOKE.SyncListener_OnSyncChangesBeginSwigExplicitSyncListener(swigCPtr); else SharingClientPINVOKE.SyncListener_OnSyncChangesBegin(swigCPtr);
  }

  public virtual void OnSyncChangesEnd() {
    if (SwigDerivedClassHasMethod("OnSyncChangesEnd", swigMethodTypes1)) SharingClientPINVOKE.SyncListener_OnSyncChangesEndSwigExplicitSyncListener(swigCPtr); else SharingClientPINVOKE.SyncListener_OnSyncChangesEnd(swigCPtr);
  }

  public SyncListener() : this(SharingClientPINVOKE.new_SyncListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnSyncChangesBegin", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateSyncListener_0(SwigDirectorOnSyncChangesBegin);
    if (SwigDerivedClassHasMethod("OnSyncChangesEnd", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateSyncListener_1(SwigDirectorOnSyncChangesEnd);
    SharingClientPINVOKE.SyncListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(SyncListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnSyncChangesBegin() {
    OnSyncChangesBegin();
  }

  private void SwigDirectorOnSyncChangesEnd() {
    OnSyncChangesEnd();
  }

  public delegate void SwigDelegateSyncListener_0();
  public delegate void SwigDelegateSyncListener_1();

  private SwigDelegateSyncListener_0 swigDelegate0;
  private SwigDelegateSyncListener_1 swigDelegate1;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] {  };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] {  };
}

}
