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
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity
{
    // Shows / hides based on enum value of a named member
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class ShowIfEnumValueAttribute : ShowIfAttribute
    {
        public int[] ShowValues { get; private set; }

        // IL2CPP doesn't support attributes with object arguments that are array types
        public ShowIfEnumValueAttribute(string enumVariableName, object enumValue, bool showIfConditionMet = true)
        {
            if (!enumValue.GetType().IsEnum())
                throw new Exception("Value must be of type Enum");

            ShowValues = new int[] { Convert.ToInt32(enumValue) };
            MemberName = enumVariableName;
            ShowIfConditionMet = showIfConditionMet;
        }

        public ShowIfEnumValueAttribute(string enumVariableName, object enumValue1, object enumValue2, bool showIfConditionMet = true)
        {
            if (!enumValue1.GetType().IsEnum() || !enumValue2.GetType().IsEnum())
                throw new Exception("Values must be of type Enum");

            ShowValues = new int[] { Convert.ToInt32(enumValue1), Convert.ToInt32(enumValue2) };
            MemberName = enumVariableName;
            ShowIfConditionMet = showIfConditionMet;
        }

        public ShowIfEnumValueAttribute(string enumVariableName, object enumValue1, object enumValue2, object enumValue3, bool showIfConditionMet = true)
        {
            if (!enumValue1.GetType().IsEnum() || !enumValue2.GetType().IsEnum() || !enumValue3.GetType().IsEnum())
                throw new Exception("Values must be of type Enum");

            ShowValues = new int[] { Convert.ToInt32(enumValue1), Convert.ToInt32(enumValue2), Convert.ToInt32(enumValue3) };
            MemberName = enumVariableName;
            ShowIfConditionMet = showIfConditionMet;
        }

        public ShowIfEnumValueAttribute(string enumVariableName, object enumValue1, object enumValue2, object enumValue3, object enumValue4, bool showIfConditionMet = true)
        {
            if (!enumValue1.GetType().IsEnum() || !enumValue2.GetType().IsEnum() || !enumValue3.GetType().IsEnum() || !enumValue4.GetType().IsEnum())
                throw new Exception("Values must be of type Enum");

            ShowValues = new int[] { Convert.ToInt32(enumValue1), Convert.ToInt32(enumValue2), Convert.ToInt32(enumValue3), Convert.ToInt32(enumValue4) };
            MemberName = enumVariableName;
            ShowIfConditionMet = showIfConditionMet;
        }

#if UNITY_EDITOR
        public override bool ShouldShow(object target)
        {
            bool conditionMet = false;
            int memberValue = Convert.ToInt32(GetMemberValue(target, MemberName));
            for (int i = 0; i < ShowValues.Length; i++)
            {
                if (ShowValues[i] == memberValue)
                {
                    conditionMet = true;
                    break;
                }
            }
            return ShowIfConditionMet ? conditionMet : !conditionMet;
        }
#endif

        private static object GetAsUnderlyingType(Enum enval)
        {
            Type entype = enval.GetType();
            Type undertype = Enum.GetUnderlyingType(entype);
            return Convert.ChangeType(enval, undertype);
        }
    }
}