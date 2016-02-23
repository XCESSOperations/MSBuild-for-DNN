﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DnnComponentResourceFiles.cs" company="XCESS expertise center b.v.">
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

using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Dnn.MsBuild.Tasks.Entities.FileTypes;

namespace Dnn.MsBuild.Tasks.Entities
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// http://www.dnnsoftware.com/wiki/manifest-resourcefile-component
    /// </remarks>
    public class DnnComponentResourceFiles
    {
        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="DnnComponentResourceFiles"/> class from being created.
        /// </summary>
        private DnnComponentResourceFiles()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DnnComponentResourceFiles"/> class.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        /// <param name="resourceFiles">The resource files.</param>
        internal DnnComponentResourceFiles(string basePath, IEnumerable<ResourceFileInfo> resourceFiles)
        {
            this.BasePath = basePath;
            this.ResourceFiles = resourceFiles.ToList();
        }

        #endregion

        /// <summary>
        /// Gets or sets the base path.
        /// </summary>
        /// <value>
        /// The base path.
        /// </value>
        [XmlElement("basePath")]
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets the resource files.
        /// </summary>
        /// <value>
        /// The resource files.
        /// </value>
        [XmlElement("resourceFile")]
        public List<ResourceFileInfo> ResourceFiles { get; set; }
    }
}