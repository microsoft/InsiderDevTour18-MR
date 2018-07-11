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

using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Hardware;
using UnityEngine;

namespace HoloToolkit.Unity
{
    [InitializeOnLoad]
    public class USBDeviceListener
    {
        [SerializeField]
        public static USBDeviceInfo[] USBDevices;

        public delegate void OnUsbDevicesChanged(UsbDevice[] usbDevices);

        public static event OnUsbDevicesChanged UsbDevicesChanged;

        private static List<USBDeviceInfo> usbDevicesList = new List<USBDeviceInfo>(0);

        static USBDeviceListener()
        {
            Usb.DevicesChanged += NotifyUsbDevicesChanged;
        }

        private static void NotifyUsbDevicesChanged(UsbDevice[] devices)
        {
            if (UsbDevicesChanged != null)
            {
                UsbDevicesChanged.Invoke(devices);
            }

            usbDevicesList.Clear();

            foreach (UsbDevice device in devices)
            {
                usbDevicesList.Add(new USBDeviceInfo(device.vendorId, device.udid, device.productId, device.name, device.revision));
            }

            USBDevices = usbDevicesList.ToArray();
        }
    }
}