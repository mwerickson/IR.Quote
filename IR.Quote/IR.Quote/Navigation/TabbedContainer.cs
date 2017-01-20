using FreshMvvm;
using Xamarin.Forms;

namespace IR.Quote.Navigation
{
    public class TabbedContainer : FreshTabbedNavigationContainer
    {
        public TabbedContainer(string navigationName) : base(navigationName)
        {
            
        }

        protected override Page CreateContainerPage(Page page)
        {
            if (page is NavigationPage || page is MasterDetailPage || page is TabbedPage)
                return page;

            return base.CreateContainerPage(page);
        }
    }
}