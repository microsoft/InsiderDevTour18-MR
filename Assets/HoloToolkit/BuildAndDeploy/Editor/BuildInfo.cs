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
using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class BuildInfo
    {
        public string OutputDirectory { get; set; }

        public IEnumerable<string> Scenes { get; set; }

        public IEnumerable<CopyDirectoryInfo> CopyDirectories { get; set; }

        public Action<BuildInfo> PreBuildAction { get; set; }

        public Action<BuildInfo, string> PostBuildAction { get; set; }

        public BuildOptions BuildOptions { get; set; }

        public BuildTarget BuildTarget { get; set; }

        public WSASDK? WSASdk { get; set; }

        public string WSAUwpSdk { get; set; }

        public WSAUWPBuildType? WSAUWPBuildType { get; set; }

        public bool? WSAGenerateReferenceProjects { get; set; }

        public ColorSpace? ColorSpace { get; set; }

        public bool IsCommandLine { get; set; }

        public string BuildSymbols { get; private set; }

        public BuildInfo()
        {
            BuildSymbols = string.Empty;
        }

        public void AppendSymbols(params string[] symbol)
        {
            AppendSymbols((IEnumerable<string>)symbol);
        }

        public void AppendSymbols(IEnumerable<string> symbols)
        {
            string[] toAdd = symbols.Except(BuildSymbols.Split(';'))
                                    .Where(sym => !string.IsNullOrEmpty(sym)).ToArray();

            if (!toAdd.Any())
            {
                return;
            }

            if (!string.IsNullOrEmpty(BuildSymbols))
            {
                BuildSymbols += ";";
            }

            BuildSymbols += string.Join(";", toAdd);
        }

        public bool HasAnySymbols(params string[] symbols)
        {
            return BuildSymbols.Split(';').Intersect(symbols).Any();
        }

        public bool HasConfigurationSymbol()
        {
            return HasAnySymbols(
                BuildSLNUtilities.BuildSymbolDebug,
                BuildSLNUtilities.BuildSymbolRelease,
                BuildSLNUtilities.BuildSymbolMaster);
        }

        public static IEnumerable<string> RemoveConfigurationSymbols(string symbols)
        {
            return symbols.Split(';').Except(new[]
            {
                BuildSLNUtilities.BuildSymbolDebug,
                BuildSLNUtilities.BuildSymbolRelease,
                BuildSLNUtilities.BuildSymbolMaster
            });
        }

        public bool HasAnySymbols(IEnumerable<string> symbols)
        {
            return BuildSymbols.Split(';').Intersect(symbols).Any();
        }
    }
}