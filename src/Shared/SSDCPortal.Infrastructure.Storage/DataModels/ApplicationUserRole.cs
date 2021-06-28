using SSDCPortal.Infrastructure.Storage.Permissions;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Identity;
using System;

namespace SSDCPortal.Infrastructure.Storage.DataModels
{
    [MultiTenant]
    [Permissions(Actions.CRUD)]
    public partial class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
