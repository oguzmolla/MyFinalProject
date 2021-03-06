using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Intercepters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensice codin yani gönderdiği class IValidator değilse hata göstermek için yazdık 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Activator.CreateInstance new leme anında çalışması demek
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Verilen modelin validatorunu bul 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //buda o bulunan validatorunun argumanlarını bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
