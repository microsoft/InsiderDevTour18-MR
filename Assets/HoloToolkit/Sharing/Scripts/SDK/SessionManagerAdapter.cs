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
    /// Allows users of the SessionManager to register to receive event callbacks without
    /// having their classes inherit directly from SessionManagerListener
    /// </summary>
    public class SessionManagerAdapter : SessionManagerListener
    {
        public event System.Action<Session> CreateSucceededEvent;
        public event System.Action<XString> CreateFailedEvent;
        public event System.Action<Session> SessionAddedEvent;
        public event System.Action<Session> SessionClosedEvent;
        public event System.Action<Session, User> UserJoinedSessionEvent;
        public event System.Action<Session, User> UserLeftSessionEvent;
        public event System.Action<Session, User> UserChangedEvent;
        public event System.Action ServerConnectedEvent;
        public event System.Action ServerDisconnectedEvent;

        public SessionManagerAdapter() { }

        public override void OnCreateSucceeded(Session newSession)
        {
            Profile.BeginRange("OnCreateSucceeded");
            if (this.CreateSucceededEvent != null)
            {
                this.CreateSucceededEvent(newSession);
            }
            Profile.EndRange();
        }

        public override void OnCreateFailed(XString reason)
        {
            Profile.BeginRange("OnCreateFailed");
            if (this.CreateFailedEvent != null)
            {
                this.CreateFailedEvent(reason);
            }
            Profile.EndRange();
        }

        public override void OnSessionAdded(Session newSession)
        {
            Profile.BeginRange("OnSessionAdded");
            if (this.SessionAddedEvent != null)
            {
                this.SessionAddedEvent(newSession);
            }
            Profile.EndRange();
        }

        public override void OnSessionClosed(Session session)
        {
            Profile.BeginRange("OnSessionClosed");
            if (this.SessionClosedEvent != null)
            {
                this.SessionClosedEvent(session);
            }
            Profile.EndRange();
        }

        public override void OnUserJoinedSession(Session session, User newUser)
        {
            Profile.BeginRange("OnUserJoinedSession");
            if (this.UserJoinedSessionEvent != null)
            {
                this.UserJoinedSessionEvent(session, newUser);
            }
            Profile.EndRange();
        }

        public override void OnUserLeftSession(Session session, User user)
        {
            Profile.BeginRange("OnUserLeftSession");
            if (this.UserLeftSessionEvent != null)
            {
                this.UserLeftSessionEvent(session, user);
            }
            Profile.EndRange();
        }

        public override void OnUserChanged(Session session, User user)
        {
            Profile.BeginRange("OnUserChanged");
            if (this.UserChangedEvent != null)
            {
                this.UserChangedEvent(session, user);
            }
            Profile.EndRange();
        }

        public override void OnServerConnected()
        {
            Profile.BeginRange("OnServerConnected");
            if (this.ServerConnectedEvent != null)
            {
                this.ServerConnectedEvent();
            }
            Profile.EndRange();
        }

        public override void OnServerDisconnected()
        {
            Profile.BeginRange("OnServerDisconnected");
            if (this.ServerDisconnectedEvent != null)
            {
                this.ServerDisconnectedEvent();
            }
            Profile.EndRange();
        }
    }
}