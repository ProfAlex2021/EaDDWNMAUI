﻿namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void btnCombustivel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Combustivel());
        }

        private void btnJogo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JogoDaVelha());
        }
    }

}
