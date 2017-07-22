// https://msdn.microsoft.com/en-us/library/dn178466(v=pandp.30).aspx
// http://unity.codeplex.com/discussions/400636#post931911

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using RetryHelper.Helpers;

namespace RetryHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRetryHelper, Helpers.RetryHelper>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());
        }
    }
}
