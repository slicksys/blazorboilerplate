﻿using System;

namespace SSDCPortal.Infrastructure.Storage.Permissions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PermissionsAttribute : Attribute
    {
        public Actions Actions;

        public PermissionsAttribute(Actions actions)
        {
            Actions = actions;
        }
    }
}
