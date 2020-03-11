﻿using MyBetModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBetService
{
    public class MyUserValidator : IUserValidator
    {
        public IList<User> CheckRegUser(User u)
        {
            using (var db = new MyDbContext())
            {
                List<User> userL =
                    db.Users
                    .Where(b => b.UserLogin == u.UserLogin || b.UserPass == u.UserPass)
                    .ToList();
                return userL;
            }
        }
        public int RegistrationNewUser(User user)
        {
            using (var context = new MyDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return 1;
            }
        }

        public void UpdateUser(User user)
        {
            using (var context = new MyDbContext())
            {
                var us = context.Users.FirstOrDefault(c => c.UserId == user.UserId);

                us.Name = user.Name;
                us.SecondName = user.SecondName;
                us.SurName = user.SurName;
                us.UserLogin = us.UserLogin;
                us.UserPass = user.UserPass;
                us.Birthday = user.Birthday;

                context.Users.Update(us);
                context.SaveChanges();
            }
        }

        public IList<User> GetUserData(User user)
        {
            using (var db = new MyDbContext())
            {
                List<User> userL =
                    db.Users
                    .Where(b => b.UserId == user.UserId)
                    .ToList();
                return userL;
            }
        }
    }
}
