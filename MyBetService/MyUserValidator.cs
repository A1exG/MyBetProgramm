using MyBetModel.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBetService
{
    public class MyUserValidator : IUserValidator
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public IList<User> CheckRegUser(User u)
        {
            try
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
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }
        public int RegistrationNewUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return 0;
            }
        }

        public void UpdateUser(User user)
        {
            try
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
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
            }
        }

        public IList<User> GetUserData(User user)
        {
            try
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
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }
    }
}
