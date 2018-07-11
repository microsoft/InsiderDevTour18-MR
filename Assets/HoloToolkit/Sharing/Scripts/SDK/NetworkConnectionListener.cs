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

public class NetworkConnectionListener : Listener {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal NetworkConnectionListener(global::System.IntPtr cPtr, bool cMemoryOwn) : base(SharingClientPINVOKE.NetworkConnectionListener_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NetworkConnectionListener obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~NetworkConnectionListener() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SharingClientPINVOKE.delete_NetworkConnectionListener(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public virtual void OnConnected(NetworkConnection connection) {
    if (SwigDerivedClassHasMethod("OnConnected", swigMethodTypes0)) SharingClientPINVOKE.NetworkConnectionListener_OnConnectedSwigExplicitNetworkConnectionListener(swigCPtr, NetworkConnection.getCPtr(connection)); else SharingClientPINVOKE.NetworkConnectionListener_OnConnected(swigCPtr, NetworkConnection.getCPtr(connection));
  }

  public virtual void OnConnectFailed(NetworkConnection connection) {
    if (SwigDerivedClassHasMethod("OnConnectFailed", swigMethodTypes1)) SharingClientPINVOKE.NetworkConnectionListener_OnConnectFailedSwigExplicitNetworkConnectionListener(swigCPtr, NetworkConnection.getCPtr(connection)); else SharingClientPINVOKE.NetworkConnectionListener_OnConnectFailed(swigCPtr, NetworkConnection.getCPtr(connection));
  }

  public virtual void OnDisconnected(NetworkConnection connection) {
    if (SwigDerivedClassHasMethod("OnDisconnected", swigMethodTypes2)) SharingClientPINVOKE.NetworkConnectionListener_OnDisconnectedSwigExplicitNetworkConnectionListener(swigCPtr, NetworkConnection.getCPtr(connection)); else SharingClientPINVOKE.NetworkConnectionListener_OnDisconnected(swigCPtr, NetworkConnection.getCPtr(connection));
  }

  public virtual void OnMessageReceived(NetworkConnection connection, NetworkInMessage message) {
    if (SwigDerivedClassHasMethod("OnMessageReceived", swigMethodTypes3)) SharingClientPINVOKE.NetworkConnectionListener_OnMessageReceivedSwigExplicitNetworkConnectionListener(swigCPtr, NetworkConnection.getCPtr(connection), NetworkInMessage.getCPtr(message)); else SharingClientPINVOKE.NetworkConnectionListener_OnMessageReceived(swigCPtr, NetworkConnection.getCPtr(connection), NetworkInMessage.getCPtr(message));
    if (SharingClientPINVOKE.SWIGPendingException.Pending) throw SharingClientPINVOKE.SWIGPendingException.Retrieve();
  }

  public NetworkConnectionListener() : this(SharingClientPINVOKE.new_NetworkConnectionListener(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("OnConnected", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateNetworkConnectionListener_0(SwigDirectorOnConnected);
    if (SwigDerivedClassHasMethod("OnConnectFailed", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateNetworkConnectionListener_1(SwigDirectorOnConnectFailed);
    if (SwigDerivedClassHasMethod("OnDisconnected", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateNetworkConnectionListener_2(SwigDirectorOnDisconnected);
    if (SwigDerivedClassHasMethod("OnMessageReceived", swigMethodTypes3))
      swigDelegate3 = new SwigDelegateNetworkConnectionListener_3(SwigDirectorOnMessageReceived);
    SharingClientPINVOKE.NetworkConnectionListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(NetworkConnectionListener));
    return hasDerivedMethod;
  }

  private void SwigDirectorOnConnected(global::System.IntPtr connection) {
    OnConnected((connection == global::System.IntPtr.Zero) ? null : new NetworkConnection(connection, true));
  }

  private void SwigDirectorOnConnectFailed(global::System.IntPtr connection) {
    OnConnectFailed((connection == global::System.IntPtr.Zero) ? null : new NetworkConnection(connection, true));
  }

  private void SwigDirectorOnDisconnected(global::System.IntPtr connection) {
    OnDisconnected((connection == global::System.IntPtr.Zero) ? null : new NetworkConnection(connection, true));
  }

  private void SwigDirectorOnMessageReceived(global::System.IntPtr connection, global::System.IntPtr message) {
    OnMessageReceived((connection == global::System.IntPtr.Zero) ? null : new NetworkConnection(connection, true), new NetworkInMessage(message, false));
  }

  public delegate void SwigDelegateNetworkConnectionListener_0(global::System.IntPtr connection);
  public delegate void SwigDelegateNetworkConnectionListener_1(global::System.IntPtr connection);
  public delegate void SwigDelegateNetworkConnectionListener_2(global::System.IntPtr connection);
  public delegate void SwigDelegateNetworkConnectionListener_3(global::System.IntPtr connection, global::System.IntPtr message);

  private SwigDelegateNetworkConnectionListener_0 swigDelegate0;
  private SwigDelegateNetworkConnectionListener_1 swigDelegate1;
  private SwigDelegateNetworkConnectionListener_2 swigDelegate2;
  private SwigDelegateNetworkConnectionListener_3 swigDelegate3;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(NetworkConnection) };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(NetworkConnection) };
  private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(NetworkConnection) };
  private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(NetworkConnection), typeof(NetworkInMessage) };
}

}
