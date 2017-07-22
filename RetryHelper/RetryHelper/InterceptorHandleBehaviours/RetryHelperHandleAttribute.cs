using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace RetryHelper.InterceptorHandleBehaviours
{
    public class RetryHelperHandleAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new Helpers.RetryHelper();
        }
    }
}
