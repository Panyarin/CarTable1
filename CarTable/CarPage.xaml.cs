using CarTable.MVVM.ViewModels;
namespace CarTable;

public partial class CarPage : ContentPage
{
	public CarPage()
	{
		InitializeComponent();
		BindingContext = new CarPageViewModel();
	}
}