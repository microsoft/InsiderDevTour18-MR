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

namespace HoloToolkit.Unity.InputModule
{
    [CustomEditor(typeof(MixedRealityTeleport))]
    public class MixedRealityTeleportEditor : Editor
    {
        private readonly GUIContent verticalRotationLabel = new GUIContent("Vertical Rotation", "Used to check the Horizontal Rotation and the intent of the user to rotate in that direction");

        private static MixedRealityTeleport mixedRealityTeleport;

        private static SerializedProperty teleportMakerPrefab;
        private static SerializedProperty useCustomMappingProperty;

        private static SerializedProperty stayOnTheFloorProperty;
        private static SerializedProperty enableTeleportProperty;
        private static SerializedProperty enableStrafeProperty;
        private static SerializedProperty strafeAmountProperty;
        private static SerializedProperty enableRotationProperty;
        private static SerializedProperty rotationSizeProperty;

        private static SerializedProperty leftThumbstickXProperty;
        private static SerializedProperty leftThumbstickYProperty;
        private static SerializedProperty rightThumbstickXProperty;
        private static SerializedProperty rightThumbstickYProperty;

        private static SerializedProperty horizontalStrafeProperty;
        private static SerializedProperty forwardMovementProperty;
        private static SerializedProperty horizontalRotationProperty;
        private static SerializedProperty verticalRotationProperty;

        private static bool useCustomMapping;
        private static bool mappingOverride;

        private void OnEnable()
        {
            mixedRealityTeleport = (MixedRealityTeleport)target;

            teleportMakerPrefab = serializedObject.FindProperty("teleportMarker");
            useCustomMappingProperty = serializedObject.FindProperty("useCustomMapping");

            enableTeleportProperty = serializedObject.FindProperty("EnableTeleport");
            enableStrafeProperty = serializedObject.FindProperty("EnableStrafe");
            strafeAmountProperty = serializedObject.FindProperty("StrafeAmount");
            enableRotationProperty = serializedObject.FindProperty("EnableRotation");
            rotationSizeProperty = serializedObject.FindProperty("RotationSize");

            stayOnTheFloorProperty = serializedObject.FindProperty("StayOnTheFloor");

            leftThumbstickXProperty = serializedObject.FindProperty("LeftThumbstickX");
            leftThumbstickYProperty = serializedObject.FindProperty("LeftThumbstickY");
            rightThumbstickXProperty = serializedObject.FindProperty("RightThumbstickX");
            rightThumbstickYProperty = serializedObject.FindProperty("RightThumbstickY");

            horizontalStrafeProperty = serializedObject.FindProperty("HorizontalStrafe");
            forwardMovementProperty = serializedObject.FindProperty("ForwardMovement");
            horizontalRotationProperty = serializedObject.FindProperty("HorizontalRotation");
            verticalRotationProperty = serializedObject.FindProperty("VerticalRotation");


        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            useCustomMapping = useCustomMappingProperty.boolValue;

            EditorGUILayout.LabelField("Teleport Options", new GUIStyle("Label") { fontStyle = FontStyle.Bold });

            EditorGUILayout.PropertyField(enableTeleportProperty, new GUIContent("Enable Teleport"));
            EditorGUILayout.PropertyField(enableStrafeProperty, new GUIContent("Enable Strafe"));
            EditorGUILayout.PropertyField(strafeAmountProperty, new GUIContent("Strafe Amount"));

            EditorGUILayout.PropertyField(enableRotationProperty, new GUIContent("Enable Rotation"));
            EditorGUILayout.PropertyField(rotationSizeProperty, new GUIContent("Rotation Amount"));

            EditorGUILayout.PropertyField(stayOnTheFloorProperty, new GUIContent("Stay on the floor"));

            EditorGUILayout.PropertyField(teleportMakerPrefab);


            EditorGUILayout.LabelField("Teleport Controller Mappings", new GUIStyle("Label") { fontStyle = FontStyle.Bold });

            // Use custom mappings if users have already edited their axis mappings
            if (!mappingOverride &&
                (mixedRealityTeleport.LeftThumbstickX != InputMappingAxisUtility.CONTROLLER_LEFT_STICK_HORIZONTAL && mixedRealityTeleport.LeftThumbstickX != string.Empty ||
                 mixedRealityTeleport.LeftThumbstickY != InputMappingAxisUtility.CONTROLLER_LEFT_STICK_VERTICAL && mixedRealityTeleport.LeftThumbstickY != string.Empty ||
                 mixedRealityTeleport.RightThumbstickX != InputMappingAxisUtility.CONTROLLER_RIGHT_STICK_HORIZONTAL && mixedRealityTeleport.RightThumbstickX != string.Empty ||
                 mixedRealityTeleport.RightThumbstickY != InputMappingAxisUtility.CONTROLLER_RIGHT_STICK_VERTICAL && mixedRealityTeleport.RightThumbstickY != string.Empty))
            {
                useCustomMapping = true;
            }

            EditorGUI.BeginChangeCheck();

            useCustomMapping = EditorGUILayout.Toggle("Use Custom Mappings", useCustomMapping);

            if (EditorGUI.EndChangeCheck())
            {
                mappingOverride = !useCustomMapping;
            }

            useCustomMappingProperty.boolValue = useCustomMapping;

            if (useCustomMapping)
            {
                EditorGUILayout.PropertyField(leftThumbstickXProperty, new GUIContent("Horizontal Strafe"));
                EditorGUILayout.PropertyField(leftThumbstickYProperty, new GUIContent("Forward Movement"));
                EditorGUILayout.PropertyField(rightThumbstickXProperty, new GUIContent("Horizontal Rotation"));
                EditorGUILayout.PropertyField(rightThumbstickYProperty, new GUIContent(verticalRotationLabel));
            }
            else
            {
                EditorGUILayout.PropertyField(horizontalStrafeProperty, new GUIContent("Horizontal Strafe"));
                EditorGUILayout.PropertyField(forwardMovementProperty, new GUIContent("Forward Movement"));
                EditorGUILayout.PropertyField(horizontalRotationProperty, new GUIContent("Horizontal Rotation"));
                EditorGUILayout.PropertyField(verticalRotationProperty, new GUIContent("Verizontal Rotation"));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
