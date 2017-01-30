using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using RetryHelper.Helpers;
using RetryHelper.Interceptors;

namespace RetryHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRetryHelper, Helpers.RetryHelper>();

            container.AddNewExtension<Interception>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<RetryInterceptionBehaviour>());
        }
    }
}
