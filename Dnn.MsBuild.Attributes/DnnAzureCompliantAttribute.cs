﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DnnAzureCompliantAttribute.cs" company="XCESS expertise center b.v.">
//     Copyright (c) 2016-2016 XCESS expertise center b.v.
// 
//     Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//     documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
//     the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
//     to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
//     The above copyright notice and this permission notice shall be included in all copies or substantial portions 
//     of the Software.
// 
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//     TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
//     THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
//     CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
//     DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

// ReSharper disable once CheckNamespace

namespace DotNetNuke.Services.Installer.MsBuild
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class DnnAzureCompliantAttribute : DnnManifestAttribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DnnAzureCompliantAttribute"/> class.
        /// </summary>
        /// <param name="isCompliant">if set to <c>true</c> [is compliant].</param>
        public DnnAzureCompliantAttribute(bool isCompliant)
        {
            this.IsCompliant = isCompliant;
        }

        #endregion

        /// <summary>
        /// Gets a value indicating whether this instance is compliant.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is compliant; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompliant { get; private set; }
    }
}