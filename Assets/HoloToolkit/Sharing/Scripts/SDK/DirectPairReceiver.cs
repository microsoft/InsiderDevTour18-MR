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

public class DirectPairReceiver : PairMaker {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal DirectPairReceiver(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.DirectPairReceiver_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DirectPairReceiver obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~DirectPairReceiver() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_DirectPairReceiver(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public DirectPairReceiver() : this(SharingClientPINVOKE.new_DirectPairReceiver__SWIG_0(), true) {
  }

  public DirectPairReceiver(ushort port) : this(SharingClientPINVOKE.new_DirectPairReceiver__SWIG_1(port), true) {
  }

  public override bool IsReceiver() {
    bool ret = SharingClientPINVOKE.DirectPairReceiver_IsReceiver(swigCPtr);
    return ret;
  }

  public override int GetAddressCount() {
    int ret = SharingClientPINVOKE.DirectPairReceiver_GetAddressCount(swigCPtr);
    return ret;
  }

  public override XString GetAddress(int index) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.DirectPairReceiver_GetAddress(swigCPtr, index);
    XString ret = (cPtr == global::System.IntPtr.Zero) ? null : new XString(cPtr, true);
    return ret; 
  }

  public override ushort GetPort() {
    ushort ret = SharingClientPINVOKE.DirectPairReceiver_GetPort(swigCPtr);
    return ret;
  }

  public override void Update() {
    SharingClientPINVOKE.DirectPairReceiver_Update(swigCPtr);
  }

  public override bool IsReadyToConnect() {
    bool ret = SharingClientPINVOKE.DirectPairReceiver_IsReadyToConnect(swigCPtr);
    return ret;
  }

  public void SetIncomingPort(ushort port) {
    SharingClientPINVOKE.DirectPairReceiver_SetIncomingPort(swigCPtr, port);
  }

}

}
