namespace MauiAppMinhasCompras.Views;

public partial class ListaProdutos : ContentPage
{
	public ListaProdutos()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
            //chama nova tela 

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}