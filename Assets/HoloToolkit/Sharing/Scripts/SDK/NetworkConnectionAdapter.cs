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

namespace HoloToolkit.Sharing
{
    /// <summary>
    /// Allows users of NetworkConnection to register to receive event callbacks without
    /// having their classes inherit directly from NetworkConnectionListener
    /// </summary>
    public class NetworkConnectionAdapter : NetworkConnectionListener
    {
        public event System.Action<NetworkConnection> ConnectedCallback;
        public event System.Action<NetworkConnection> ConnectionFailedCallback;
        public event System.Action<NetworkConnection> DisconnectedCallback;
        public event System.Action<NetworkConnection, NetworkInMessage> MessageReceivedCallback;

        public NetworkConnectionAdapter() { }

        public override void OnConnected(NetworkConnection connection)
        {
            Profile.BeginRange("OnConnected");
            if (this.ConnectedCallback != null)
            {
                this.ConnectedCallback(connection);
            }
            Profile.EndRange();
        }

        public override void OnConnectFailed(NetworkConnection connection)
        {
            Profile.BeginRange("OnConnectFailed");
            if (this.ConnectionFailedCallback != null)
            {
                this.ConnectionFailedCallback(connection);
            }
            Profile.EndRange();
        }

        public override void OnDisconnected(NetworkConnection connection)
        {
            Profile.BeginRange("OnDisconnected");
            if (this.DisconnectedCallback != null)
            {
                this.DisconnectedCallback(connection);
            }
            Profile.EndRange();
        }

        public override void OnMessageReceived(NetworkConnection connection, NetworkInMessage message)
        {
            Profile.BeginRange("OnMessageReceived");
            if (this.MessageReceivedCallback != null)
            {
                this.MessageReceivedCallback(connection, message);
            }
            Profile.EndRange();
        }
    }
}