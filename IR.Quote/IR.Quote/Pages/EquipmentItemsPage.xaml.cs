using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IR.Quote.Pages
{
    public partial class EquipmentItemsPage : ContentPage
    {
        public EquipmentItemsPage()
        {
            InitializeComponent();
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = EquipmentSearchBar.Text;
        }
    }
}
