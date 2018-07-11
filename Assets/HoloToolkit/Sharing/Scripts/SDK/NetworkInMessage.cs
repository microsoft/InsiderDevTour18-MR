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

public class NetworkInMessage : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal NetworkInMessage(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NetworkInMessage obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~NetworkInMessage() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_NetworkInMessage(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual byte ReadByte() {
    byte ret = SharingClientPINVOKE.NetworkInMessage_ReadByte(swigCPtr);
    return ret;
  }

  public virtual short ReadInt16() {
    short ret = SharingClientPINVOKE.NetworkInMessage_ReadInt16(swigCPtr);
    return ret;
  }

  public virtual int ReadInt32() {
    int ret = SharingClientPINVOKE.NetworkInMessage_ReadInt32(swigCPtr);
    return ret;
  }

  public virtual long ReadInt64() {
    long ret = SharingClientPINVOKE.NetworkInMessage_ReadInt64(swigCPtr);
    return ret;
  }

  public virtual float ReadFloat() {
    float ret = SharingClientPINVOKE.NetworkInMessage_ReadFloat(swigCPtr);
    return ret;
  }

  public virtual double ReadDouble() {
    double ret = SharingClientPINVOKE.NetworkInMessage_ReadDouble(swigCPtr);
    return ret;
  }

  public virtual XString ReadString() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.NetworkInMessage_ReadString(swigCPtr);
    XString ret = (cPtr == global::System.IntPtr.Zero) ? null : new XString(cPtr, true);
    return ret; 
  }

  public virtual void ReadArray(byte[] data, uint arrayLength) {
    global::System.Runtime.InteropServices.GCHandle pinHandle_data = global::System.Runtime.InteropServices.GCHandle.Alloc(data, global::System.Runtime.InteropServices.GCHandleType.Pinned); try {
    {
      SharingClientPINVOKE.NetworkInMessage_ReadArray(swigCPtr, (global::System.IntPtr)pinHandle_data.AddrOfPinnedObject(), arrayLength);
    }
    } finally { pinHandle_data.Free(); }
  }

  public virtual int GetUnreadBitsCount() {
    int ret = SharingClientPINVOKE.NetworkInMessage_GetUnreadBitsCount(swigCPtr);
    return ret;
  }

  public virtual int GetSize() {
    int ret = SharingClientPINVOKE.NetworkInMessage_GetSize(swigCPtr);
    return ret;
  }

}

}
