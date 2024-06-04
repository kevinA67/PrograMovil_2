namespace PrimerProyectoMovil2.Views;

public partial class PageListPerson : ContentPage
{
	public PageListPerson()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Views.NewPage1 page = new NewPage1();
        Navigation.PushAsync(page);
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }

    private void ListPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        ListPerson.ItemsSource =await App.DataBase.GetListPersons();
    }
}