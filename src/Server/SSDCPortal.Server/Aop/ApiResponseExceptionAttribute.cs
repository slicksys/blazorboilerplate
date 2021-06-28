using AspectInjector.Broker;
using System;

namespace SSDCPortal.Server.Aop
{
    [Injection(typeof(ApiResponseExceptionAspect))]
    public class ApiResponseExceptionAttribute : Attribute
    {
    }
}
