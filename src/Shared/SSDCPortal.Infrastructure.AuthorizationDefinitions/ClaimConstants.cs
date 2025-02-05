﻿namespace SSDCPortal.Infrastructure.AuthorizationDefinitions
{
    public static class ApplicationClaimTypes
    {
        ///<summary>A claim that specifies the permission of an entity</summary>
        public const string Permission = "permission";
    }

    public static class ClaimValues
    {
        public static string trueString = "true";
        public static string falseString = "false";
    }
}