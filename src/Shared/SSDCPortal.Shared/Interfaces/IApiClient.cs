﻿using SSDCPortal.Shared.Dto;
using SSDCPortal.Shared.Dto.Db;
using SSDCPortal.Shared.Dto.Email;
using Breeze.Sharp;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SSDCPortal.Shared.Interfaces
{
    public interface IApiClient : IBaseApiClient
    {
        Task<UserProfile> GetUserProfile();

        Task<QueryResult<TenantSetting>> GetTenantSettings();
        Task<QueryResult<ApplicationUser>> GetUsers(Expression<Func<ApplicationUser, bool>> predicate = null, int? take = null, int? skip = null);
        Task<QueryResult<ApplicationRole>> GetRoles(Expression<Func<ApplicationRole, bool>> predicate = null, int? take = null, int? skip = null);

        Task<QueryResult<DbLog>> GetLogs(Expression<Func<DbLog, bool>> predicate = null, int? take = null, int? skip = null);
        Task<QueryResult<ApiLogItem>> GetApiLogs(Expression<Func<ApiLogItem, bool>> predicate = null, int? take = null, int? skip = null);

        Task<QueryResult<Todo>> GetToDos();

        Task<ApiResponseDto> SendTestEmail(EmailDto email);
    }
}
