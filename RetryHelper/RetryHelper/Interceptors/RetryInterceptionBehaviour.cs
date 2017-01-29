using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace RetryHelper.Interceptors
{
    public class RetryInterceptionBehaviour : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute => true;
    }
}
