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

public class ClientConfig : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ClientConfig(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ClientConfig obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ClientConfig() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_ClientConfig(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public ClientConfig(ClientRole role) : this(SharingClientPINVOKE.new_ClientConfig((int)role), true) {
  }

  public ClientRole GetRole() {
    ClientRole ret = (ClientRole)SharingClientPINVOKE.ClientConfig_GetRole(swigCPtr);
    return ret;
  }

  public string GetServerAddress() {
    string ret = SharingClientPINVOKE.ClientConfig_GetServerAddress(swigCPtr);
    return ret;
  }

  public bool SetServerAddress(string serverAddress) {
    bool ret = SharingClientPINVOKE.ClientConfig_SetServerAddress(swigCPtr, serverAddress);
    if (SharingClientPINVOKE.SWIGPendingException.Pending) throw SharingClientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetServerPort() {
    int ret = SharingClientPINVOKE.ClientConfig_GetServerPort(swigCPtr);
    return ret;
  }

  public bool SetServerPort(int port) {
    bool ret = SharingClientPINVOKE.ClientConfig_SetServerPort(swigCPtr, port);
    return ret;
  }

  public LogWriter GetLogWriter() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ClientConfig_GetLogWriter(swigCPtr);
    LogWriter ret = (cPtr == global::System.IntPtr.Zero) ? null : new LogWriter(cPtr, false);
    return ret;
  }

  public void SetLogWriter(LogWriter logger) {
    SharingClientPINVOKE.ClientConfig_SetLogWriter(swigCPtr, LogWriter.getCPtr(logger));
  }

  public bool GetIsAudioEndpoint() {
    bool ret = SharingClientPINVOKE.ClientConfig_GetIsAudioEndpoint(swigCPtr);
    return ret;
  }

  public void SetIsAudioEndpoint(bool isAudioEndpoint) {
    SharingClientPINVOKE.ClientConfig_SetIsAudioEndpoint(swigCPtr, isAudioEndpoint);
  }

  public bool GetProfilerEnabled() {
    bool ret = SharingClientPINVOKE.ClientConfig_GetProfilerEnabled(swigCPtr);
    return ret;
  }

  public void SetProfilerEnabled(bool enabled) {
    SharingClientPINVOKE.ClientConfig_SetProfilerEnabled(swigCPtr, enabled);
  }

}

}
