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

public class PairingManager : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal PairingManager(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PairingManager obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~PairingManager() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_PairingManager(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual bool HasPairingInfo() {
    bool ret = SharingClientPINVOKE.PairingManager_HasPairingInfo(swigCPtr);
    return ret;
  }

  public virtual void ClearPairingInfo() {
    SharingClientPINVOKE.PairingManager_ClearPairingInfo(swigCPtr);
  }

  public virtual bool BeginConnecting(PairingListener listener) {
    bool ret = SharingClientPINVOKE.PairingManager_BeginConnecting(swigCPtr, PairingListener.getCPtr(listener));
    return ret;
  }

  public virtual void CancelConnecting() {
    SharingClientPINVOKE.PairingManager_CancelConnecting(swigCPtr);
  }

  public virtual PairingResult BeginPairing(PairMaker pairMaker, PairingListener listener) {
    PairingResult ret = (PairingResult)SharingClientPINVOKE.PairingManager_BeginPairing(swigCPtr, PairMaker.getCPtr(pairMaker), PairingListener.getCPtr(listener));
    return ret;
  }

  public virtual void CancelPairing() {
    SharingClientPINVOKE.PairingManager_CancelPairing(swigCPtr);
  }

  public virtual bool IsPairing() {
    bool ret = SharingClientPINVOKE.PairingManager_IsPairing(swigCPtr);
    return ret;
  }

  public virtual bool IsConnected() {
    bool ret = SharingClientPINVOKE.PairingManager_IsConnected(swigCPtr);
    return ret;
  }

}

}
