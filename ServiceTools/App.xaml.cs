using Prism.Ioc;
using Prism.Modularity;
using ServiceTools.Modules.ControlBlock;
using ServiceTools.Views;
using System.Windows;
using DryIoc;
using Prism.Regions;
using ServiceTools.Modules.PultBlock;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.SerialPort.Services;
using SerialPortService.Abstractions;
using SerialPortService.Services;
using ServiceTools.Core.Extensions;
using ServiceTools.Services.Serial_Port;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.Pult;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Services.Pult.Interfaces;
using ServiceTools.Services.Serial_Port.Interfaces;
using ServiceTools.Models;
using ServiceTools.Modules.PultBlock.Views;
using ServiceTools.Services.SerialPort.Tools;
using ServiceTools.ViewModels;
using Prism.Mvvm;

namespace ServiceTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static IContainerProvider ContainerIoC { get; private set; }

        protected override Window CreateShell()
        {
            var moduleManager = Container.Resolve<IModuleManager>();
            moduleManager.LoadModule("ViewPult");
            moduleManager.LoadModule("ViewA");
            MainWindow mainWindow =Container.Resolve<MainWindow>();
           // mainWindow.DataContext = Container.Resolve(typeof(MainWindowViewModel));
            ContainerIoC = Container;

            return mainWindow;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<GlobalSettings>();
            containerRegistry.RegisterSingleton<IMessageQueue, MessageQueue>();
            containerRegistry.RegisterSingleton<ISerialPortService, Serial_Port>();
            containerRegistry.RegisterSingleton<IPortManager, PortManager>();
            containerRegistry.RegisterSingleton<IReceivedData, ReceivedData>();
            containerRegistry.RegisterSingleton<ViewPultViewModel>();
            containerRegistry.Register<IResponseSortingPult, ResponseSortingPult>();
            containerRegistry.RegisterSingleton<ViewAViewModel>();//TODO - Переименовать
            containerRegistry.RegisterSingleton<Pult>();
            containerRegistry.RegisterSingleton<ControlBlock>();
            containerRegistry.Register<IMessageTools, MessageTools>();
            containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.Register<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ControlBlockModule>("ViewA").Initialize();
            moduleCatalog.AddModule<PultBlockModule>("ViewPult").Initialize();
        }

        protected override void ConfigureViewModelLocator()
        {
            //ViewModelLocationProvider.Register<ViewPult, ViewPultViewModel>();
        }
    }
}
