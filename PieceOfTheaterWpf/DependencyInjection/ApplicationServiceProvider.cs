using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PieceofTheater.Model;
using PieceofTheater.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PieceofTheater.DependencyInjection
{
    internal static class ApplicationServiceProvider
    {
        public static IServiceProvider Instance { get; } = ConfigureDependencyInjection();

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
