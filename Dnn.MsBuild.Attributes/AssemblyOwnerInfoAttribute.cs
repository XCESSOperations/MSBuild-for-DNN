﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyOwnerInfoAttribute.cs" company="XCESS expertise center bv">
//   Copyright (c) 2016 XCESS expertise center bv
//   
//   The software is owned by XCESS and is protected by 
//   the Dutch copyright laws and international treaty provisions.
//   You are allowed to make copies of the software solely for backup or archival purposes.
//   You may not lease, rent, export or sublicense the software.
//   You may not reverse engineer, decompile, disassemble or create derivative works from the software.
//   
//   Owned by XCESS expertise center b.v., Storkstraat 19, 3833 LB Leusden, The Netherlands
//   T. +31-33-4335151, E. info@xcess.nl, I. http://www.xcess.nl
// </copyright>
// <summary>
//   
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;

// ReSharper disable once CheckNamespace
namespace DotNetNuke.Services.Installer.MsBuild
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyOwnerInfoAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyOwnerInfoAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="url">The URL.</param>
        public AssemblyOwnerInfoAttribute(string name, string emailAddress, string url)
        {
            this.EmailAddress = emailAddress;
            this.Name = name;
            this.Url = url;
        }

        #endregion

        /// <summary>
        /// Gets the owner email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; }

        /// <summary>
        /// Gets the owner name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the owner (usually the company) URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; }
    }
}