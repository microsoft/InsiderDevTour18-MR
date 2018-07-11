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

using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class UAudioManagerBaseEditor<TEvent, TBank> : Editor where TEvent : AudioEvent, new() where TBank : AudioBank<TEvent>, new()
    {
        protected UAudioManagerBase<TEvent, TBank> MyTarget;

        public void DrawExportToAsset()
        { 
            // Don't show this if there are no embedded events in this audio manager
            if (MyTarget.EditorEvents == null || MyTarget.EditorEvents.Length == 0)
                return;

            EditorGUILayout.HelpBox("Audio events have moved to an asset system.\nThey are no longer stored in the scene.\nPlease export these events to an event bank.", MessageType.Info, true);

            if (GUILayout.Button("Convert To Bank"))
            {
                TBank bank = ScriptableObject.CreateInstance<TBank>();

                bank.Events = MyTarget.EditorEvents;

                // Create the Asset
                AssetDatabase.CreateAsset(bank, "Assets/ConvertedAudioBank.asset");
                AssetDatabase.SaveAssets();

                // Remove the events from the manager
                this.serializedObject.Update();
                var eventsProperty = this.serializedObject.FindProperty("Events");
                eventsProperty.ClearArray();

                // Add the Asset to the Default Banks
                var defaultBanksProperty = this.serializedObject.FindProperty("DefaultBanks");
                defaultBanksProperty.InsertArrayElementAtIndex(defaultBanksProperty.arraySize);
                var newEntry = defaultBanksProperty.FindPropertyRelative("Array.data[" + (defaultBanksProperty.arraySize - 1) + "]");
                newEntry.objectReferenceValue = bank;

                this.serializedObject.ApplyModifiedProperties();
            }
        }

        public void DrawBankList()
        {
            this.serializedObject.Update();
            var bankList = this.serializedObject.FindProperty("DefaultBanks");

            EditorGUILayout.PropertyField(bankList, true);

            this.serializedObject.ApplyModifiedProperties();
        }

        protected void SetUpEditor()
        {
            if (MyTarget.DefaultBanks == null)
            {
                MyTarget.DefaultBanks = new TBank[0];
            }
        }

    }
}