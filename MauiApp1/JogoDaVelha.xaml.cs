namespace MauiApp1;

public partial class JogoDaVelha : ContentPage
{
    string vez = "X";
    public JogoDaVelha()
    {
        InitializeComponent();
        ((Label)((Grid)Content).Children[0]).Text = $"Jogo da Velha - {vez}";
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
            if (!Vitoria("O"))
                Velha();

        vez = vez.Equals("X") ? "O" : "X";
        ((Label)((Grid)Content).Children[0]).Text = $"Jogo da Velha - {vez}";
    }

    private async void Velha()
    {
        foreach (var item in (Grid)this.Content)
        {
            if (item is Button)
            {
                var btn = (Button)item;
                if (btn.Text != "Voltar")
                    if (btn.IsEnabled)
                        return;
            }
        }
        await DisplayAlert("Empate", "Deu Velha!", "Jogar novamente");

        Zerar();
    }

    private bool Vitoria(string jogador)
    {
        int linha, coluna;

        //Linhas
        for (linha = 1; linha < ((Grid)Content).Children.Count - 1; linha += 3)
        {
            for (coluna = 0; coluna <= 2; coluna++)
                if (GetButton(linha + coluna).Text != jogador)
                    break;

            if (coluna > 2)
            {
                ExibirMensagem(jogador);
                return true;
            }
        }

        //Colunas
        for (coluna = 0; coluna <= 2; coluna++)
        {
            for (linha = 1; linha < ((Grid)Content).Children.Count - 1; linha += 3)
                if (GetButton(linha + coluna).Text != jogador)
                    break;

            if (linha == 10)
            {
                ExibirMensagem(jogador);
                return true;
            }
        }
        //Diagonal \
        if (GetButton(1).Text == jogador &&
            GetButton(5).Text == jogador &&
            GetButton(9).Text == jogador)
        {
            ExibirMensagem(jogador);
            return true;
        }

        //Diagonal /
        if (GetButton(3).Text == jogador &&
            GetButton(5).Text == jogador &&
            GetButton(7).Text == jogador)
        {
            ExibirMensagem(jogador);
            return true;
        }

        return false;
    }

    private Button GetButton(int index)
    {
        return (Button)((Grid)Content).Children[index];
    }

    private async void ExibirMensagem(string jogador)
    {
        await DisplayAlert("Parabéns", $"Vitória do Jogador {jogador}", "Jogar novamente");

        Zerar();
    }

    private void Zerar()
    {
        foreach (var item in (Grid)this.Content)
        {
            if (item is Button)
            {
                var btn = (Button)item;

                if (btn.Text != "Voltar")
                {
                    btn.IsEnabled = true;
                    btn.Text = "";
                }
            }
        }
    }
}