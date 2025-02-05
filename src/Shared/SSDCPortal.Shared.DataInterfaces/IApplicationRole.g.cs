//Autogenerated by SSDCPortal.EntityGenerator
using SSDCPortal.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SSDCPortal.Shared.DataInterfaces
{
    public interface IApplicationRole
    {
        string TenantId { get; set; }

        ICollection<IApplicationUserRole> UserRoles { get; }

        Guid Id { get; set; }

        String Name { get; set; }

        String NormalizedName { get; set; }

        String ConcurrencyStamp { get; set; }

    }
}
