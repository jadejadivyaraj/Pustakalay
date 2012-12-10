using System;
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


        protected override void ConfigureModuleCatalog()
        {
            Type LayoutModuleType = typeof(LayoutModule.LayoutModule);
            ModuleCatalog.AddModule(new ModuleInfo()
                                        {
                                            ModuleName = LayoutModuleType.Name,
                                            ModuleType = LayoutModuleType.AssemblyQualifiedName,
                                            InitializationMode = InitializationMode.WhenAvailable
                                        });
            Type moduleAType = typeof(BooksModule.BooksModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleAType.Name,
                ModuleType = moduleAType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }
    }
}
