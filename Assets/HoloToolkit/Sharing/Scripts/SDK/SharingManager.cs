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

public class SharingManager : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal SharingManager(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SharingManager obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~SharingManager() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_SharingManager(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public static SharingManager Create(ClientConfig config) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_Create(ClientConfig.getCPtr(config));
    SharingManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new SharingManager(cPtr, true);
    return ret; 
  }

  public virtual SessionManager GetSessionManager() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetSessionManager(swigCPtr);
    SessionManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new SessionManager(cPtr, true);
    return ret; 
  }

  public virtual UserPresenceManager GetUserPresenceManager() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetUserPresenceManager(swigCPtr);
    UserPresenceManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new UserPresenceManager(cPtr, true);
    return ret; 
  }

  public virtual AudioManager GetAudioManager() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetAudioManager(swigCPtr);
    AudioManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new AudioManager(cPtr, true);
    return ret; 
  }

  public virtual PairingManager GetPairingManager() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetPairingManager(swigCPtr);
    PairingManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new PairingManager(cPtr, true);
    return ret; 
  }

  public virtual RoomManager GetRoomManager() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetRoomManager(swigCPtr);
    RoomManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new RoomManager(cPtr, true);
    return ret; 
  }

  public virtual ObjectElement GetRootSyncObject() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetRootSyncObject(swigCPtr);
    ObjectElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new ObjectElement(cPtr, true);
    return ret; 
  }

  public virtual bool RegisterSyncListener(SyncListener listener) {
    bool ret = SharingClientPINVOKE.SharingManager_RegisterSyncListener(swigCPtr, SyncListener.getCPtr(listener));
    return ret;
  }

  public virtual void Update() {
    SharingClientPINVOKE.SharingManager_Update(swigCPtr);
  }

  public virtual NetworkConnection GetPairedConnection() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetPairedConnection(swigCPtr);
    NetworkConnection ret = (cPtr == global::System.IntPtr.Zero) ? null : new NetworkConnection(cPtr, true);
    return ret; 
  }

  public virtual NetworkConnection GetServerConnection() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetServerConnection(swigCPtr);
    NetworkConnection ret = (cPtr == global::System.IntPtr.Zero) ? null : new NetworkConnection(cPtr, true);
    return ret; 
  }

  public virtual Settings GetSettings() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetSettings(swigCPtr);
    Settings ret = (cPtr == global::System.IntPtr.Zero) ? null : new Settings(cPtr, true);
    return ret; 
  }

  public virtual void SetServerConnectionInfo(XString address, uint port) {
    SharingClientPINVOKE.SharingManager_SetServerConnectionInfo(swigCPtr, XString.getCPtr(address), port);
  }

  public virtual User GetLocalUser() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.SharingManager_GetLocalUser(swigCPtr);
    User ret = (cPtr == global::System.IntPtr.Zero) ? null : new User(cPtr, true);
    return ret; 
  }

  public virtual void SetUserName(XString name) {
    SharingClientPINVOKE.SharingManager_SetUserName(swigCPtr, XString.getCPtr(name));
  }

}

}
