using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModel
    {
        //Startup taki IServiceCollection sları buradan vericez 
        void Load(IServiceCollection serviceCollection);

    }
}
