/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:KanbanApplicationMVVM"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using KanbanApplicationMVVM.Model;
using KanbanApplicationMVVM.Service;
using Microsoft.Practices.ServiceLocation;

namespace KanbanApplicationMVVM.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private BoardViewModel boardViewModel;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                //SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<DatabaseContext>();
                SimpleIoc.Default.Register<IBoardRepository, BoardRepository>();
                SimpleIoc.Default.Register<IApplicationContext, ApplicationContext>();
                SimpleIoc.Default.Register<IProjectsRepository, ProjectsRepository>();
                SimpleIoc.Default.Register<ViewModelLocator>(() => this);
                SimpleIoc.Default.Register<StartViewModel>();
                //SimpleIoc.Default.Register<BoardViewModel>();

                 this.ApplicationContext.ActiveViewModel = this.StartViewModel;
            }
        }

        public StartViewModel StartViewModel
        {
            get { return ServiceLocator.Current.GetInstance<StartViewModel>(); }
        }

        public BoardViewModel BoardViewModel
        {
            get { return this.boardViewModel; }
            set { this.boardViewModel = value; }
        }

        public BoardColumnViewModel BoardColumnViewModel
        {
            get { return ServiceLocator.Current.GetInstance<BoardColumnViewModel>(); }
        }

        public IApplicationContext ApplicationContext
        {
            get { return ServiceLocator.Current.GetInstance<IApplicationContext>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}