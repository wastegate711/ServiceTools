using ServiceTools.Modules.ControlBlock;
using ServiceTools.Views;
using ServiceTools.Modules.PultBlock;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.SerialPort.Services;
using ServiceTools.Services.Serial_Port;
using ServiceTools.Services.Pult;
using ServiceTools.Services.Pult.Interfaces;
using ServiceTools.Services.Serial_Port.Interfaces;
using ServiceTools.Models;
using ServiceTools.Services.SerialPort.Tools;
using ServiceTools.ViewModels;
using System;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using SerialPortService.Abstractions;
using SerialPortService.Services;
using ServiceTools.Core.Extensions;

namespace ServiceTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var moduleManager = Container.Resolve<IModuleManager>();
            moduleManager.LoadModule("ViewPult");
            moduleManager.LoadModule("ViewControlBlock");
            MainWindow mainWindow =Container.Resolve<MainWindow>();

           return mainWindow;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<GlobalSettings>();
            containerRegistry.RegisterSingleton<IMessageQueue, MessageQueue>();
            containerRegistry.RegisterSingleton<ISerialPortService, Serial_Port>();
            containerRegistry.RegisterSingleton<IPortManager, PortManager>();
            containerRegistry.RegisterSingleton<IReceivedData, ReceivedData>();
            containerRegistry.Register<IResponseSortingPult, ResponseSortingPult>();
            containerRegistry.RegisterSingleton<ControlBlock>();
            containerRegistry.Register<IMessageTools, MessageTools>();
            containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.Register<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ControlBlockModule>("ViewControlBlock").Initialize();
            moduleCatalog.AddModule<PultBlockModule>("ViewPult").Initialize();
        }

        protected override void ConfigureViewModelLocator()
        {
            //ViewModelLocationProvider.Register<ViewPult, ViewPultViewModel>();
        }
    }
}
