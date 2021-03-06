﻿using App2.Layers.Business;
using App2.Model;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class CadastrarTimeViewModel
    {
        public TimeModel TimeModel { get; set; }
        public ICommand CadastrarTimeCommand { get; private set; }
        public ICommand VoltarCommand { get; private set; }

        public CadastrarTimeViewModel()
        {
            TimeModel = new TimeModel();

            CadastrarTimeCommand = new Command(() =>
            {
                try
                {


                    var timeId = new TimeBusiness().SaveTime(TimeModel);

                    if (timeId != null)
                        new UsuarioBusiness().Register(timeId);

                    Global.Usuario = null;

                    MessagingCenter.Send("", "LoginSucesso");
                }
                catch(Exception ex)
                {
                    App.MensagemAlerta($"Dados inválidos ou campos não preenchidos \n{ex.Message}");
                }
            });

            //VoltarCommand = new Command(() =>
            //{
            //    MessagingCenter.Send(new Jogadores(), "JogadoresAbrir");
            //});
        }
    }
}
