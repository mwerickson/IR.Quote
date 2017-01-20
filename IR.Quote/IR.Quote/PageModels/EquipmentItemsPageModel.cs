using System;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using FreshMvvm;
using IR.Quote.Data.Models;
using Xamarin.Forms;

namespace IR.Quote.PageModels
{
    public class EquipmentItemsPageModel : FreshBasePageModel
    {
        public EquipmentItemsPageModel()
        {
            
        }

        public ObservableCollection<EquipmentItem> Items { get; set; }
        public string Title { get; set; }
        public string CustomerName { get; set; } = "Caterpillar America";

        public Command AddItemCommand
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    var result = await UserDialogs.Instance.PromptAsync($"Enter a quantity for id {id}", "Quantity",
                        "Ok", "Cancel", "Qty", InputType.Number);
                });
            }
        }

        public override void Init(object initData)
        {
            Title = (string) initData;
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            Items = new ObservableCollection<EquipmentItem>();
            Items.Add(new EquipmentItem() { Available = 5, Name = "14\" BLADE - HAND-HELD CONCRETE SAW", BookVal1 = "D 1,400", BookVal2 = "W 450", BookVal3 = "M 500", FloorVal1 = "D 360", FloorVal2 = "W 410", FloorVal3 = "M 450", Id = 1, MarketVal1 = "D 380", MarketVal2 = "W 420", MarketVal3 = "M 480" });
            Items.Add(new EquipmentItem() { Available = 5, Name = "18\" BLADE - WLAK BEHIND CONCRETE SAW", BookVal1 = "D 400", BookVal2 = "W 450", BookVal3 = "M 500", FloorVal1 = "D 360", FloorVal2 = "W 410", FloorVal3 = "M 450", Id = 2, MarketVal1 = "D 380", MarketVal2 = "W 420", MarketVal3 = "M 480" });
            Items.Add(new EquipmentItem() { Available = 5, Name = "TROWEL WALK-BEHIND 36\"", BookVal1 = "D 400", BookVal2 = "W 450", BookVal3 = "M 500", FloorVal1 = "D 360", FloorVal2 = "W 410", FloorVal3 = "M 450", Id = 3, MarketVal1 = "D 380", MarketVal2 = "W 420", MarketVal3 = "M 480" });
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
    }
}