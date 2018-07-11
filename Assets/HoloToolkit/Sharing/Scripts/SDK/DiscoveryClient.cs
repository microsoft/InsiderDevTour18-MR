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

public class DiscoveryClient : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DiscoveryClient(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DiscoveryClient obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~DiscoveryClient() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_DiscoveryClient(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static DiscoveryClient Create() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.DiscoveryClient_Create();
    DiscoveryClient ret = (cPtr == global::System.IntPtr.Zero) ? null : new DiscoveryClient(cPtr, true);
    return ret; 
  }

  public virtual void Ping() {
    SharingClientPINVOKE.DiscoveryClient_Ping(swigCPtr);
  }

  public virtual uint GetDiscoveredCount() {
    uint ret = SharingClientPINVOKE.DiscoveryClient_GetDiscoveredCount(swigCPtr);
    return ret;
  }

  public virtual DiscoveredSystem GetDiscoveredSystem(uint index) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.DiscoveryClient_GetDiscoveredSystem(swigCPtr, index);
    DiscoveredSystem ret = (cPtr == global::System.IntPtr.Zero) ? null : new DiscoveredSystem(cPtr, true);
    return ret; 
  }

  public virtual void Update() {
    SharingClientPINVOKE.DiscoveryClient_Update(swigCPtr);
  }

  public virtual void AddListener(DiscoveryClientListener newListener) {
    SharingClientPINVOKE.DiscoveryClient_AddListener(swigCPtr, DiscoveryClientListener.getCPtr(newListener));
  }

  public virtual void RemoveListener(DiscoveryClientListener oldListener) {
    SharingClientPINVOKE.DiscoveryClient_RemoveListener(swigCPtr, DiscoveryClientListener.getCPtr(oldListener));
  }

}

}
