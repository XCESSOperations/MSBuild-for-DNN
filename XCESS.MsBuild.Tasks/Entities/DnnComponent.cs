﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DnnComponent.cs" company="XCESS expertise center b.v.">
//   Copyright (c) 2014 XCESS expertise center b.v. 
//   
//   The software is owned by XCESS expertise center b.v. and is protected by 
//   the Dutch copyright laws and international treaty provisions. 
//   You are allowed to make copies of the software solely for backup or archival purposes. 
//   You may not lease, rent, export or sublicense the software. 
//   You may not reverse engineer, decompile, disassemble or create derivative works from the software.
//   
//   XCESS expertise center b.v., Storkstraat 19, 3833 LB Leusden, The Netherlands
//   T. +31-33-4335151, I. http://www.xcess.nl
// </copyright>
// <summary>
//   Defines the DnnComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XCESS.MsBuild.Tasks.Entities
{
    using System.Xml.Serialization;
    using XCESS.MsBuild.Attributes;

    /// <summary>
    /// </summary>
    [XmlInclude(typeof(DnnComponentModule))]
    [XmlInclude(typeof(DnnComponentScript))]
    [XmlRoot("component")]
    public abstract class DnnComponent
    {
        /// <summary>
        /// Gets or sets the type of the component.
        /// </summary>
        /// <value>
        /// The type of the component.
        /// </value>
        [XmlAttribute("type")]
        public abstract DnnComponentType ComponentType { get; set; }
    }
}
