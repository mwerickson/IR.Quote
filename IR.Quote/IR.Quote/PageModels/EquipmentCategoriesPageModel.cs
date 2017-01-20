using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using IR.Quote.Data.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace IR.Quote.PageModels
{
    [ImplementPropertyChanged]
    public class EquipmentCategoriesPageModel : FreshBasePageModel
    {
        public EquipmentCategoriesPageModel()
        {
            
        }

        private EquipmentCategory _selectedItem;
        public EquipmentCategory SelectedItem {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem == null) return;
                ItemSelectedCommand.Execute(null);
                _selectedItem = null;  // needed to un-select the item from the list
            }
        }

        public List<EquipmentCategory> Categories { get; set; }
        public List<EquipmentCategory> FullCategoryList { get; set; }

        public Command ItemSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<EquipmentItemsPageModel>(SelectedItem.Name);
                });
            }
        }

        public Command FilterListCommand
        {
            get
            {
                return new Command<string>((searchText) =>
                {
                    Categories = FullCategoryList.Where(c => c.Name.Contains(searchText)).ToList();
                });
            }
        }

        public override void Init(object initData)
        {
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            FullCategoryList = new List<EquipmentCategory>();
            FullCategoryList.Add(new EquipmentCategory() { Name = "Air Compressors" });
            FullCategoryList.Add(new EquipmentCategory() { Name = "Articulating booms" });
            FullCategoryList.Add(new EquipmentCategory() { Name = "Backhoe loaders" });
            FullCategoryList.Add(new EquipmentCategory() { Name = "Excavators" });
            FullCategoryList.Add(new EquipmentCategory() { Name = "Forklift trucks" });
            Categories = FullCategoryList;
        }
    }
}