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

public class Room : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Room(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Room obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Room() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_Room(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual XString GetName() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.Room_GetName(swigCPtr);
    XString ret = (cPtr == global::System.IntPtr.Zero) ? null : new XString(cPtr, true);
    return ret; 
  }

  public virtual long GetID() {
    long ret = SharingClientPINVOKE.Room_GetID(swigCPtr);
    return ret;
  }

  public virtual int GetUserCount() {
    int ret = SharingClientPINVOKE.Room_GetUserCount(swigCPtr);
    return ret;
  }

  public virtual int GetUserID(int userIndex) {
    int ret = SharingClientPINVOKE.Room_GetUserID(swigCPtr, userIndex);
    return ret;
  }

  public virtual bool GetKeepOpen() {
    bool ret = SharingClientPINVOKE.Room_GetKeepOpen(swigCPtr);
    return ret;
  }

  public virtual void SetKeepOpen(bool keepOpen) {
    SharingClientPINVOKE.Room_SetKeepOpen(swigCPtr, keepOpen);
  }

  public virtual int GetAnchorCount() {
    int ret = SharingClientPINVOKE.Room_GetAnchorCount(swigCPtr);
    return ret;
  }

  public virtual XString GetAnchorName(int index) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.Room_GetAnchorName(swigCPtr, index);
    XString ret = (cPtr == global::System.IntPtr.Zero) ? null : new XString(cPtr, true);
    return ret; 
  }

  public const long kInvalidRoomID = -1L;
}

}
