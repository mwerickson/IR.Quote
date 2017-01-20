using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using IR.Quote.Data.Models;
using PropertyChanged;

namespace IR.Quote.PageModels
{
    [ImplementPropertyChanged]
    public class ContactsPageModel : FreshBasePageModel
    {
        public ContactsPageModel()
        {
            
        }

        public ObservableCollection<Contact> Contacts { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
    }
}