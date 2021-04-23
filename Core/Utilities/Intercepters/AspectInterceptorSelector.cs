using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Intercepters
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //git classın attribute larını oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //git methodun attribute larını oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            // Tüm methodlara loglama yapar
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            //onlarıda sıralarken Priority öncelik sırasına göre oku
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
