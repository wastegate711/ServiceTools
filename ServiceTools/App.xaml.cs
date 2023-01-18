using Prism.Ioc;
using Prism.Modularity;
using ServiceTools.Modules.ControlBlock;
using ServiceTools.Views;
using System.Windows;
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
using ServiceTools.Services.SerialPort.Tools;

namespace ServiceTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
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
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ControlBlockModule>();
            moduleCatalog.AddModule<PultBlockModule>();
        }
    }
}
