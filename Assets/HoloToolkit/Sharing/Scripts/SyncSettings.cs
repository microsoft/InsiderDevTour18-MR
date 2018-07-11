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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HoloToolkit.Sharing.SyncModel
{
    /// <summary>
    /// Collection of sharing sync settings, used by the HoloToolkit Sharing sync system
    /// to figure out which data model classes need to be instantiated when receiving
    /// data that inherits from SyncObject.
    /// </summary>
    public class SyncSettings
    {
#if UNITY_WSA && !UNITY_EDITOR
        private readonly Dictionary<TypeInfo, string> dataModelTypeToName = new Dictionary<TypeInfo, string>();
        private readonly Dictionary<string, TypeInfo> dataModelNameToType = new Dictionary<string, TypeInfo>();
#else
        private readonly Dictionary<Type, string> dataModelTypeToName = new Dictionary<Type, string>();
        private readonly Dictionary<string, Type> dataModelNameToType = new Dictionary<string, Type>();
#endif

        private static SyncSettings instance;
        public static SyncSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SyncSettings();
                }
                return instance;
            }
        }

        public string GetDataModelName(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            string retVal;
            dataModelTypeToName.TryGetValue(typeInfo, out retVal);
            return retVal;
        }

#if UNITY_WSA && !UNITY_EDITOR
        public TypeInfo GetDataModelType(string name)
        {
            TypeInfo retVal;
#else
        public Type GetDataModelType(string name)
        {
            Type retVal;
#endif

            dataModelNameToType.TryGetValue(name, out retVal);
            return retVal;
        }

        public void Initialize()
        {
            dataModelNameToType.Clear();
            dataModelTypeToName.Clear();

            foreach (var assembly in GetAssemblies())
            {
                // We currently skip all assemblies except Unity-generated ones
                // This could be modified to be customizable by the user
                if (!assembly.FullName.StartsWith("Assembly-"))
                {
                    continue;
                }

#if UNITY_WSA && !UNITY_EDITOR
                foreach (TypeInfo type in assembly.GetTypes())
#else
                foreach (Type type in assembly.GetTypes())
#endif
                {
                    object customAttribute = type.GetCustomAttributes(typeof(SyncDataClassAttribute), false).FirstOrDefault();
                    SyncDataClassAttribute attribute = customAttribute as SyncDataClassAttribute;

                    if (attribute != null)
                    {
                        string dataModelName = type.Name;

                        // Override the class name if provided
                        if (!string.IsNullOrEmpty(attribute.CustomClassName))
                        {
                            dataModelName = attribute.CustomClassName;
                        }

                        dataModelNameToType.Add(dataModelName, type);
                        dataModelTypeToName.Add(type, dataModelName);
                    }
                }
            }
        }

        private static Assembly[] GetAssemblies()
        {
#if UNITY_WSA && !UNITY_EDITOR
            return new Assembly[]
            {
                typeof(SyncSettings).GetTypeInfo().Assembly
            };
#else
            return AppDomain.CurrentDomain.GetAssemblies();
#endif
        }
    }
}
