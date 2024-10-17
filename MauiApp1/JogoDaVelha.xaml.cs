namespace MauiApp1;

public partial class JogoDaVelha : ContentPage
{
    string vez = "X";
	public JogoDaVelha()
	{
		InitializeComponent();
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var botao = (Button)sender;
        botao.IsEnabled = false;

        botao.Text = vez;

        vez = vez.Equals("X") ? "O" : "X";
        VitoriaX();

    }

    private void VitoriaX()
    {
        if (btn10.Text.Equals("X") && btn11.Text == "X" && btn12.Text == "X")
        {
            DisplayAlert("Parabéns", "Vitória do Jogador X", "Jogar novamente");

            Zerar();
        }
    }

    private void Zerar()
    {
        btn10.Text = "";
        btn11.Text = String.Empty;
        btn12.Text = "";

        btn10.IsEnabled = true;
        btn11.IsEnabled = true;
        btn12.IsEnabled = true;
    }
}