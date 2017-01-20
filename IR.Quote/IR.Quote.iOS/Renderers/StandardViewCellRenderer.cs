using System;
using IR.Quote.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(StandardViewCellRenderer))]
namespace IR.Quote.iOS.Renderers
{
    public class StandardViewCellRenderer : ViewCellRenderer
    {
        public static void Init()
        {
            var time = DateTime.UtcNow;
        }

        public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            cell.SetDisclosure(item.StyleId);
            return cell;
        }
    }
}