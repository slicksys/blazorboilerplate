using AspectInjector.Broker;
using System;

namespace SSDCPortal.Server.Aop
{
    [Injection(typeof(LogExceptionAspect))]
    public class LogExceptionAttribute : Attribute
    {
    }
}
