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

public class SessionManager : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal SessionManager(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SessionManager obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~SessionManager() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_SessionManager(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual void AddListener(SessionManagerListener newListener) {
    SharingClientPINVOKE.SessionManager_AddListener(swigCPtr, SessionManagerListener.getCPtr(newListener));
  }

  public virtual void RemoveListener(SessionManagerListener oldListener) {
    SharingClientPINVOKE.SessionManager_RemoveListener(swigCPtr, SessionManagerListener.getCPtr(oldListener));
  }

  public virtual bool CreateSession(XString sessionName) {
    bool ret = SharingClientPINVOKE.SessionManager_CreateSession__SWIG_0(swigCPtr, XString.getCPtr(sessionName));
    return ret;
  }

  public virtual bool CreateSession(XString sessionName, SessionType type) {
    bool ret = SharingClientPINVOKE.SessionManager_CreateSession__SWIG_1(swigCPtr, XString.getCPtr(sessionName), (int)type);
    return ret;
  }

  public virtual int GetSessionCount() {
    int ret = SharingClientPINVOKE.SessionManager_GetSessionCount(swigCPtr);
    return ret;
  }

  public virtual Session GetSession(int index) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SessionManager_GetSession(swigCPtr, index);
    Session ret = (cPtr == global::System.IntPtr.Zero) ? null : new Session(cPtr, true);
    return ret; 
  }

  public virtual Session GetCurrentSession() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SessionManager_GetCurrentSession(swigCPtr);
    Session ret = (cPtr == global::System.IntPtr.Zero) ? null : new Session(cPtr, true);
    return ret; 
  }

  public virtual User GetCurrentUser() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SessionManager_GetCurrentUser(swigCPtr);
    User ret = (cPtr == global::System.IntPtr.Zero) ? null : new User(cPtr, true);
    return ret; 
  }

  public virtual bool IsServerConnected() {
    bool ret = SharingClientPINVOKE.SessionManager_IsServerConnected(swigCPtr);
    return ret;
  }

}

}
