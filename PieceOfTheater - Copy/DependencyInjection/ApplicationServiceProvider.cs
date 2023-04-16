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

            serviceCollection.AddSingleton<IPlayModel, Play>();

            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();

            serviceCollection.AddTransient<IPlayTextViewModel, PlayTextViewModel>();
            serviceCollection.AddTransient<IActsAndScenesViewModel, ActsAndScenesViewModel>();
            serviceCollection.AddTransient<ICharactersViewModel, CharactersViewModel>();
            serviceCollection.AddTransient<IScenesViewModel, ScenesViewModel>();
            serviceCollection.AddTransient<ITableViewModel, TableViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
