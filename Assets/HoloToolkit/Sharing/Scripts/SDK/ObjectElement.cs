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

public class ObjectElement : Element {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal ObjectElement(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.ObjectElement_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ObjectElement obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ObjectElement() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_ObjectElement(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static ObjectElement Cast(Element element) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_Cast(Element.getCPtr(element));
    ObjectElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new ObjectElement(cPtr, true);
    return ret; 
  }

  public virtual BoolElement CreateBoolElement(XString name, bool value) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateBoolElement(swigCPtr, XString.getCPtr(name), value);
    BoolElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new BoolElement(cPtr, true);
    return ret; 
  }

  public virtual IntElement CreateIntElement(XString name, int value) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateIntElement(swigCPtr, XString.getCPtr(name), value);
    IntElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new IntElement(cPtr, true);
    return ret; 
  }

  public virtual LongElement CreateLongElement(XString name, long value) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateLongElement(swigCPtr, XString.getCPtr(name), value);
    LongElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new LongElement(cPtr, true);
    return ret; 
  }

  public virtual FloatElement CreateFloatElement(XString name, float value) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateFloatElement(swigCPtr, XString.getCPtr(name), value);
    FloatElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new FloatElement(cPtr, true);
    return ret; 
  }

  public virtual DoubleElement CreateDoubleElement(XString name, double value) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateDoubleElement(swigCPtr, XString.getCPtr(name), value);
    DoubleElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new DoubleElement(cPtr, true);
    return ret; 
  }

  public virtual StringElement CreateStringElement(XString name, XString value) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateStringElement(swigCPtr, XString.getCPtr(name), XString.getCPtr(value));
    StringElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringElement(cPtr, true);
    return ret; 
  }

  public virtual ObjectElement CreateObjectElement(XString name, XString objectType, User owner) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateObjectElement__SWIG_0(swigCPtr, XString.getCPtr(name), XString.getCPtr(objectType), User.getCPtr(owner));
    ObjectElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new ObjectElement(cPtr, true);
    return ret; 
  }

  public virtual ObjectElement CreateObjectElement(XString name, XString objectType) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateObjectElement__SWIG_1(swigCPtr, XString.getCPtr(name), XString.getCPtr(objectType));
    ObjectElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new ObjectElement(cPtr, true);
    return ret; 
  }

  public virtual IntArrayElement CreateIntArrayElement(XString name) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateIntArrayElement(swigCPtr, XString.getCPtr(name));
    IntArrayElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new IntArrayElement(cPtr, true);
    return ret; 
  }

  public virtual FloatArrayElement CreateFloatArrayElement(XString name) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateFloatArrayElement(swigCPtr, XString.getCPtr(name));
    FloatArrayElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new FloatArrayElement(cPtr, true);
    return ret; 
  }

  public virtual StringArrayElement CreateStringArrayElement(XString name) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_CreateStringArrayElement(swigCPtr, XString.getCPtr(name));
    StringArrayElement ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringArrayElement(cPtr, true);
    return ret; 
  }

  public virtual int GetElementCount() {
    int ret = SharingClientPINVOKE.ObjectElement_GetElementCount(swigCPtr);
    return ret;
  }

  public virtual Element GetElement(long id) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_GetElement__SWIG_0(swigCPtr, id);
    Element ret = (cPtr == global::System.IntPtr.Zero) ? null : new Element(cPtr, true);
    return ret; 
  }

  public virtual Element GetElement(XString name) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_GetElement__SWIG_1(swigCPtr, XString.getCPtr(name));
    Element ret = (cPtr == global::System.IntPtr.Zero) ? null : new Element(cPtr, true);
    return ret; 
  }

  public virtual Element GetElementAt(int index) {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_GetElementAt(swigCPtr, index);
    Element ret = (cPtr == global::System.IntPtr.Zero) ? null : new Element(cPtr, true);
    return ret; 
  }

  public virtual void RemoveElement(Element element) {
    SharingClientPINVOKE.ObjectElement_RemoveElement__SWIG_0(swigCPtr, Element.getCPtr(element));
  }

  public virtual void RemoveElement(long id) {
    SharingClientPINVOKE.ObjectElement_RemoveElement__SWIG_1(swigCPtr, id);
  }

  public virtual void RemoveElementAt(int index) {
    SharingClientPINVOKE.ObjectElement_RemoveElementAt(swigCPtr, index);
  }

  public virtual void AddListener(ObjectElementListener newListener) {
    SharingClientPINVOKE.ObjectElement_AddListener(swigCPtr, ObjectElementListener.getCPtr(newListener));
  }

  public virtual void RemoveListener(ObjectElementListener oldListener) {
    SharingClientPINVOKE.ObjectElement_RemoveListener(swigCPtr, ObjectElementListener.getCPtr(oldListener));
  }

  public virtual int GetOwnerID() {
    int ret = SharingClientPINVOKE.ObjectElement_GetOwnerID(swigCPtr);
    return ret;
  }

  public virtual XString GetObjectType() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.ObjectElement_GetObjectType(swigCPtr);
    XString ret = (cPtr == global::System.IntPtr.Zero) ? null : new XString(cPtr, true);
    return ret; 
  }

}

}
