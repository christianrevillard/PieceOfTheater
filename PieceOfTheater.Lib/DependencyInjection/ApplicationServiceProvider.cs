using Microsoft.Extensions.DependencyInjection;
using PieceofTheater.Lib.Model;
using PieceofTheater.Lib.ViewModels;
using System;
using PieceOfTheater.Lib.MVVM;

namespace PieceofTheater.Lib.DependencyInjection
{
    public static class ApplicationServiceProvider
    {
        public static IServiceProvider Instance { get; } = ConfigureDependencyInjection();

        public static IServiceProvider ConfigureDependencyInjection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IPlayModel, Play>();
            serviceCollection.AddSingleton<IMediator, Mediator>();

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
