using Demo.ViewModels;
using MvvmCross.Forms.Views;

namespace Demo.Views
{
	
	public partial class ProductList : MvxContentPage<ProductViewModel>
    {
		public ProductList()
		{
			InitializeComponent ();
		}
	}
}