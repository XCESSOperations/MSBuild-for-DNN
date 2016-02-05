﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleComponentBuilder.cs" company="XCESS expertise center bv">
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

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dnn.MsBuild.Tasks.Components;
using Dnn.MsBuild.Tasks.Entities;
using Dnn.MsBuild.Tasks.Extensions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Installer.MsBuild;

namespace Dnn.MsBuild.Tasks.Composition
{
    internal class ModuleComponentBuilder : IBuilder
    {
        #region Implementation of IBuilder

        public IManifestElement Build(IManifestData data)
        {
            var component = new DnnComponentModule
                            {
                                // Only a single DesktopModule per module component
                                DesktopModule = this.GetOrCreateDesktopModule(data)
                            };

            component.DesktopModule.ModuleDefinitions.AddRange(this.GetModuleDefinitions(data));
           
            return component;
        }

        #endregion

        private DnnDesktopModule GetOrCreateDesktopModule(IManifestData data)
        {
            var desktopModule = new DnnDesktopModule();

            // Only a single desktop module is allowed per package.
            var desktopModuleAttribute = data.ExportedTypes.GetCustomAttribute<DnnDesktopModuleAttribute>();
            desktopModule.FolderName = desktopModule.FolderName
                                                    .FirstNotEmpty(desktopModuleAttribute?.FolderName, data.Package?.Folder);
            desktopModule.ModuleName = desktopModule.ModuleName
                                                    .FirstNotEmpty(desktopModuleAttribute?.ModuleName, data.Package?.Name);

            if (desktopModuleAttribute != null)
            {
                desktopModule.IsAdmin = desktopModuleAttribute.IsAdmin;
                desktopModule.IsPremium = desktopModuleAttribute.IsPremium;
            }

            var type = data.ExportedTypes.FirstOrDefault(arg => arg.HasAttribute<DnnBusinessControllerAttribute>());
            // ReSharper disable once InvertIf
            if (type != null)
            {
                var assemblyName = type.Assembly.GetName();
                desktopModule.BusinessControllerClass = $"{type.FullName}, {assemblyName.Name}";

                var supportedInterfaces = type.GetInterfaces();
                desktopModule.AssignSupportedFeature<IPortable>(supportedInterfaces, DnnSupportedFeatureType.Portable);
                desktopModule.AssignSupportedFeature<ISearchable>(supportedInterfaces, DnnSupportedFeatureType.Searchable);
                desktopModule.AssignSupportedFeature<IUpgradeable>(supportedInterfaces, DnnSupportedFeatureType.Upgradeable);
            }

            return desktopModule;
        }

        private IEnumerable<DnnModuleDefinition> GetModuleDefinitions(IManifestData data)
        {
            var moduleDefinitions = new Dictionary<string, DnnModuleDefinition>();

            var moduleControlTypes = data.ExportedTypes.Where(arg => arg.HasAttribute<DnnModuleControlAttribute>());
            moduleControlTypes.ForEach(arg =>
                                       {
                                           var moduleControlAttribtute = arg.GetCustomAttribute<DnnModuleControlAttribute>();

                                           // Add the module definition for the module control, if it does not already exist.
                                           var moduleDefinitionName = moduleControlAttribtute.ModuleDefinition ?? DnnModuleDefinition.DefaultModuleDefinitionName;
                                           if (!moduleDefinitions.ContainsKey(moduleDefinitionName))
                                           {
                                               moduleDefinitions.Add(moduleDefinitionName, new DnnModuleDefinition(moduleDefinitionName));
                                           }

                                           var moduleDefinition = moduleDefinitions[moduleDefinitionName];

                                           var userControlFilePath = string.Empty;
                                           var moduleControl = DnnModuleControl.CreateFromAttribute(moduleControlAttribtute, data.UserControls.TryGetValue(arg.FullName, out userControlFilePath) ? userControlFilePath : arg.FullName);
                                           moduleDefinition.ModuleControls.Add(moduleControl);

                                           var permissionAttribute = arg.GetCustomAttribute<DnnModulePermissionAttribute>();
                                           if (permissionAttribute != null)
                                           {
                                               // Create and add the permission.
                                               moduleDefinition.Permissions.Add(DnnModulePermission.CreateFromAttribute(permissionAttribute));
                                           }
                                       });

            return moduleDefinitions.Values;
        }
    }
}