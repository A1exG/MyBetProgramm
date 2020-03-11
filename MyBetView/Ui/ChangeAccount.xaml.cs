using MyBetModel.Model;
using MyBetService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MyBetView.Ui
{
    public partial class ChangeAccount : Window
    {
        private readonly IList<User> check;

        public ChangeAccount(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.check = check;
            LoadData(check[0]);

            IKernel kernel = new StandardKernel();
            MyUserValidator validator = kernel.Get<MyUserValidator>();

            this.Activated += (s, e) =>
            {
                var data = validator.GetUserData(check[0]);
                check = data;
                LoadData(check[0]);
            };

            btnSeve.Click += (s, e) =>
            {
                check[0].UserLogin = txtLogin.Text;
                check[0].UserPass = txtUserPass.Text;
                check[0].SurName = txtSurName.Text;
                check[0].SecondName = txtSecondName.Text;
                check[0].Name = txtName.Text;
                check[0].Birthday = Convert.ToDateTime(txtBirthday.Text);

                validator.UpdateUser(check[0]);
                MessageBox.Show("Данные сохранены");
                Close();
            };
            btnExit.Click += (s, e) => {Close();};
        }
        void LoadData(User check)
        {
            txtSurName.Text = check.SurName;
            txtName.Text = check.Name;
            txtSecondName.Text = check.SecondName;
            txtBirthday.Text = check.Birthday.ToShortDateString();
            txtLogin.Text = check.UserLogin;
            txtUserPass.Text = check.UserPass;
            txtUserId.Text = check.UserId.ToString();
        }
    }
}
