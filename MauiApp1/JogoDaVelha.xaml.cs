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

        if (!Vitoria("X"))
        {
            if (!Vitoria("O"))
            {
                if (!btn10.IsEnabled &&
                   !btn11.IsEnabled &&
                   !btn12.IsEnabled)
                {
                    DisplayAlert("Empate", "Deu Velha!", "Jogar novamente");

                    Zerar();
                }
            }
        }

        vez = vez.Equals("X") ? "O" : "X";
    }

    private bool Vitoria(string jogador)
    {
        //1ª condição de vitória X
        if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador)
        {
            DisplayAlert("Parabéns", $"Vitória do Jogador {jogador}", "Jogar novamente");

            Zerar();
            return true;
        }






        return false;
        
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