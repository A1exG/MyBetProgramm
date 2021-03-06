﻿using MyBetModel.Model;
using MyBetService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MyBetView.Ui
{
    public partial class Main : Window
    {
        private IList<User> check;
        public Main(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            this.Activated += (s, e) =>
            {
                IKernel kernel = new StandardKernel();
                MyUserValidator validator = kernel.Get<MyUserValidator>();
                var data = validator.GetUserData(check[0]);
                check = data;
            };

            this.check = check;
            lblHellow.Content = string.Format("Добро пожаловать, {0} {1}!", check[0].SurName, check[0].Name);

            if (check[0].UserLogin == "admin"){btnAddResult.Visibility = Visibility.Visible; btnAddEvent.Visibility = Visibility.Visible; }

            btnEvent.Click += (s, e) => 
            {
                var events = new EventsUi(check);
                events.Owner = this;
                events.ShowDialog();
            };
            btnAccount.Click += (s, e) =>
            {
                var userAccount = new UserAccountUi(check);
                userAccount.Owner = this;
                userAccount.ShowDialog();
            };
            btnHistoryBets.Click += (s, e) =>
            {
                var historyBets = new HistoryBetsUi(check);
                historyBets.Owner = this;
                historyBets.ShowDialog();
            };

            btnAddResult.Click += (s, e) =>
            {
                var addResult = new AddResultUi();
                addResult.Owner = this;
                addResult.ShowDialog();
            };

            btnAddEvent.Click += (s, e) =>
            {
                var addNewEvent = new AddNewEventUi();
                addNewEvent.Owner = this;
                addNewEvent.ShowDialog();
            };

            btnHistiryEvent.Click += (s, e) =>
            {
                var historyEvent = new HistoryEventUi();
                historyEvent.Owner = this;
                historyEvent.ShowDialog();
            };
        }
    }
}
