using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PieceOfTheater.Model;
using PieceOfTheater.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceOfTheater.DependencyInjection
{
    internal static class ApplicationServiceProvider
    {
        public static IServiceProvider ConfigureDependencyInjection()
        {
            var serviceCollection = new ServiceCollection();

            // add the actual stuff.
            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();
            serviceCollection.AddSingleton<IPlayModel, Play>();

            return serviceCollection.BuildServiceProvider();
        }

    }
}
