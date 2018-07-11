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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// By applying the [AudioEvent] attribute to a string field, this 
    /// PropertyDrawer is used instead of a standard string field entry.
    /// </summary>
    [CustomPropertyDrawer(typeof(AudioEventAttribute))]
    public class AudioEventPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Stored list of event names as GUIContent for display
        /// </summary>
        private static GUIContent[] AudioEventNames;

        /// <summary>
        /// For selecting no event
        /// </summary>
        private static readonly string NoEventName = "-- None --";

        /// <summary>
        /// Enable / Disable bank names
        /// </summary>
        private static bool ShowBankNames;

        /// <summary>
        /// Simple case insensitive comparer for GUIContent that contains text
        /// </summary>
        private class EventNameComparer : IComparer<GUIContent>
        {
            public int Compare(GUIContent x, GUIContent y)
            {
                return x.text.ToLower().CompareTo( y.text.ToLower() );
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Right click menu handler to enable / disable bank names in the list
            // Having bank names does not affect the data stored in the property
            if (Event.current.type == EventType.ContextClick)
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Show Banks", "Show bank names in the dropdown"), ShowBankNames, () => ShowBankNames = !ShowBankNames);
                menu.ShowAsContext();
                Event.current.Use();
            }

            GetAllEventNames();

            var currentId = OptionToId(property.stringValue);
            EditorGUI.BeginProperty(position, new GUIContent(property.name), property);
            var newId = EditorGUI.Popup(position, label, currentId, AudioEventNames);

            // Do the necessary modification to property value
            if (newId != currentId)
            {
                if (AudioEventNames[newId].text == NoEventName)
                {
                    property.stringValue = string.Empty;
                }
                else
                {
                    if (ShowBankNames)
                    {
                        // Remove the bank name before storing the string
                        int skip = AudioEventNames[newId].text.IndexOf('/') + 1;
                        property.stringValue = AudioEventNames[newId].text.Substring(skip);
                    }
                    else
                    {
                        property.stringValue = AudioEventNames[newId].text;
                    }
                }
            }

            EditorGUI.EndProperty();
        }

        /// <summary>
        /// Extract all the audio event names from all the audio banks in the project
        /// </summary>
        private static void GetAllEventNames()
        {
            List<GUIContent> eventNames = new List<GUIContent>(200);

            var assets = AssetDatabase.FindAssets("t:AudioEventBank");

            var audioBanks = Resources.FindObjectsOfTypeAll<AudioEventBank>();

            // Check all the banks are loaded and load them if they are not
            if (audioBanks.Length != assets.Length)
            {
                List<AudioEventBank> tmpBanks = new List<AudioEventBank>(assets.Length);
                for(int i=0; i<assets.Length; i++)
                {
                    tmpBanks.Add(AssetDatabase.LoadAssetAtPath<AudioEventBank>(AssetDatabase.GUIDToAssetPath(assets[i])));
                }
                audioBanks = tmpBanks.ToArray();
            }

            for (int bankIndex = 0; bankIndex < audioBanks.Length; bankIndex++)
            {
                var bank = audioBanks[bankIndex];
                for (int eventIndex = 0; eventIndex < bank.Events.Length; eventIndex++)
                {
                    if (ShowBankNames)
                    {
                        // Prepend the bank name to the string, "/" causes a sub-menu to appear
                        // Pro-Tip, place a "/" in your event name to further sub-divide the list of events
                        eventNames.Add(new GUIContent(bank.name + "/" + bank.Events[eventIndex].Name));
                    }
                    else
                    {
                        eventNames.Add(new GUIContent(bank.Events[eventIndex].Name));
                    }
                }
            }

            eventNames.Sort(new EventNameComparer());

            // Make sure the NoEventName is first in the list
            eventNames.Insert(0, new GUIContent(NoEventName));

            AudioEventNames = eventNames.ToArray();
        }

        /// <summary>
        /// Convert a string entry to an option Id
        /// </summary>
        /// <param name="option">Name of string entry to find</param>
        /// <returns>Index in the list, or 0 if not found</returns>
        private static int OptionToId(string option)
        {
            int optionIndex = 0;

            if (AudioEventNames != null)
            {
                for(int i=0; i<AudioEventNames.Length; i++)
                {
                    if (ShowBankNames)
                    {
                        if (AudioEventNames[i].text.EndsWith(option))
                        {
                            optionIndex = i;
                            break;
                        }
                    }
                    else
                    {
                        if (AudioEventNames[i].text == option)
                        {
                            optionIndex = i;
                            break;
                        }
                    }
                }
            }

            return optionIndex;
        }
    }
}