using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using IR.Quote.Data.Repositories;
using IR.Quote.Navigation;
using IR.Quote.PageModels;
using Xamarin.Forms;

namespace IR.Quote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ConfigureIOC();

            SetupNavContainers();
        }

        protected void SetupNavContainers()
        {
            var loginPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
            var loginNavContainer = new FreshNavigationContainer(loginPage, NavigationStacks.LoginStack);

            var tabbedNavigation = new FreshTabbedNavigationContainer(NavigationStacks.MainAppStack);
            tabbedNavigation.AddTab<EquipmentCategoriesPageModel>("Equipment", null, null);
            tabbedNavigation.AddTab<ContactsPageModel>("Contacts", null, null);
            tabbedNavigation.AddTab<QuotesPageModel>("Quotes", null, null);
            tabbedNavigation.AddTab<FavoritesPageModel>("Favorites", null, null);

            MainPage = loginNavContainer;
        }

        protected void ConfigureIOC()
        {
            FreshIOC.Container.Register<IQuoteRepository, QuoteRepository>().AsSingleton();
            // Add any other repositories here
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
