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

public class PairingListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal PairingListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.PairingListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PairingListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~PairingListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_PairingListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void PairingConnectionSucceeded() {
    if (SwigDerivedClassHasMethod("PairingConnectionSucceeded", swigMethodTypes0)) SharingClientPINVOKE.PairingListener_PairingConnectionSucceededSwigExplicitPairingListener(swigCPtr); else SharingClientPINVOKE.PairingListener_PairingConnectionSucceeded(swigCPtr);
  }

  public virtual void PairingConnectionFailed(PairingResult reason) {
    if (SwigDerivedClassHasMethod("PairingConnectionFailed", swigMethodTypes1)) SharingClientPINVOKE.PairingListener_PairingConnectionFailedSwigExplicitPairingListener(swigCPtr, (int)reason); else SharingClientPINVOKE.PairingListener_PairingConnectionFailed(swigCPtr, (int)reason);
  }

  public PairingListener() : this(SharingClientPINVOKE.new_PairingListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("PairingConnectionSucceeded", swigMethodTypes0))
      swigDelegate0 = new SwigDelegatePairingListener_0(SwigDirectorPairingConnectionSucceeded);
    if (SwigDerivedClassHasMethod("PairingConnectionFailed", swigMethodTypes1))
      swigDelegate1 = new SwigDelegatePairingListener_1(SwigDirectorPairingConnectionFailed);
    SharingClientPINVOKE.PairingListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(PairingListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorPairingConnectionSucceeded() {
    PairingConnectionSucceeded();
  }

  private void SwigDirectorPairingConnectionFailed(int reason) {
    PairingConnectionFailed((PairingResult)reason);
  }

  public delegate void SwigDelegatePairingListener_0();
  public delegate void SwigDelegatePairingListener_1(int reason);

  private SwigDelegatePairingListener_0 swigDelegate0;
  private SwigDelegatePairingListener_1 swigDelegate1;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] {  };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(PairingResult) };
}

}
