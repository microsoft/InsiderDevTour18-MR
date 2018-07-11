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

public class DiscoveryClientListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal DiscoveryClientListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.DiscoveryClientListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DiscoveryClientListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~DiscoveryClientListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_DiscoveryClientListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnRemoteSystemDiscovered(DiscoveredSystem remoteSystem) {
    if (SwigDerivedClassHasMethod("OnRemoteSystemDiscovered", swigMethodTypes0)) SharingClientPINVOKE.DiscoveryClientListener_OnRemoteSystemDiscoveredSwigExplicitDiscoveryClientListener(swigCPtr, DiscoveredSystem.getCPtr(remoteSystem)); else SharingClientPINVOKE.DiscoveryClientListener_OnRemoteSystemDiscovered(swigCPtr, DiscoveredSystem.getCPtr(remoteSystem));
  }

  public virtual void OnRemoteSystemLost(DiscoveredSystem remoteSystem) {
    if (SwigDerivedClassHasMethod("OnRemoteSystemLost", swigMethodTypes1)) SharingClientPINVOKE.DiscoveryClientListener_OnRemoteSystemLostSwigExplicitDiscoveryClientListener(swigCPtr, DiscoveredSystem.getCPtr(remoteSystem)); else SharingClientPINVOKE.DiscoveryClientListener_OnRemoteSystemLost(swigCPtr, DiscoveredSystem.getCPtr(remoteSystem));
  }

  public DiscoveryClientListener() : this(SharingClientPINVOKE.new_DiscoveryClientListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnRemoteSystemDiscovered", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateDiscoveryClientListener_0(SwigDirectorOnRemoteSystemDiscovered);
    if (SwigDerivedClassHasMethod("OnRemoteSystemLost", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateDiscoveryClientListener_1(SwigDirectorOnRemoteSystemLost);
    SharingClientPINVOKE.DiscoveryClientListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(DiscoveryClientListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnRemoteSystemDiscovered(global::System.IntPtr remoteSystem) {
    OnRemoteSystemDiscovered((remoteSystem == global::System.IntPtr.Zero) ? null : new DiscoveredSystem(remoteSystem, true));
  }

  private void SwigDirectorOnRemoteSystemLost(global::System.IntPtr remoteSystem) {
    OnRemoteSystemLost((remoteSystem == global::System.IntPtr.Zero) ? null : new DiscoveredSystem(remoteSystem, true));
  }

  public delegate void SwigDelegateDiscoveryClientListener_0(global::System.IntPtr remoteSystem);
  public delegate void SwigDelegateDiscoveryClientListener_1(global::System.IntPtr remoteSystem);

  private SwigDelegateDiscoveryClientListener_0 swigDelegate0;
  private SwigDelegateDiscoveryClientListener_1 swigDelegate1;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(DiscoveredSystem) };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(DiscoveredSystem) };
}

}
