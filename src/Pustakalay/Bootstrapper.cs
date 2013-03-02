using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Pustakalay
{
    class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();  
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        //protected override void ConfigureModuleCatalog()
        //{
            //Type layoutModuleType = typeof(LayoutModule.LayoutModule);
            //ModuleCatalog.AddModule(new ModuleInfo()
            //                            {
            //                                ModuleName = layoutModuleType.Name,
            //                                ModuleType = layoutModuleType.AssemblyQualifiedName,
            //                                InitializationMode = InitializationMode.WhenAvailable
            //                            });
            //Type booksModuleType = typeof(Pustakalay);
            //                            ModuleCatalog.AddModule(new ModuleInfo()
            //                            {
            //                                ModuleName = booksModuleType.Name,
            //                                ModuleType = booksModuleType.AssemblyQualifiedName,
            //                                InitializationMode = InitializationMode.WhenAvailable
            //                            });
            //Type inventoryModuleType = typeof(Inventory.InventoryModule);
            //                            ModuleCatalog.AddModule(new ModuleInfo()
            //                            {
            //                                ModuleName = inventoryModuleType.Name,
            //                                ModuleType = inventoryModuleType.AssemblyQualifiedName,
            //                                InitializationMode = InitializationMode.WhenAvailable
            //                            });

        //}
    }
}
