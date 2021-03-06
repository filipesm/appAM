﻿using App2.Layers.Business;
using App2.Layers.Data;
using App2.Model;
using App2.ViewModel;
using App2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }

        protected override void OnStart()
        {

            //var _dbConn = new Layers.Data.Config.DBConnection();



            Global.TokenSalesForce = new GenerateTokenBusiness().GetTokenFromSalesForce();

            MessagingCenter.Subscribe<string>(this, "LoginSucesso", (sender) =>
            {
                MainPage = new Principal();
            });

            MessagingCenter.Subscribe<LoginViewModel>(this, "CadastrarTimeAbrir", (sender) =>
            {
                MainPage = new CadastrarTime();
            });

            MessagingCenter.Subscribe<Views.Menu>(this, "LogoffClicked", (sender) =>
            {
                Global.TimeNome = null;
                new AcontecimentoData().DropTable();
                new JogadorSalesForceData().DropTable();
                new PartidaData().DropTable();
                MainPage = new Login();
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        internal static void MensagemAlerta(string texto)
        {
            Current.MainPage.DisplayAlert("Título", texto, "Ok");
        }
    }
}
