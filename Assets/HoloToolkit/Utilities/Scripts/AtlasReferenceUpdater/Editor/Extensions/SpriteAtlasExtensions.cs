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
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

namespace HoloToolkit.Unity
{
    public static class SpriteAtlasExtensions
    {
#if UNITY_2017_1_OR_NEWER
        public const string SpritePackables = "m_EditorData.packables";

        public static void SetSprites(this SpriteAtlas spriteAtlas, IList<Sprite> sprites)
        {
            var serializedObject = new SerializedObject(spriteAtlas);
            var packables = serializedObject.FindProperty(SpritePackables);
            packables.SetObjects(sprites);
            serializedObject.ApplyModifiedProperties();
        }

        public static bool ContainsSprite(this SpriteAtlas spriteAtlas, Sprite sprite)
        {
            var serializedObject = new SerializedObject(spriteAtlas);
            var packables = serializedObject.FindProperty(SpritePackables);
            for (var i = 0; i < packables.arraySize; i++)
            {
                var containedSprite = packables.GetArrayElementAtIndex(i).objectReferenceValue as Sprite;
                if (sprite != containedSprite) { continue; }
                return true;
            }
            return false;
        }
#endif // UNITY_2017_1_OR_NEWER
    }
}
