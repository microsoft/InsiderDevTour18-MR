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

public class SessionManagerListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal SessionManagerListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.SessionManagerListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SessionManagerListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~SessionManagerListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_SessionManagerListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnCreateSucceeded(Session newSession) {
    if (SwigDerivedClassHasMethod("OnCreateSucceeded", swigMethodTypes0)) SharingClientPINVOKE.SessionManagerListener_OnCreateSucceededSwigExplicitSessionManagerListener(swigCPtr, Session.getCPtr(newSession)); else SharingClientPINVOKE.SessionManagerListener_OnCreateSucceeded(swigCPtr, Session.getCPtr(newSession));
  }

  public virtual void OnCreateFailed(XString reason) {
    if (SwigDerivedClassHasMethod("OnCreateFailed", swigMethodTypes1)) SharingClientPINVOKE.SessionManagerListener_OnCreateFailedSwigExplicitSessionManagerListener(swigCPtr, XString.getCPtr(reason)); else SharingClientPINVOKE.SessionManagerListener_OnCreateFailed(swigCPtr, XString.getCPtr(reason));
  }

  public virtual void OnSessionAdded(Session newSession) {
    if (SwigDerivedClassHasMethod("OnSessionAdded", swigMethodTypes2)) SharingClientPINVOKE.SessionManagerListener_OnSessionAddedSwigExplicitSessionManagerListener(swigCPtr, Session.getCPtr(newSession)); else SharingClientPINVOKE.SessionManagerListener_OnSessionAdded(swigCPtr, Session.getCPtr(newSession));
  }

  public virtual void OnSessionClosed(Session session) {
    if (SwigDerivedClassHasMethod("OnSessionClosed", swigMethodTypes3)) SharingClientPINVOKE.SessionManagerListener_OnSessionClosedSwigExplicitSessionManagerListener(swigCPtr, Session.getCPtr(session)); else SharingClientPINVOKE.SessionManagerListener_OnSessionClosed(swigCPtr, Session.getCPtr(session));
  }

  public virtual void OnUserJoinedSession(Session session, User newUser) {
    if (SwigDerivedClassHasMethod("OnUserJoinedSession", swigMethodTypes4)) SharingClientPINVOKE.SessionManagerListener_OnUserJoinedSessionSwigExplicitSessionManagerListener(swigCPtr, Session.getCPtr(session), User.getCPtr(newUser)); else SharingClientPINVOKE.SessionManagerListener_OnUserJoinedSession(swigCPtr, Session.getCPtr(session), User.getCPtr(newUser));
  }

  public virtual void OnUserLeftSession(Session session, User user) {
    if (SwigDerivedClassHasMethod("OnUserLeftSession", swigMethodTypes5)) SharingClientPINVOKE.SessionManagerListener_OnUserLeftSessionSwigExplicitSessionManagerListener(swigCPtr, Session.getCPtr(session), User.getCPtr(user)); else SharingClientPINVOKE.SessionManagerListener_OnUserLeftSession(swigCPtr, Session.getCPtr(session), User.getCPtr(user));
  }

  public virtual void OnUserChanged(Session session, User user) {
    if (SwigDerivedClassHasMethod("OnUserChanged", swigMethodTypes6)) SharingClientPINVOKE.SessionManagerListener_OnUserChangedSwigExplicitSessionManagerListener(swigCPtr, Session.getCPtr(session), User.getCPtr(user)); else SharingClientPINVOKE.SessionManagerListener_OnUserChanged(swigCPtr, Session.getCPtr(session), User.getCPtr(user));
  }

  public virtual void OnServerConnected() {
    if (SwigDerivedClassHasMethod("OnServerConnected", swigMethodTypes7)) SharingClientPINVOKE.SessionManagerListener_OnServerConnectedSwigExplicitSessionManagerListener(swigCPtr); else SharingClientPINVOKE.SessionManagerListener_OnServerConnected(swigCPtr);
  }

  public virtual void OnServerDisconnected() {
    if (SwigDerivedClassHasMethod("OnServerDisconnected", swigMethodTypes8)) SharingClientPINVOKE.SessionManagerListener_OnServerDisconnectedSwigExplicitSessionManagerListener(swigCPtr); else SharingClientPINVOKE.SessionManagerListener_OnServerDisconnected(swigCPtr);
  }

  public SessionManagerListener() : this(SharingClientPINVOKE.new_SessionManagerListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnCreateSucceeded", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateSessionManagerListener_0(SwigDirectorOnCreateSucceeded);
    if (SwigDerivedClassHasMethod("OnCreateFailed", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateSessionManagerListener_1(SwigDirectorOnCreateFailed);
    if (SwigDerivedClassHasMethod("OnSessionAdded", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateSessionManagerListener_2(SwigDirectorOnSessionAdded);
    if (SwigDerivedClassHasMethod("OnSessionClosed", swigMethodTypes3))
      swigDelegate3 = new SwigDelegateSessionManagerListener_3(SwigDirectorOnSessionClosed);
    if (SwigDerivedClassHasMethod("OnUserJoinedSession", swigMethodTypes4))
      swigDelegate4 = new SwigDelegateSessionManagerListener_4(SwigDirectorOnUserJoinedSession);
    if (SwigDerivedClassHasMethod("OnUserLeftSession", swigMethodTypes5))
      swigDelegate5 = new SwigDelegateSessionManagerListener_5(SwigDirectorOnUserLeftSession);
    if (SwigDerivedClassHasMethod("OnUserChanged", swigMethodTypes6))
      swigDelegate6 = new SwigDelegateSessionManagerListener_6(SwigDirectorOnUserChanged);
    if (SwigDerivedClassHasMethod("OnServerConnected", swigMethodTypes7))
      swigDelegate7 = new SwigDelegateSessionManagerListener_7(SwigDirectorOnServerConnected);
    if (SwigDerivedClassHasMethod("OnServerDisconnected", swigMethodTypes8))
      swigDelegate8 = new SwigDelegateSessionManagerListener_8(SwigDirectorOnServerDisconnected);
    SharingClientPINVOKE.SessionManagerListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(SessionManagerListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnCreateSucceeded(global::System.IntPtr newSession) {
    OnCreateSucceeded((newSession == global::System.IntPtr.Zero) ? null : new Session(newSession, true));
  }

  private void SwigDirectorOnCreateFailed(global::System.IntPtr reason) {
    OnCreateFailed((reason == global::System.IntPtr.Zero) ? null : new XString(reason, true));
  }

  private void SwigDirectorOnSessionAdded(global::System.IntPtr newSession) {
    OnSessionAdded((newSession == global::System.IntPtr.Zero) ? null : new Session(newSession, true));
  }

  private void SwigDirectorOnSessionClosed(global::System.IntPtr session) {
    OnSessionClosed((session == global::System.IntPtr.Zero) ? null : new Session(session, true));
  }

  private void SwigDirectorOnUserJoinedSession(global::System.IntPtr session, global::System.IntPtr newUser) {
    OnUserJoinedSession((session == global::System.IntPtr.Zero) ? null : new Session(session, true), (newUser == global::System.IntPtr.Zero) ? null : new User(newUser, true));
  }

  private void SwigDirectorOnUserLeftSession(global::System.IntPtr session, global::System.IntPtr user) {
    OnUserLeftSession((session == global::System.IntPtr.Zero) ? null : new Session(session, true), (user == global::System.IntPtr.Zero) ? null : new User(user, true));
  }

  private void SwigDirectorOnUserChanged(global::System.IntPtr session, global::System.IntPtr user) {
    OnUserChanged((session == global::System.IntPtr.Zero) ? null : new Session(session, true), (user == global::System.IntPtr.Zero) ? null : new User(user, true));
  }

  private void SwigDirectorOnServerConnected() {
    OnServerConnected();
  }

  private void SwigDirectorOnServerDisconnected() {
    OnServerDisconnected();
  }

  public delegate void SwigDelegateSessionManagerListener_0(global::System.IntPtr newSession);
  public delegate void SwigDelegateSessionManagerListener_1(global::System.IntPtr reason);
  public delegate void SwigDelegateSessionManagerListener_2(global::System.IntPtr newSession);
  public delegate void SwigDelegateSessionManagerListener_3(global::System.IntPtr session);
  public delegate void SwigDelegateSessionManagerListener_4(global::System.IntPtr session, global::System.IntPtr newUser);
  public delegate void SwigDelegateSessionManagerListener_5(global::System.IntPtr session, global::System.IntPtr user);
  public delegate void SwigDelegateSessionManagerListener_6(global::System.IntPtr session, global::System.IntPtr user);
  public delegate void SwigDelegateSessionManagerListener_7();
  public delegate void SwigDelegateSessionManagerListener_8();

  private SwigDelegateSessionManagerListener_0 swigDelegate0;
  private SwigDelegateSessionManagerListener_1 swigDelegate1;
  private SwigDelegateSessionManagerListener_2 swigDelegate2;
  private SwigDelegateSessionManagerListener_3 swigDelegate3;
  private SwigDelegateSessionManagerListener_4 swigDelegate4;
  private SwigDelegateSessionManagerListener_5 swigDelegate5;
  private SwigDelegateSessionManagerListener_6 swigDelegate6;
  private SwigDelegateSessionManagerListener_7 swigDelegate7;
  private SwigDelegateSessionManagerListener_8 swigDelegate8;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(Session) };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(XString) };
  private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(Session) };
  private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(Session) };
  private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(Session), typeof(User) };
  private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(Session), typeof(User) };
  private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] { typeof(Session), typeof(User) };
  private static global::System.Type[] swigMethodTypes7 = new global::System.Type[] {  };
  private static global::System.Type[] swigMethodTypes8 = new global::System.Type[] {  };
}

}
