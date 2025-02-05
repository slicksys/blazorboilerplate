﻿using SSDCPortal.Infrastructure.Storage.Permissions;
using SSDCPortal.Infrastructure.Storage.DataInterfaces;
using System.ComponentModel.DataAnnotations;

namespace SSDCPortal.Infrastructure.Storage.DataModels
{
    [Permissions(Actions.Delete)]
    public partial class Todo : IAuditable, ISoftDelete
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [MaxLength(128)]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}