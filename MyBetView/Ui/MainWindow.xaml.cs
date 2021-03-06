﻿using MyBetModel.Model;
using MyBetService;
using Ninject;
using NLog;
using System.Windows;


namespace MyBetView.Ui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            IKernel kernel = new StandardKernel();
            MyUserValidator validator = kernel.Get<MyUserValidator>();
            Logger logger = LogManager.GetCurrentClassLogger();


            btnOk.Click += (s, e) =>
            {
                var userLogin = txtLogin.Text.ToString();
                var userPass = txtPass.Text.ToString();

                User u = new User(userLogin, userPass);
                var check = validator.CheckRegUser(u);

                if (check.Count > 0)
                {
                    logger.Info($"Успешный вход в систему {userLogin}");
                    var main = new Main(check);
                    main.Show();
                    Close();
                }
            };

            btnRegistration.Click += (s, e) =>
            {
                RegistrationUser regUser = new RegistrationUser();
                regUser.Owner = this;
                regUser.ShowDialog();
            };
        }
    }
}
