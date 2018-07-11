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

public class IntArrayElement : Element {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal IntArrayElement(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.IntArrayElement_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IntArrayElement obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~IntArrayElement() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_IntArrayElement(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static IntArrayElement Cast(Element element) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.IntArrayElement_Cast(Element.getCPtr(element));
    IntArrayElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new IntArrayElement(cPtr, true);
    return ret; 
  }

  public virtual int GetCount() {
    int ret = SharingClientPINVOKE.IntArrayElement_GetCount(swigCPtr);
    return ret;
  }

  public virtual int GetValue(int index) {
    int ret = SharingClientPINVOKE.IntArrayElement_GetValue(swigCPtr, index);
    return ret;
  }

  public virtual void SetValue(int index, int newValue) {
    SharingClientPINVOKE.IntArrayElement_SetValue(swigCPtr, index, newValue);
  }

  public virtual void InsertValue(int index, int value) {
    SharingClientPINVOKE.IntArrayElement_InsertValue(swigCPtr, index, value);
  }

  public virtual void RemoveValue(int index) {
    SharingClientPINVOKE.IntArrayElement_RemoveValue(swigCPtr, index);
  }

  public virtual void AddListener(IntArrayListener newListener) {
    SharingClientPINVOKE.IntArrayElement_AddListener(swigCPtr, IntArrayListener.getCPtr(newListener));
  }

  public virtual void RemoveListener(IntArrayListener oldListener) {
    SharingClientPINVOKE.IntArrayElement_RemoveListener(swigCPtr, IntArrayListener.getCPtr(oldListener));
  }

}

}
