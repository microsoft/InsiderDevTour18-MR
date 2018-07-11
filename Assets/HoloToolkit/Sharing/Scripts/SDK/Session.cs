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

public class Session : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Session(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Session obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Session() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_Session(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual MachineSessionState GetMachineSessionState() {
    MachineSessionState ret = (MachineSessionState)SharingClientPINVOKE.Session_GetMachineSessionState(swigCPtr);
    return ret;
  }

  public virtual void AddListener(SessionListener newListener) {
    SharingClientPINVOKE.Session_AddListener(swigCPtr, SessionListener.getCPtr(newListener));
  }

  public virtual void RemoveListener(SessionListener oldListener) {
    SharingClientPINVOKE.Session_RemoveListener(swigCPtr, SessionListener.getCPtr(oldListener));
  }

  public virtual bool IsJoined() {
    bool ret = SharingClientPINVOKE.Session_IsJoined(swigCPtr);
    return ret;
  }

  public virtual bool Join() {
    bool ret = SharingClientPINVOKE.Session_Join(swigCPtr);
    return ret;
  }

  public virtual void Leave() {
    SharingClientPINVOKE.Session_Leave(swigCPtr);
  }

  public virtual int GetUserCount() {
    int ret = SharingClientPINVOKE.Session_GetUserCount(swigCPtr);
    return ret;
  }

  public virtual User GetUser(int i) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.Session_GetUser(swigCPtr, i);
    User ret = (cPtr == global::System.IntPtr.Zero) ? null : new User(cPtr, true);
    return ret; 
  }

  public virtual SessionType GetSessionType() {
    SessionType ret = (SessionType)SharingClientPINVOKE.Session_GetSessionType(swigCPtr);
    return ret;
  }

  public virtual XString GetName() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.Session_GetName(swigCPtr);
    XString ret = (cPtr == global::System.IntPtr.Zero) ? null : new XString(cPtr, true);
    return ret; 
  }

  public virtual NetworkConnection GetSessionNetworkConnection() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.Session_GetSessionNetworkConnection(swigCPtr);
    NetworkConnection ret = (cPtr == global::System.IntPtr.Zero) ? null : new NetworkConnection(cPtr, true);
    return ret; 
  }

}

}
