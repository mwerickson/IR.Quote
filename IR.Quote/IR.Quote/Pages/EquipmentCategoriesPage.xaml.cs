using System;
using IR.Quote.PageModels;
using Xamarin.Forms;

namespace IR.Quote.Pages
{
    public partial class EquipmentCategoriesPage : ContentPage
    {
        public EquipmentCategoriesPage()
        {
            InitializeComponent();
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = EquipmentSearchBar.Text;
            var vm = BindingContext as EquipmentCategoriesPageModel;
            if (vm == null) return;
            vm.FilterListCommand.Execute(searchText);
        }
    }
}
