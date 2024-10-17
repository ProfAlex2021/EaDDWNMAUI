namespace MauiApp1;

public partial class Combustivel : ContentPage
{
	public Combustivel()
	{
		InitializeComponent();
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}