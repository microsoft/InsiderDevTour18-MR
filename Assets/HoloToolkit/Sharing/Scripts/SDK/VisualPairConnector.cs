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

public class VisualPairConnector : PairMaker {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal VisualPairConnector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.VisualPairConnector_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VisualPairConnector obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~VisualPairConnector() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_VisualPairConnector(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static VisualPairConnector Create() {
    global::System.IntPtr cPtr = SharingClientPINVOKE.VisualPairConnector_Create();
    VisualPairConnector ret = (cPtr == global::System.IntPtr.Zero) ? null : new VisualPairConnector(cPtr, true);
    return ret; 
  }

  public virtual bool ProcessImage(byte[] image, int width, int height, int bytesPerPixel) {
    global::System.Runtime.InteropServices.GCHandle pinHandle_image = global::System.Runtime.InteropServices.GCHandle.Alloc(image, global::System.Runtime.InteropServices.GCHandleType.Pinned); try {
    {
      bool ret = SharingClientPINVOKE.VisualPairConnector_ProcessImage(swigCPtr, (global::System.IntPtr)pinHandle_image.AddrOfPinnedObject(), width, height, bytesPerPixel);
      return ret;
    }
    } finally { pinHandle_image.Free(); }
  }

  public virtual bool IsProcessingImage() {
    bool ret = SharingClientPINVOKE.VisualPairConnector_IsProcessingImage(swigCPtr);
    return ret;
  }

}

}
