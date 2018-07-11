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

class SharingClientPINVOKE {

  protected class SWIGExceptionHelper {

    public delegate void ExceptionDelegate(string message);
    public delegate void ExceptionArgumentDelegate(string message, string paramName);

    static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
    static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
    static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
    static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
    static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
    static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
    static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
    static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
    static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
    static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
    static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

    static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
    static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
    static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

    [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="SWIGRegisterExceptionCallbacks_SharingClient")]
    public static extern void SWIGRegisterExceptionCallbacks_SharingClient(
                                ExceptionDelegate applicationDelegate,
                                ExceptionDelegate arithmeticDelegate,
                                ExceptionDelegate divideByZeroDelegate, 
                                ExceptionDelegate indexOutOfRangeDelegate, 
                                ExceptionDelegate invalidCastDelegate,
                                ExceptionDelegate invalidOperationDelegate,
                                ExceptionDelegate ioDelegate,
                                ExceptionDelegate nullReferenceDelegate,
                                ExceptionDelegate outOfMemoryDelegate, 
                                ExceptionDelegate overflowDelegate, 
                                ExceptionDelegate systemExceptionDelegate);

    [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_SharingClient")]
    public static extern void SWIGRegisterExceptionCallbacksArgument_SharingClient(
                                ExceptionArgumentDelegate argumentDelegate,
                                ExceptionArgumentDelegate argumentNullDelegate,
                                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

    static void SetPendingApplicationException(string message) {
      SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArithmeticException(string message) {
      SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingDivideByZeroException(string message) {
      SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIndexOutOfRangeException(string message) {
      SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidCastException(string message) {
      SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidOperationException(string message) {
      SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIOException(string message) {
      SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingNullReferenceException(string message) {
      SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOutOfMemoryException(string message) {
      SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOverflowException(string message) {
      SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingSystemException(string message) {
      SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
    }

    static void SetPendingArgumentException(string message, string paramName) {
      SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArgumentNullException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentNullException(paramName, message));
    }
    static void SetPendingArgumentOutOfRangeException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
    }

    static SWIGExceptionHelper() {
      SWIGRegisterExceptionCallbacks_SharingClient(
                                applicationDelegate,
                                arithmeticDelegate,
                                divideByZeroDelegate,
                                indexOutOfRangeDelegate,
                                invalidCastDelegate,
                                invalidOperationDelegate,
                                ioDelegate,
                                nullReferenceDelegate,
                                outOfMemoryDelegate,
                                overflowDelegate,
                                systemDelegate);

      SWIGRegisterExceptionCallbacksArgument_SharingClient(
                                argumentDelegate,
                                argumentNullDelegate,
                                argumentOutOfRangeDelegate);
    }
  }

  protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

  public class SWIGPendingException {
    [global::System.ThreadStatic]
    private static global::System.Exception pendingException = null;
    private static int numExceptionsPending = 0;

    public static bool Pending {
      get {
        bool pending = false;
        if (numExceptionsPending > 0)
          if (pendingException != null)
            pending = true;
        return pending;
      } 
    }

    public static void Set(global::System.Exception e) {
      if (pendingException != null)
        throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
      pendingException = e;
      lock(typeof(SharingClientPINVOKE)) {
        numExceptionsPending++;
      }
    }

    public static global::System.Exception Retrieve() {
      global::System.Exception e = null;
      if (numExceptionsPending > 0) {
        if (pendingException != null) {
          e = pendingException;
          pendingException = null;
          lock(typeof(SharingClientPINVOKE)) {
            numExceptionsPending--;
          }
        }
      }
      return e;
    }
  }


  protected class SWIGStringHelper {

    public delegate string SWIGStringDelegate(string message);
    static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

    [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="SWIGRegisterStringCallback_SharingClient")]
    public static extern void SWIGRegisterStringCallback_SharingClient(SWIGStringDelegate stringDelegate);

    static string CreateString(string cString) {
      return cString;
    }

    static SWIGStringHelper() {
      SWIGRegisterStringCallback_SharingClient(stringDelegate);
    }
  }

  static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


  static SharingClientPINVOKE() {
  }


  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_kInvalidSocketID_get___")]
  public static extern ulong kInvalidSocketID_get();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_kInvalidConnectionGUID_get___")]
  public static extern ulong kInvalidConnectionGUID_get();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Receipt___")]
  public static extern void delete_Receipt(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Receipt_Clear___")]
  public static extern void Receipt_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_Receipt___")]
  public static extern global::System.IntPtr new_Receipt();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_LogManager___")]
  public static extern void delete_LogManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LogManager_Log___")]
  public static extern void LogManager_Log(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_LogWriter___")]
  public static extern void delete_LogWriter(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LogWriter_WriteLogEntry___")]
  public static extern void LogWriter_WriteLogEntry(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LogWriter_WriteLogEntrySwigExplicitLogWriter___")]
  public static extern void LogWriter_WriteLogEntrySwigExplicitLogWriter(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_LogWriter___")]
  public static extern global::System.IntPtr new_LogWriter();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LogWriter_director_connect___")]
  public static extern void LogWriter_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LogWriter.SwigDelegateLogWriter_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Log_Info___")]
  public static extern void Log_Info([global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Log_Warning___")]
  public static extern void Log_Warning([global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Log_Error___")]
  public static extern void Log_Error([global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_Log___")]
  public static extern global::System.IntPtr new_Log();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Log___")]
  public static extern void delete_Log(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Listener___")]
  public static extern void delete_Listener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Listener_UnregisterAll___")]
  public static extern void Listener_UnregisterAll(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Listener_IsRegistered___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool Listener_IsRegistered(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_Listener___")]
  public static extern global::System.IntPtr new_Listener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_kInvalidXGuid_get___")]
  public static extern long kInvalidXGuid_get();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_XString__SWIG_0___")]
  public static extern global::System.IntPtr new_XString__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_XString__SWIG_1___")]
  public static extern global::System.IntPtr new_XString__SWIG_1(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_XString___")]
  public static extern void delete_XString(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_XString_GetLength___")]
  public static extern uint XString_GetLength(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_XString_IsEqual___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool XString_IsEqual(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_XString_GetString___")]
  public static extern string XString_GetString(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_0___")]
  public static extern void NetworkOutMessage_Write__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_1___")]
  public static extern void NetworkOutMessage_Write__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, short jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_2___")]
  public static extern void NetworkOutMessage_Write__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_3___")]
  public static extern void NetworkOutMessage_Write__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_4___")]
  public static extern void NetworkOutMessage_Write__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_5___")]
  public static extern void NetworkOutMessage_Write__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Write__SWIG_6___")]
  public static extern void NetworkOutMessage_Write__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_WriteArray___")]
  public static extern void NetworkOutMessage_WriteArray(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkOutMessage_Reset___")]
  public static extern void NetworkOutMessage_Reset(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_NetworkOutMessage___")]
  public static extern void delete_NetworkOutMessage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_NetworkInMessage___")]
  public static extern void delete_NetworkInMessage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadByte___")]
  public static extern byte NetworkInMessage_ReadByte(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadInt16___")]
  public static extern short NetworkInMessage_ReadInt16(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadInt32___")]
  public static extern int NetworkInMessage_ReadInt32(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadInt64___")]
  public static extern long NetworkInMessage_ReadInt64(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadFloat___")]
  public static extern float NetworkInMessage_ReadFloat(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadDouble___")]
  public static extern double NetworkInMessage_ReadDouble(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadString___")]
  public static extern global::System.IntPtr NetworkInMessage_ReadString(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_ReadArray___")]
  public static extern void NetworkInMessage_ReadArray(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_GetUnreadBitsCount___")]
  public static extern int NetworkInMessage_GetUnreadBitsCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkInMessage_GetSize___")]
  public static extern int NetworkInMessage_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_NetworkConnectionListener___")]
  public static extern void delete_NetworkConnectionListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnConnected___")]
  public static extern void NetworkConnectionListener_OnConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnConnectedSwigExplicitNetworkConnectionListener___")]
  public static extern void NetworkConnectionListener_OnConnectedSwigExplicitNetworkConnectionListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnConnectFailed___")]
  public static extern void NetworkConnectionListener_OnConnectFailed(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnConnectFailedSwigExplicitNetworkConnectionListener___")]
  public static extern void NetworkConnectionListener_OnConnectFailedSwigExplicitNetworkConnectionListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnDisconnected___")]
  public static extern void NetworkConnectionListener_OnDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnDisconnectedSwigExplicitNetworkConnectionListener___")]
  public static extern void NetworkConnectionListener_OnDisconnectedSwigExplicitNetworkConnectionListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnMessageReceived___")]
  public static extern void NetworkConnectionListener_OnMessageReceived(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_OnMessageReceivedSwigExplicitNetworkConnectionListener___")]
  public static extern void NetworkConnectionListener_OnMessageReceivedSwigExplicitNetworkConnectionListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_NetworkConnectionListener___")]
  public static extern global::System.IntPtr new_NetworkConnectionListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_director_connect___")]
  public static extern void NetworkConnectionListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, NetworkConnectionListener.SwigDelegateNetworkConnectionListener_0 delegate0, NetworkConnectionListener.SwigDelegateNetworkConnectionListener_1 delegate1, NetworkConnectionListener.SwigDelegateNetworkConnectionListener_2 delegate2, NetworkConnectionListener.SwigDelegateNetworkConnectionListener_3 delegate3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_User_GetName___")]
  public static extern global::System.IntPtr User_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_User_GetID___")]
  public static extern int User_GetID(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_User_IsValid___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool User_IsValid(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_User_GetMuteState___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool User_GetMuteState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_User___")]
  public static extern void delete_User(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_IsConnected___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool NetworkConnection_IsConnected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_GetConnectionGUID___")]
  public static extern ulong NetworkConnection_GetConnectionGUID(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Send__SWIG_0___")]
  public static extern void NetworkConnection_Send__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, int jarg5, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg6);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Send__SWIG_1___")]
  public static extern void NetworkConnection_Send__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Send__SWIG_2___")]
  public static extern void NetworkConnection_Send__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Send__SWIG_3___")]
  public static extern void NetworkConnection_Send__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Send__SWIG_4___")]
  public static extern void NetworkConnection_Send__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_SendTo__SWIG_0___")]
  public static extern void NetworkConnection_SendTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, int jarg6, int jarg7, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg8);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_SendTo__SWIG_1___")]
  public static extern void NetworkConnection_SendTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, int jarg6, int jarg7);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_SendTo__SWIG_2___")]
  public static extern void NetworkConnection_SendTo__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, int jarg6);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_SendTo__SWIG_3___")]
  public static extern void NetworkConnection_SendTo__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_SendTo__SWIG_4___")]
  public static extern void NetworkConnection_SendTo__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Broadcast__SWIG_0___")]
  public static extern void NetworkConnection_Broadcast__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, int jarg5, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg6);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Broadcast__SWIG_1___")]
  public static extern void NetworkConnection_Broadcast__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Broadcast__SWIG_2___")]
  public static extern void NetworkConnection_Broadcast__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Broadcast__SWIG_3___")]
  public static extern void NetworkConnection_Broadcast__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Broadcast__SWIG_4___")]
  public static extern void NetworkConnection_Broadcast__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_AddListener___")]
  public static extern void NetworkConnection_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_RemoveListener___")]
  public static extern void NetworkConnection_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_AddListenerAsync___")]
  public static extern void NetworkConnection_AddListenerAsync(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_RemoveListenerAsync___")]
  public static extern void NetworkConnection_RemoveListenerAsync(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_CreateMessage___")]
  public static extern global::System.IntPtr NetworkConnection_CreateMessage(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_ReturnMessage___")]
  public static extern void NetworkConnection_ReturnMessage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_Disconnect___")]
  public static extern void NetworkConnection_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnection_GetRemoteAddress___")]
  public static extern global::System.IntPtr NetworkConnection_GetRemoteAddress(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_NetworkConnection___")]
  public static extern void delete_NetworkConnection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Element_GetElementType___")]
  public static extern int Element_GetElementType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Element_GetGUID___")]
  public static extern long Element_GetGUID(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Element_GetName___")]
  public static extern global::System.IntPtr Element_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Element_GetParent___")]
  public static extern global::System.IntPtr Element_GetParent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Element_IsValid___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool Element_IsValid(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Element___")]
  public static extern void delete_Element(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_BoolElement_Cast___")]
  public static extern global::System.IntPtr BoolElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_BoolElement_GetValue___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool BoolElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_BoolElement_SetValue___")]
  public static extern void BoolElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_BoolElement___")]
  public static extern void delete_BoolElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntElement_Cast___")]
  public static extern global::System.IntPtr IntElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntElement_GetValue___")]
  public static extern int IntElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntElement_SetValue___")]
  public static extern void IntElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_IntElement___")]
  public static extern void delete_IntElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LongElement_Cast___")]
  public static extern global::System.IntPtr LongElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LongElement_GetValue___")]
  public static extern long LongElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LongElement_SetValue___")]
  public static extern void LongElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_LongElement___")]
  public static extern void delete_LongElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatElement_Cast___")]
  public static extern global::System.IntPtr FloatElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatElement_GetValue___")]
  public static extern float FloatElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatElement_SetValue___")]
  public static extern void FloatElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_FloatElement___")]
  public static extern void delete_FloatElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DoubleElement_Cast___")]
  public static extern global::System.IntPtr DoubleElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DoubleElement_GetValue___")]
  public static extern double DoubleElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DoubleElement_SetValue___")]
  public static extern void DoubleElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_DoubleElement___")]
  public static extern void delete_DoubleElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringElement_Cast___")]
  public static extern global::System.IntPtr StringElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringElement_GetValue___")]
  public static extern global::System.IntPtr StringElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringElement_SetValue___")]
  public static extern void StringElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_StringElement___")]
  public static extern void delete_StringElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_IntArrayListener___")]
  public static extern void delete_IntArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_OnValueChanged___")]
  public static extern void IntArrayListener_OnValueChanged(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_OnValueChangedSwigExplicitIntArrayListener___")]
  public static extern void IntArrayListener_OnValueChangedSwigExplicitIntArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_OnValueInserted___")]
  public static extern void IntArrayListener_OnValueInserted(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_OnValueInsertedSwigExplicitIntArrayListener___")]
  public static extern void IntArrayListener_OnValueInsertedSwigExplicitIntArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_OnValueRemoved___")]
  public static extern void IntArrayListener_OnValueRemoved(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_OnValueRemovedSwigExplicitIntArrayListener___")]
  public static extern void IntArrayListener_OnValueRemovedSwigExplicitIntArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_IntArrayListener___")]
  public static extern global::System.IntPtr new_IntArrayListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_director_connect___")]
  public static extern void IntArrayListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, IntArrayListener.SwigDelegateIntArrayListener_0 delegate0, IntArrayListener.SwigDelegateIntArrayListener_1 delegate1, IntArrayListener.SwigDelegateIntArrayListener_2 delegate2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_Cast___")]
  public static extern global::System.IntPtr IntArrayElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_GetCount___")]
  public static extern int IntArrayElement_GetCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_GetValue___")]
  public static extern int IntArrayElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_SetValue___")]
  public static extern void IntArrayElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_InsertValue___")]
  public static extern void IntArrayElement_InsertValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_RemoveValue___")]
  public static extern void IntArrayElement_RemoveValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_AddListener___")]
  public static extern void IntArrayElement_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_RemoveListener___")]
  public static extern void IntArrayElement_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_IntArrayElement___")]
  public static extern void delete_IntArrayElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_FloatArrayListener___")]
  public static extern void delete_FloatArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_OnValueChanged___")]
  public static extern void FloatArrayListener_OnValueChanged(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_OnValueChangedSwigExplicitFloatArrayListener___")]
  public static extern void FloatArrayListener_OnValueChangedSwigExplicitFloatArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_OnValueInserted___")]
  public static extern void FloatArrayListener_OnValueInserted(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_OnValueInsertedSwigExplicitFloatArrayListener___")]
  public static extern void FloatArrayListener_OnValueInsertedSwigExplicitFloatArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_OnValueRemoved___")]
  public static extern void FloatArrayListener_OnValueRemoved(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_OnValueRemovedSwigExplicitFloatArrayListener___")]
  public static extern void FloatArrayListener_OnValueRemovedSwigExplicitFloatArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_FloatArrayListener___")]
  public static extern global::System.IntPtr new_FloatArrayListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_director_connect___")]
  public static extern void FloatArrayListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, FloatArrayListener.SwigDelegateFloatArrayListener_0 delegate0, FloatArrayListener.SwigDelegateFloatArrayListener_1 delegate1, FloatArrayListener.SwigDelegateFloatArrayListener_2 delegate2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_Cast___")]
  public static extern global::System.IntPtr FloatArrayElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_GetCount___")]
  public static extern int FloatArrayElement_GetCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_GetValue___")]
  public static extern float FloatArrayElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_SetValue___")]
  public static extern void FloatArrayElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_InsertValue___")]
  public static extern void FloatArrayElement_InsertValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_RemoveValue___")]
  public static extern void FloatArrayElement_RemoveValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_AddListener___")]
  public static extern void FloatArrayElement_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_RemoveListener___")]
  public static extern void FloatArrayElement_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_FloatArrayElement___")]
  public static extern void delete_FloatArrayElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_StringArrayListener___")]
  public static extern void delete_StringArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_OnValueChanged___")]
  public static extern void StringArrayListener_OnValueChanged(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_OnValueChangedSwigExplicitStringArrayListener___")]
  public static extern void StringArrayListener_OnValueChangedSwigExplicitStringArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_OnValueInserted___")]
  public static extern void StringArrayListener_OnValueInserted(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_OnValueInsertedSwigExplicitStringArrayListener___")]
  public static extern void StringArrayListener_OnValueInsertedSwigExplicitStringArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_OnValueRemoved___")]
  public static extern void StringArrayListener_OnValueRemoved(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_OnValueRemovedSwigExplicitStringArrayListener___")]
  public static extern void StringArrayListener_OnValueRemovedSwigExplicitStringArrayListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_StringArrayListener___")]
  public static extern global::System.IntPtr new_StringArrayListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_director_connect___")]
  public static extern void StringArrayListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, StringArrayListener.SwigDelegateStringArrayListener_0 delegate0, StringArrayListener.SwigDelegateStringArrayListener_1 delegate1, StringArrayListener.SwigDelegateStringArrayListener_2 delegate2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_Cast___")]
  public static extern global::System.IntPtr StringArrayElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_GetCount___")]
  public static extern int StringArrayElement_GetCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_GetValue___")]
  public static extern global::System.IntPtr StringArrayElement_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_SetValue___")]
  public static extern void StringArrayElement_SetValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_InsertValue___")]
  public static extern void StringArrayElement_InsertValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_RemoveValue___")]
  public static extern void StringArrayElement_RemoveValue(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_AddListener___")]
  public static extern void StringArrayElement_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_RemoveListener___")]
  public static extern void StringArrayElement_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_StringArrayElement___")]
  public static extern void delete_StringArrayElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_ObjectElementListener___")]
  public static extern void delete_ObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnBoolElementChanged___")]
  public static extern void ObjectElementListener_OnBoolElementChanged(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnBoolElementChangedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnBoolElementChangedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnIntElementChanged___")]
  public static extern void ObjectElementListener_OnIntElementChanged(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnIntElementChangedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnIntElementChangedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnLongElementChanged___")]
  public static extern void ObjectElementListener_OnLongElementChanged(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, long jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnLongElementChangedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnLongElementChangedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, long jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnFloatElementChanged___")]
  public static extern void ObjectElementListener_OnFloatElementChanged(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnFloatElementChangedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnFloatElementChangedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnDoubleElementChanged___")]
  public static extern void ObjectElementListener_OnDoubleElementChanged(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, double jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnDoubleElementChangedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnDoubleElementChangedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, double jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnStringElementChanged___")]
  public static extern void ObjectElementListener_OnStringElementChanged(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnStringElementChangedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnStringElementChangedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnElementAdded___")]
  public static extern void ObjectElementListener_OnElementAdded(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnElementAddedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnElementAddedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnElementDeleted___")]
  public static extern void ObjectElementListener_OnElementDeleted(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_OnElementDeletedSwigExplicitObjectElementListener___")]
  public static extern void ObjectElementListener_OnElementDeletedSwigExplicitObjectElementListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_ObjectElementListener___")]
  public static extern global::System.IntPtr new_ObjectElementListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_director_connect___")]
  public static extern void ObjectElementListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ObjectElementListener.SwigDelegateObjectElementListener_0 delegate0, ObjectElementListener.SwigDelegateObjectElementListener_1 delegate1, ObjectElementListener.SwigDelegateObjectElementListener_2 delegate2, ObjectElementListener.SwigDelegateObjectElementListener_3 delegate3, ObjectElementListener.SwigDelegateObjectElementListener_4 delegate4, ObjectElementListener.SwigDelegateObjectElementListener_5 delegate5, ObjectElementListener.SwigDelegateObjectElementListener_6 delegate6, ObjectElementListener.SwigDelegateObjectElementListener_7 delegate7);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_Cast___")]
  public static extern global::System.IntPtr ObjectElement_Cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateBoolElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateBoolElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateIntElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateIntElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateLongElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateLongElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, long jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateFloatElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateFloatElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateDoubleElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateDoubleElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, double jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateStringElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateStringElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateObjectElement__SWIG_0___")]
  public static extern global::System.IntPtr ObjectElement_CreateObjectElement__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateObjectElement__SWIG_1___")]
  public static extern global::System.IntPtr ObjectElement_CreateObjectElement__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateIntArrayElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateIntArrayElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateFloatArrayElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateFloatArrayElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_CreateStringArrayElement___")]
  public static extern global::System.IntPtr ObjectElement_CreateStringArrayElement(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_GetElementCount___")]
  public static extern int ObjectElement_GetElementCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_GetElement__SWIG_0___")]
  public static extern global::System.IntPtr ObjectElement_GetElement__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_GetElement__SWIG_1___")]
  public static extern global::System.IntPtr ObjectElement_GetElement__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_GetElementAt___")]
  public static extern global::System.IntPtr ObjectElement_GetElementAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_RemoveElement__SWIG_0___")]
  public static extern void ObjectElement_RemoveElement__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_RemoveElement__SWIG_1___")]
  public static extern void ObjectElement_RemoveElement__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_RemoveElementAt___")]
  public static extern void ObjectElement_RemoveElementAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_AddListener___")]
  public static extern void ObjectElement_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_RemoveListener___")]
  public static extern void ObjectElement_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_GetOwnerID___")]
  public static extern int ObjectElement_GetOwnerID(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_GetObjectType___")]
  public static extern global::System.IntPtr ObjectElement_GetObjectType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_ObjectElement___")]
  public static extern void delete_ObjectElement(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SyncListener_OnSyncChangesBegin___")]
  public static extern void SyncListener_OnSyncChangesBegin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SyncListener_OnSyncChangesBeginSwigExplicitSyncListener___")]
  public static extern void SyncListener_OnSyncChangesBeginSwigExplicitSyncListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SyncListener_OnSyncChangesEnd___")]
  public static extern void SyncListener_OnSyncChangesEnd(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SyncListener_OnSyncChangesEndSwigExplicitSyncListener___")]
  public static extern void SyncListener_OnSyncChangesEndSwigExplicitSyncListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_SyncListener___")]
  public static extern global::System.IntPtr new_SyncListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_SyncListener___")]
  public static extern void delete_SyncListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SyncListener_director_connect___")]
  public static extern void SyncListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, SyncListener.SwigDelegateSyncListener_0 delegate0, SyncListener.SwigDelegateSyncListener_1 delegate1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_SessionListener___")]
  public static extern void delete_SessionListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnJoiningSession___")]
  public static extern void SessionListener_OnJoiningSession(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnJoiningSessionSwigExplicitSessionListener___")]
  public static extern void SessionListener_OnJoiningSessionSwigExplicitSessionListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnJoinSucceeded___")]
  public static extern void SessionListener_OnJoinSucceeded(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnJoinSucceededSwigExplicitSessionListener___")]
  public static extern void SessionListener_OnJoinSucceededSwigExplicitSessionListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnJoinFailed___")]
  public static extern void SessionListener_OnJoinFailed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnJoinFailedSwigExplicitSessionListener___")]
  public static extern void SessionListener_OnJoinFailedSwigExplicitSessionListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnSessionDisconnected___")]
  public static extern void SessionListener_OnSessionDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_OnSessionDisconnectedSwigExplicitSessionListener___")]
  public static extern void SessionListener_OnSessionDisconnectedSwigExplicitSessionListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_SessionListener___")]
  public static extern global::System.IntPtr new_SessionListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_director_connect___")]
  public static extern void SessionListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, SessionListener.SwigDelegateSessionListener_0 delegate0, SessionListener.SwigDelegateSessionListener_1 delegate1, SessionListener.SwigDelegateSessionListener_2 delegate2, SessionListener.SwigDelegateSessionListener_3 delegate3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_GetMachineSessionState___")]
  public static extern int Session_GetMachineSessionState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_AddListener___")]
  public static extern void Session_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_RemoveListener___")]
  public static extern void Session_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_IsJoined___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool Session_IsJoined(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_Join___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool Session_Join(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_Leave___")]
  public static extern void Session_Leave(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_GetUserCount___")]
  public static extern int Session_GetUserCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_GetUser___")]
  public static extern global::System.IntPtr Session_GetUser(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_GetSessionType___")]
  public static extern int Session_GetSessionType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_GetName___")]
  public static extern global::System.IntPtr Session_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Session_GetSessionNetworkConnection___")]
  public static extern global::System.IntPtr Session_GetSessionNetworkConnection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Session___")]
  public static extern void delete_Session(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_SessionManagerListener___")]
  public static extern void delete_SessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnCreateSucceeded___")]
  public static extern void SessionManagerListener_OnCreateSucceeded(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnCreateSucceededSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnCreateSucceededSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnCreateFailed___")]
  public static extern void SessionManagerListener_OnCreateFailed(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnCreateFailedSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnCreateFailedSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnSessionAdded___")]
  public static extern void SessionManagerListener_OnSessionAdded(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnSessionAddedSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnSessionAddedSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnSessionClosed___")]
  public static extern void SessionManagerListener_OnSessionClosed(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnSessionClosedSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnSessionClosedSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnUserJoinedSession___")]
  public static extern void SessionManagerListener_OnUserJoinedSession(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnUserJoinedSessionSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnUserJoinedSessionSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnUserLeftSession___")]
  public static extern void SessionManagerListener_OnUserLeftSession(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnUserLeftSessionSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnUserLeftSessionSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnUserChanged___")]
  public static extern void SessionManagerListener_OnUserChanged(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnUserChangedSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnUserChangedSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnServerConnected___")]
  public static extern void SessionManagerListener_OnServerConnected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnServerConnectedSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnServerConnectedSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnServerDisconnected___")]
  public static extern void SessionManagerListener_OnServerDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_OnServerDisconnectedSwigExplicitSessionManagerListener___")]
  public static extern void SessionManagerListener_OnServerDisconnectedSwigExplicitSessionManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_SessionManagerListener___")]
  public static extern global::System.IntPtr new_SessionManagerListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_director_connect___")]
  public static extern void SessionManagerListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, SessionManagerListener.SwigDelegateSessionManagerListener_0 delegate0, SessionManagerListener.SwigDelegateSessionManagerListener_1 delegate1, SessionManagerListener.SwigDelegateSessionManagerListener_2 delegate2, SessionManagerListener.SwigDelegateSessionManagerListener_3 delegate3, SessionManagerListener.SwigDelegateSessionManagerListener_4 delegate4, SessionManagerListener.SwigDelegateSessionManagerListener_5 delegate5, SessionManagerListener.SwigDelegateSessionManagerListener_6 delegate6, SessionManagerListener.SwigDelegateSessionManagerListener_7 delegate7, SessionManagerListener.SwigDelegateSessionManagerListener_8 delegate8);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_AddListener___")]
  public static extern void SessionManager_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_RemoveListener___")]
  public static extern void SessionManager_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_CreateSession__SWIG_0___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool SessionManager_CreateSession__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_CreateSession__SWIG_1___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool SessionManager_CreateSession__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_GetSessionCount___")]
  public static extern int SessionManager_GetSessionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_GetSession___")]
  public static extern global::System.IntPtr SessionManager_GetSession(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_GetCurrentSession___")]
  public static extern global::System.IntPtr SessionManager_GetCurrentSession(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_GetCurrentUser___")]
  public static extern global::System.IntPtr SessionManager_GetCurrentUser(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManager_IsServerConnected___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool SessionManager_IsServerConnected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_SessionManager___")]
  public static extern void delete_SessionManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_UserPresenceManagerListener___")]
  public static extern void delete_UserPresenceManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManagerListener_OnUserPresenceChanged___")]
  public static extern void UserPresenceManagerListener_OnUserPresenceChanged(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManagerListener_OnUserPresenceChangedSwigExplicitUserPresenceManagerListener___")]
  public static extern void UserPresenceManagerListener_OnUserPresenceChangedSwigExplicitUserPresenceManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_UserPresenceManagerListener___")]
  public static extern global::System.IntPtr new_UserPresenceManagerListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManagerListener_director_connect___")]
  public static extern void UserPresenceManagerListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, UserPresenceManagerListener.SwigDelegateUserPresenceManagerListener_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_AddListener___")]
  public static extern void UserPresenceManager_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_RemoveListener___")]
  public static extern void UserPresenceManager_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_GetMuteState___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool UserPresenceManager_GetMuteState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_SetMuteState___")]
  public static extern void UserPresenceManager_SetMuteState(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_SetName___")]
  public static extern void UserPresenceManager_SetName(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_GetName___")]
  public static extern global::System.IntPtr UserPresenceManager_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManager_SetUser___")]
  public static extern void UserPresenceManager_SetUser(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_UserPresenceManager___")]
  public static extern void delete_UserPresenceManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_ClientConfig___")]
  public static extern global::System.IntPtr new_ClientConfig(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_GetRole___")]
  public static extern int ClientConfig_GetRole(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_GetServerAddress___")]
  public static extern string ClientConfig_GetServerAddress(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_SetServerAddress___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool ClientConfig_SetServerAddress(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_GetServerPort___")]
  public static extern int ClientConfig_GetServerPort(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_SetServerPort___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool ClientConfig_SetServerPort(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_GetLogWriter___")]
  public static extern global::System.IntPtr ClientConfig_GetLogWriter(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_SetLogWriter___")]
  public static extern void ClientConfig_SetLogWriter(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_GetIsAudioEndpoint___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool ClientConfig_GetIsAudioEndpoint(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_SetIsAudioEndpoint___")]
  public static extern void ClientConfig_SetIsAudioEndpoint(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_GetProfilerEnabled___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool ClientConfig_GetProfilerEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ClientConfig_SetProfilerEnabled___")]
  public static extern void ClientConfig_SetProfilerEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_ClientConfig___")]
  public static extern void delete_ClientConfig(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_AudioManager_SetMicrophoneEnabled___")]
  public static extern void AudioManager_SetMicrophoneEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_AudioManager___")]
  public static extern void delete_AudioManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_ProfileManager___")]
  public static extern void delete_ProfileManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ProfileManager_BeginRange___")]
  public static extern void ProfileManager_BeginRange(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ProfileManager_EndRange___")]
  public static extern void ProfileManager_EndRange(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ProfileManager_Log___")]
  public static extern void ProfileManager_Log(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Profile_BeginRange___")]
  public static extern void Profile_BeginRange(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Profile_EndRange___")]
  public static extern void Profile_EndRange();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_Profile___")]
  public static extern global::System.IntPtr new_Profile();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Profile___")]
  public static extern void delete_Profile(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetName___")]
  public static extern global::System.IntPtr Room_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetID___")]
  public static extern long Room_GetID(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetUserCount___")]
  public static extern int Room_GetUserCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetUserID___")]
  public static extern int Room_GetUserID(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetKeepOpen___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool Room_GetKeepOpen(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_SetKeepOpen___")]
  public static extern void Room_SetKeepOpen(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetAnchorCount___")]
  public static extern int Room_GetAnchorCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Room_GetAnchorName___")]
  public static extern global::System.IntPtr Room_GetAnchorName(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Room___")]
  public static extern void delete_Room(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_AnchorDownloadRequest_GetAnchorName___")]
  public static extern global::System.IntPtr AnchorDownloadRequest_GetAnchorName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_AnchorDownloadRequest_GetRoom___")]
  public static extern global::System.IntPtr AnchorDownloadRequest_GetRoom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_AnchorDownloadRequest_GetDataSize___")]
  public static extern int AnchorDownloadRequest_GetDataSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_AnchorDownloadRequest_GetData___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool AnchorDownloadRequest_GetData(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_AnchorDownloadRequest___")]
  public static extern void delete_AnchorDownloadRequest(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_RoomManagerListener___")]
  public static extern void delete_RoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnRoomAdded___")]
  public static extern void RoomManagerListener_OnRoomAdded(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnRoomAddedSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnRoomAddedSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnRoomClosed___")]
  public static extern void RoomManagerListener_OnRoomClosed(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnRoomClosedSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnRoomClosedSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnUserJoinedRoom___")]
  public static extern void RoomManagerListener_OnUserJoinedRoom(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnUserJoinedRoomSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnUserJoinedRoomSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnUserLeftRoom___")]
  public static extern void RoomManagerListener_OnUserLeftRoom(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnUserLeftRoomSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnUserLeftRoomSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnAnchorsChanged___")]
  public static extern void RoomManagerListener_OnAnchorsChanged(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnAnchorsChangedSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnAnchorsChangedSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnAnchorsDownloaded___")]
  public static extern void RoomManagerListener_OnAnchorsDownloaded(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnAnchorsDownloadedSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnAnchorsDownloadedSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnAnchorUploadComplete___")]
  public static extern void RoomManagerListener_OnAnchorUploadComplete(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_OnAnchorUploadCompleteSwigExplicitRoomManagerListener___")]
  public static extern void RoomManagerListener_OnAnchorUploadCompleteSwigExplicitRoomManagerListener(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_RoomManagerListener___")]
  public static extern global::System.IntPtr new_RoomManagerListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_director_connect___")]
  public static extern void RoomManagerListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, RoomManagerListener.SwigDelegateRoomManagerListener_0 delegate0, RoomManagerListener.SwigDelegateRoomManagerListener_1 delegate1, RoomManagerListener.SwigDelegateRoomManagerListener_2 delegate2, RoomManagerListener.SwigDelegateRoomManagerListener_3 delegate3, RoomManagerListener.SwigDelegateRoomManagerListener_4 delegate4, RoomManagerListener.SwigDelegateRoomManagerListener_5 delegate5, RoomManagerListener.SwigDelegateRoomManagerListener_6 delegate6);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_AddListener___")]
  public static extern void RoomManager_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_RemoveListener___")]
  public static extern void RoomManager_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_GetRoomCount___")]
  public static extern int RoomManager_GetRoomCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_GetRoom___")]
  public static extern global::System.IntPtr RoomManager_GetRoom(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_GetCurrentRoom___")]
  public static extern global::System.IntPtr RoomManager_GetCurrentRoom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_CreateRoom___")]
  public static extern global::System.IntPtr RoomManager_CreateRoom(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, long jarg3, [global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_JoinRoom___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool RoomManager_JoinRoom(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_LeaveRoom___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool RoomManager_LeaveRoom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_DownloadAnchor___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool RoomManager_DownloadAnchor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManager_UploadAnchor___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool RoomManager_UploadAnchor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.IntPtr jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_RoomManager___")]
  public static extern void delete_RoomManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_Settings___")]
  public static extern global::System.IntPtr new_Settings();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Settings_GetServerAddress___")]
  public static extern global::System.IntPtr Settings_GetServerAddress(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Settings_GetServerPort___")]
  public static extern int Settings_GetServerPort(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Settings_GetViewerAddress___")]
  public static extern global::System.IntPtr Settings_GetViewerAddress(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Settings_GetViewerPort___")]
  public static extern int Settings_GetViewerPort(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_Settings_GetLocalUserName___")]
  public static extern global::System.IntPtr Settings_GetLocalUserName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_Settings___")]
  public static extern void delete_Settings(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_IsReceiver___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairMaker_IsReceiver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_IsReceiverSwigExplicitPairMaker___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairMaker_IsReceiverSwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetAddressCount___")]
  public static extern int PairMaker_GetAddressCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetAddress___")]
  public static extern global::System.IntPtr PairMaker_GetAddress(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetAddressSwigExplicitPairMaker___")]
  public static extern global::System.IntPtr PairMaker_GetAddressSwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetPort___")]
  public static extern ushort PairMaker_GetPort(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetPortSwigExplicitPairMaker___")]
  public static extern ushort PairMaker_GetPortSwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_Update___")]
  public static extern void PairMaker_Update(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_UpdateSwigExplicitPairMaker___")]
  public static extern void PairMaker_UpdateSwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_IsReadyToConnect___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairMaker_IsReadyToConnect(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_IsReadyToConnectSwigExplicitPairMaker___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairMaker_IsReadyToConnectSwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetLocalKey___")]
  public static extern int PairMaker_GetLocalKey(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetLocalKeySwigExplicitPairMaker___")]
  public static extern int PairMaker_GetLocalKeySwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetRemoteKey___")]
  public static extern int PairMaker_GetRemoteKey(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_GetRemoteKeySwigExplicitPairMaker___")]
  public static extern int PairMaker_GetRemoteKeySwigExplicitPairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_PairMaker___")]
  public static extern global::System.IntPtr new_PairMaker();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_PairMaker___")]
  public static extern void delete_PairMaker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairMaker_director_connect___")]
  public static extern void PairMaker_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, PairMaker.SwigDelegatePairMaker_0 delegate0, PairMaker.SwigDelegatePairMaker_1 delegate1, PairMaker.SwigDelegatePairMaker_2 delegate2, PairMaker.SwigDelegatePairMaker_3 delegate3, PairMaker.SwigDelegatePairMaker_4 delegate4, PairMaker.SwigDelegatePairMaker_5 delegate5, PairMaker.SwigDelegatePairMaker_6 delegate6, PairMaker.SwigDelegatePairMaker_7 delegate7);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingListener_PairingConnectionSucceeded___")]
  public static extern void PairingListener_PairingConnectionSucceeded(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingListener_PairingConnectionSucceededSwigExplicitPairingListener___")]
  public static extern void PairingListener_PairingConnectionSucceededSwigExplicitPairingListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingListener_PairingConnectionFailed___")]
  public static extern void PairingListener_PairingConnectionFailed(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingListener_PairingConnectionFailedSwigExplicitPairingListener___")]
  public static extern void PairingListener_PairingConnectionFailedSwigExplicitPairingListener(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_PairingListener___")]
  public static extern global::System.IntPtr new_PairingListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_PairingListener___")]
  public static extern void delete_PairingListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingListener_director_connect___")]
  public static extern void PairingListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, PairingListener.SwigDelegatePairingListener_0 delegate0, PairingListener.SwigDelegatePairingListener_1 delegate1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_HasPairingInfo___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairingManager_HasPairingInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_ClearPairingInfo___")]
  public static extern void PairingManager_ClearPairingInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_BeginConnecting___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairingManager_BeginConnecting(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_CancelConnecting___")]
  public static extern void PairingManager_CancelConnecting(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_BeginPairing___")]
  public static extern int PairingManager_BeginPairing(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_CancelPairing___")]
  public static extern void PairingManager_CancelPairing(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_IsPairing___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairingManager_IsPairing(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingManager_IsConnected___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool PairingManager_IsConnected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_PairingManager___")]
  public static extern void delete_PairingManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_Create___")]
  public static extern global::System.IntPtr SharingManager_Create(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetSessionManager___")]
  public static extern global::System.IntPtr SharingManager_GetSessionManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetUserPresenceManager___")]
  public static extern global::System.IntPtr SharingManager_GetUserPresenceManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetAudioManager___")]
  public static extern global::System.IntPtr SharingManager_GetAudioManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetPairingManager___")]
  public static extern global::System.IntPtr SharingManager_GetPairingManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetRoomManager___")]
  public static extern global::System.IntPtr SharingManager_GetRoomManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetRootSyncObject___")]
  public static extern global::System.IntPtr SharingManager_GetRootSyncObject(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_RegisterSyncListener___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool SharingManager_RegisterSyncListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_Update___")]
  public static extern void SharingManager_Update(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetPairedConnection___")]
  public static extern global::System.IntPtr SharingManager_GetPairedConnection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetServerConnection___")]
  public static extern global::System.IntPtr SharingManager_GetServerConnection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetSettings___")]
  public static extern global::System.IntPtr SharingManager_GetSettings(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_SetServerConnectionInfo___")]
  public static extern void SharingManager_SetServerConnectionInfo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_GetLocalUser___")]
  public static extern global::System.IntPtr SharingManager_GetLocalUser(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SharingManager_SetUserName___")]
  public static extern void SharingManager_SetUserName(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_SharingManager___")]
  public static extern void delete_SharingManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DirectPairConnector__SWIG_0___")]
  public static extern global::System.IntPtr new_DirectPairConnector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DirectPairConnector__SWIG_1___")]
  public static extern global::System.IntPtr new_DirectPairConnector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DirectPairConnector__SWIG_2___")]
  public static extern global::System.IntPtr new_DirectPairConnector__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_IsReceiver___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool DirectPairConnector_IsReceiver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_GetAddressCount___")]
  public static extern int DirectPairConnector_GetAddressCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_GetAddress___")]
  public static extern global::System.IntPtr DirectPairConnector_GetAddress(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_GetPort___")]
  public static extern ushort DirectPairConnector_GetPort(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_Update___")]
  public static extern void DirectPairConnector_Update(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_IsReadyToConnect___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool DirectPairConnector_IsReadyToConnect(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_SetRemoteAddress___")]
  public static extern void DirectPairConnector_SetRemoteAddress(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_SetRemotePort___")]
  public static extern void DirectPairConnector_SetRemotePort(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_DirectPairConnector___")]
  public static extern void delete_DirectPairConnector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DirectPairReceiver__SWIG_0___")]
  public static extern global::System.IntPtr new_DirectPairReceiver__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DirectPairReceiver__SWIG_1___")]
  public static extern global::System.IntPtr new_DirectPairReceiver__SWIG_1(ushort jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_IsReceiver___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool DirectPairReceiver_IsReceiver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_GetAddressCount___")]
  public static extern int DirectPairReceiver_GetAddressCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_GetAddress___")]
  public static extern global::System.IntPtr DirectPairReceiver_GetAddress(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_GetPort___")]
  public static extern ushort DirectPairReceiver_GetPort(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_Update___")]
  public static extern void DirectPairReceiver_Update(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_IsReadyToConnect___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool DirectPairReceiver_IsReadyToConnect(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_SetIncomingPort___")]
  public static extern void DirectPairReceiver_SetIncomingPort(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_DirectPairReceiver___")]
  public static extern void delete_DirectPairReceiver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_TagImage_GetWidth___")]
  public static extern int TagImage_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_TagImage_GetHeight___")]
  public static extern int TagImage_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_TagImage_CopyImageData___")]
  public static extern void TagImage_CopyImageData(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_TagImage___")]
  public static extern void delete_TagImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairReceiver_Create___")]
  public static extern global::System.IntPtr VisualPairReceiver_Create();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairReceiver_CreateTagImage___")]
  public static extern global::System.IntPtr VisualPairReceiver_CreateTagImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_VisualPairReceiver___")]
  public static extern void delete_VisualPairReceiver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairConnector_Create___")]
  public static extern global::System.IntPtr VisualPairConnector_Create();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairConnector_ProcessImage___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool VisualPairConnector_ProcessImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairConnector_IsProcessingImage___")]
  [return: global::System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
  public static extern bool VisualPairConnector_IsProcessingImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_VisualPairConnector___")]
  public static extern void delete_VisualPairConnector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DiscoveredSystem___")]
  public static extern global::System.IntPtr new_DiscoveredSystem(string jarg1, string jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveredSystem_GetName___")]
  public static extern string DiscoveredSystem_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveredSystem_GetAddress___")]
  public static extern string DiscoveredSystem_GetAddress(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveredSystem_GetRole___")]
  public static extern int DiscoveredSystem_GetRole(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_DiscoveredSystem___")]
  public static extern void delete_DiscoveredSystem(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_DiscoveryClientListener___")]
  public static extern void delete_DiscoveryClientListener(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClientListener_OnRemoteSystemDiscovered___")]
  public static extern void DiscoveryClientListener_OnRemoteSystemDiscovered(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClientListener_OnRemoteSystemDiscoveredSwigExplicitDiscoveryClientListener___")]
  public static extern void DiscoveryClientListener_OnRemoteSystemDiscoveredSwigExplicitDiscoveryClientListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClientListener_OnRemoteSystemLost___")]
  public static extern void DiscoveryClientListener_OnRemoteSystemLost(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClientListener_OnRemoteSystemLostSwigExplicitDiscoveryClientListener___")]
  public static extern void DiscoveryClientListener_OnRemoteSystemLostSwigExplicitDiscoveryClientListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_new_DiscoveryClientListener___")]
  public static extern global::System.IntPtr new_DiscoveryClientListener();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClientListener_director_connect___")]
  public static extern void DiscoveryClientListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, DiscoveryClientListener.SwigDelegateDiscoveryClientListener_0 delegate0, DiscoveryClientListener.SwigDelegateDiscoveryClientListener_1 delegate1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_Create___")]
  public static extern global::System.IntPtr DiscoveryClient_Create();

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_Ping___")]
  public static extern void DiscoveryClient_Ping(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_GetDiscoveredCount___")]
  public static extern uint DiscoveryClient_GetDiscoveredCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_GetDiscoveredSystem___")]
  public static extern global::System.IntPtr DiscoveryClient_GetDiscoveredSystem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_Update___")]
  public static extern void DiscoveryClient_Update(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_AddListener___")]
  public static extern void DiscoveryClient_AddListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClient_RemoveListener___")]
  public static extern void DiscoveryClient_RemoveListener(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_delete_DiscoveryClient___")]
  public static extern void delete_DiscoveryClient(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_NetworkConnectionListener_SWIGUpcast___")]
  public static extern global::System.IntPtr NetworkConnectionListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_BoolElement_SWIGUpcast___")]
  public static extern global::System.IntPtr BoolElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntElement_SWIGUpcast___")]
  public static extern global::System.IntPtr IntElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_LongElement_SWIGUpcast___")]
  public static extern global::System.IntPtr LongElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatElement_SWIGUpcast___")]
  public static extern global::System.IntPtr FloatElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DoubleElement_SWIGUpcast___")]
  public static extern global::System.IntPtr DoubleElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringElement_SWIGUpcast___")]
  public static extern global::System.IntPtr StringElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayListener_SWIGUpcast___")]
  public static extern global::System.IntPtr IntArrayListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_IntArrayElement_SWIGUpcast___")]
  public static extern global::System.IntPtr IntArrayElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayListener_SWIGUpcast___")]
  public static extern global::System.IntPtr FloatArrayListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_FloatArrayElement_SWIGUpcast___")]
  public static extern global::System.IntPtr FloatArrayElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayListener_SWIGUpcast___")]
  public static extern global::System.IntPtr StringArrayListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_StringArrayElement_SWIGUpcast___")]
  public static extern global::System.IntPtr StringArrayElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElementListener_SWIGUpcast___")]
  public static extern global::System.IntPtr ObjectElementListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_ObjectElement_SWIGUpcast___")]
  public static extern global::System.IntPtr ObjectElement_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SyncListener_SWIGUpcast___")]
  public static extern global::System.IntPtr SyncListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionListener_SWIGUpcast___")]
  public static extern global::System.IntPtr SessionListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_SessionManagerListener_SWIGUpcast___")]
  public static extern global::System.IntPtr SessionManagerListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_UserPresenceManagerListener_SWIGUpcast___")]
  public static extern global::System.IntPtr UserPresenceManagerListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_RoomManagerListener_SWIGUpcast___")]
  public static extern global::System.IntPtr RoomManagerListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_PairingListener_SWIGUpcast___")]
  public static extern global::System.IntPtr PairingListener_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairConnector_SWIGUpcast___")]
  public static extern global::System.IntPtr DirectPairConnector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DirectPairReceiver_SWIGUpcast___")]
  public static extern global::System.IntPtr DirectPairReceiver_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairReceiver_SWIGUpcast___")]
  public static extern global::System.IntPtr VisualPairReceiver_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_VisualPairConnector_SWIGUpcast___")]
  public static extern global::System.IntPtr VisualPairConnector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("SharingClient", EntryPoint="CSharp_HoloToolkitfSharing_DiscoveryClientListener_SWIGUpcast___")]
  public static extern global::System.IntPtr DiscoveryClientListener_SWIGUpcast(global::System.IntPtr jarg1);
}

}
