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

namespace HoloToolkit.Sharing.SyncModel
{
    /// <summary>
    /// Base primitive used to define an element within the data model.
    /// The primitive is defined by a field and a value.
    /// </summary>
    public abstract class SyncPrimitive
    {
        protected string fieldName;
        private XString xStringFieldName;
        protected Element internalElement;

        /// <summary>
        /// Unique identifier for primitive.  Returns kInvalidXGuid if uninitialized.
        /// </summary>
        public long Guid
        {
            get
            {
                return internalElement != null ? internalElement.GetGUID() : SharingClient.kInvalidXGuid;
            }
        }

        /// <summary>
        /// Network Element that represents the sync primitive's value on the server.
        /// </summary>
        public virtual Element NetworkElement
        {
            get { return internalElement; }
            protected set { internalElement = value; }
        }

        /// <summary>
        /// Indicates if the primitive has a network element.
        /// The primitive can only be modified if this returns true.
        /// </summary>
        public bool HasNetworkElement
        {
            get { return internalElement != null; }
        }

        /// <summary>
        /// The field name of the primitive.
        /// </summary>
        public XString XStringFieldName
        {
            get { return xStringFieldName; }
        }

        /// <summary>
        /// The field name of the primitive.
        /// </summary>
        public string FieldName
        {
            get { return fieldName; }

            set
            {
                fieldName = value;
                xStringFieldName = new XString(value);
            }
        }

#if UNITY_EDITOR
        /// <summary>
        /// Returns the raw boxed object this primitive holds.
        /// Used by SharingStageEditor.cs
        /// </summary>
        public abstract object RawValue
        {
            get;
        }
#endif

        /// <summary>
        /// Base Constructor for Sync Primitives.
        /// </summary>
        /// <param name="field">field</param>
        public SyncPrimitive(string field)
        {
            FieldName = field;
        }

        /// <summary>
        /// Initializes this object for local use.  Doesn't wait for network initialization.
        /// </summary>
        /// <param name="parentElement">Object Element Parent</param>
        public abstract void InitializeLocal(ObjectElement parentElement);

        /// <summary>
        /// Called when being remotely initialized.
        /// </summary>
        /// <param name="remoteElement">Remote Element</param>
        public abstract void AddFromRemote(Element remoteElement);

        /// <summary>
        /// Called when the primitive value has changed from a remote action.
        /// </summary>
        /// <param name="remoteValue">Remote Value</param>
        public virtual void UpdateFromRemote(XString remoteValue) { }

        /// <summary>
        /// Called when the primitive value has changed from a remote action.
        /// </summary>
        /// <param name="remoteValue">Remote Value</param>
        public virtual void UpdateFromRemote(float remoteValue) { }

        /// <summary>
        /// Called when the primitive value has changed from a remote action.
        /// </summary>
        /// <param name="remoteValue">Remote Value</param>
        public virtual void UpdateFromRemote(double remoteValue) { }

        /// <summary>
        /// Called when the primitive value has changed from a remote action.
        /// </summary>
        /// <param name="remoteValue">Remote Value</param>
        public virtual void UpdateFromRemote(int remoteValue) { }

        /// <summary>
        /// Called when the primitive value has changed from a remote action.
        /// </summary>
        /// <param name="remoteValue">Remote Value</param>
        public virtual void UpdateFromRemote(long remoteValue) { }

        /// <summary>
        /// Called when the primitive value has changed from a remote action.
        /// </summary>
        /// <param name="remoteValue">Remote Value</param>
        public virtual void UpdateFromRemote(bool remoteValue) { }
    }
}