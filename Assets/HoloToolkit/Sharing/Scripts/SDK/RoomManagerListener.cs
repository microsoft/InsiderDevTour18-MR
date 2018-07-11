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

public class RoomManagerListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal RoomManagerListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.RoomManagerListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RoomManagerListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~RoomManagerListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_RoomManagerListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnRoomAdded(Room newRoom) {
    if (SwigDerivedClassHasMethod("OnRoomAdded", swigMethodTypes0)) SharingClientPINVOKE.RoomManagerListener_OnRoomAddedSwigExplicitRoomManagerListener(swigCPtr, Room.getCPtr(newRoom)); else SharingClientPINVOKE.RoomManagerListener_OnRoomAdded(swigCPtr, Room.getCPtr(newRoom));
  }

  public virtual void OnRoomClosed(Room room) {
    if (SwigDerivedClassHasMethod("OnRoomClosed", swigMethodTypes1)) SharingClientPINVOKE.RoomManagerListener_OnRoomClosedSwigExplicitRoomManagerListener(swigCPtr, Room.getCPtr(room)); else SharingClientPINVOKE.RoomManagerListener_OnRoomClosed(swigCPtr, Room.getCPtr(room));
  }

  public virtual void OnUserJoinedRoom(Room room, int user) {
    if (SwigDerivedClassHasMethod("OnUserJoinedRoom", swigMethodTypes2)) SharingClientPINVOKE.RoomManagerListener_OnUserJoinedRoomSwigExplicitRoomManagerListener(swigCPtr, Room.getCPtr(room), user); else SharingClientPINVOKE.RoomManagerListener_OnUserJoinedRoom(swigCPtr, Room.getCPtr(room), user);
  }

  public virtual void OnUserLeftRoom(Room room, int user) {
    if (SwigDerivedClassHasMethod("OnUserLeftRoom", swigMethodTypes3)) SharingClientPINVOKE.RoomManagerListener_OnUserLeftRoomSwigExplicitRoomManagerListener(swigCPtr, Room.getCPtr(room), user); else SharingClientPINVOKE.RoomManagerListener_OnUserLeftRoom(swigCPtr, Room.getCPtr(room), user);
  }

  public virtual void OnAnchorsChanged(Room room) {
    if (SwigDerivedClassHasMethod("OnAnchorsChanged", swigMethodTypes4)) SharingClientPINVOKE.RoomManagerListener_OnAnchorsChangedSwigExplicitRoomManagerListener(swigCPtr, Room.getCPtr(room)); else SharingClientPINVOKE.RoomManagerListener_OnAnchorsChanged(swigCPtr, Room.getCPtr(room));
  }

  public virtual void OnAnchorsDownloaded(bool successful, AnchorDownloadRequest request, XString failureReason) {
    if (SwigDerivedClassHasMethod("OnAnchorsDownloaded", swigMethodTypes5)) SharingClientPINVOKE.RoomManagerListener_OnAnchorsDownloadedSwigExplicitRoomManagerListener(swigCPtr, successful, AnchorDownloadRequest.getCPtr(request), XString.getCPtr(failureReason)); else SharingClientPINVOKE.RoomManagerListener_OnAnchorsDownloaded(swigCPtr, successful, AnchorDownloadRequest.getCPtr(request), XString.getCPtr(failureReason));
  }

  public virtual void OnAnchorUploadComplete(bool successful, XString failureReason) {
    if (SwigDerivedClassHasMethod("OnAnchorUploadComplete", swigMethodTypes6)) SharingClientPINVOKE.RoomManagerListener_OnAnchorUploadCompleteSwigExplicitRoomManagerListener(swigCPtr, successful, XString.getCPtr(failureReason)); else SharingClientPINVOKE.RoomManagerListener_OnAnchorUploadComplete(swigCPtr, successful, XString.getCPtr(failureReason));
  }

  public RoomManagerListener() : this(SharingClientPINVOKE.new_RoomManagerListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnRoomAdded", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateRoomManagerListener_0(SwigDirectorOnRoomAdded);
    if (SwigDerivedClassHasMethod("OnRoomClosed", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateRoomManagerListener_1(SwigDirectorOnRoomClosed);
    if (SwigDerivedClassHasMethod("OnUserJoinedRoom", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateRoomManagerListener_2(SwigDirectorOnUserJoinedRoom);
    if (SwigDerivedClassHasMethod("OnUserLeftRoom", swigMethodTypes3))
      swigDelegate3 = new SwigDelegateRoomManagerListener_3(SwigDirectorOnUserLeftRoom);
    if (SwigDerivedClassHasMethod("OnAnchorsChanged", swigMethodTypes4))
      swigDelegate4 = new SwigDelegateRoomManagerListener_4(SwigDirectorOnAnchorsChanged);
    if (SwigDerivedClassHasMethod("OnAnchorsDownloaded", swigMethodTypes5))
      swigDelegate5 = new SwigDelegateRoomManagerListener_5(SwigDirectorOnAnchorsDownloaded);
    if (SwigDerivedClassHasMethod("OnAnchorUploadComplete", swigMethodTypes6))
      swigDelegate6 = new SwigDelegateRoomManagerListener_6(SwigDirectorOnAnchorUploadComplete);
    SharingClientPINVOKE.RoomManagerListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(RoomManagerListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnRoomAdded(global::System.IntPtr newRoom) {
    OnRoomAdded((newRoom == global::System.IntPtr.Zero) ? null : new Room(newRoom, true));
  }

  private void SwigDirectorOnRoomClosed(global::System.IntPtr room) {
    OnRoomClosed((room == global::System.IntPtr.Zero) ? null : new Room(room, true));
  }

  private void SwigDirectorOnUserJoinedRoom(global::System.IntPtr room, int user) {
    OnUserJoinedRoom((room == global::System.IntPtr.Zero) ? null : new Room(room, true), user);
  }

  private void SwigDirectorOnUserLeftRoom(global::System.IntPtr room, int user) {
    OnUserLeftRoom((room == global::System.IntPtr.Zero) ? null : new Room(room, true), user);
  }

  private void SwigDirectorOnAnchorsChanged(global::System.IntPtr room) {
    OnAnchorsChanged((room == global::System.IntPtr.Zero) ? null : new Room(room, true));
  }

  private void SwigDirectorOnAnchorsDownloaded(bool successful, global::System.IntPtr request, global::System.IntPtr failureReason) {
    OnAnchorsDownloaded(successful, (request == global::System.IntPtr.Zero) ? null : new AnchorDownloadRequest(request, true), (failureReason == global::System.IntPtr.Zero) ? null : new XString(failureReason, true));
  }

  private void SwigDirectorOnAnchorUploadComplete(bool successful, global::System.IntPtr failureReason) {
    OnAnchorUploadComplete(successful, (failureReason == global::System.IntPtr.Zero) ? null : new XString(failureReason, true));
  }

  public delegate void SwigDelegateRoomManagerListener_0(global::System.IntPtr newRoom);
  public delegate void SwigDelegateRoomManagerListener_1(global::System.IntPtr room);
  public delegate void SwigDelegateRoomManagerListener_2(global::System.IntPtr room, int user);
  public delegate void SwigDelegateRoomManagerListener_3(global::System.IntPtr room, int user);
  public delegate void SwigDelegateRoomManagerListener_4(global::System.IntPtr room);
  public delegate void SwigDelegateRoomManagerListener_5(bool successful, global::System.IntPtr request, global::System.IntPtr failureReason);
  public delegate void SwigDelegateRoomManagerListener_6(bool successful, global::System.IntPtr failureReason);

  private SwigDelegateRoomManagerListener_0 swigDelegate0;
  private SwigDelegateRoomManagerListener_1 swigDelegate1;
  private SwigDelegateRoomManagerListener_2 swigDelegate2;
  private SwigDelegateRoomManagerListener_3 swigDelegate3;
  private SwigDelegateRoomManagerListener_4 swigDelegate4;
  private SwigDelegateRoomManagerListener_5 swigDelegate5;
  private SwigDelegateRoomManagerListener_6 swigDelegate6;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(Room) };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(Room) };
  private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(Room), typeof(int) };
  private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(Room), typeof(int) };
  private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(Room) };
  private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(bool), typeof(AnchorDownloadRequest), typeof(XString) };
  private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] { typeof(bool), typeof(XString) };
}

}
