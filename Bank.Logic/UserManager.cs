using System;
using System.Collections.Generic;

namespace Bank.Logic
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public enum FailedLoginReasons
    {
        UserNameDoesNotExist, WrongPassword
    }


    public delegate void SuccesfullLogin(User user);
    public delegate void UnsuccesfullLogin(FailedLoginReasons failedLoginReasons);

    public static class UserLoginManager
    {
        public static List<User> users = new List<User>()
        {
        new User() { UserName="Ariel",Password="Naim" },
        new User() { UserName="Yonit",Password="Mashu" },
        new User() { UserName="Levi",Password="Haalu" },
        new User() { UserName="Miriam",Password="Shani" }

        };


        public static event SuccesfullLogin SuccesfullLogin;
        public static event UnsuccesfullLogin UnsuccesfullLogin;

        public static bool Login(string userName, string password)
        {
            foreach (var item in users)
            {
                if (item.UserName == userName)
                {
                    if (item.Password != password)
                    {
                        OnUnsuccesfullLogin(FailedLoginReasons.WrongPassword);
                        return false;
                    }
                    else
                    {
                        OnSuccesfullLogin(item);
                        return true;
                    }
                }
            }


            OnUnsuccesfullLogin(FailedLoginReasons.UserNameDoesNotExist);
            return false; ;
        }

        private static void OnUnsuccesfullLogin(FailedLoginReasons failedLoginReasons)
        {
            if (UnsuccesfullLogin != null)
                UnsuccesfullLogin(failedLoginReasons);
        }

        private static void OnSuccesfullLogin(User user)
        {
            if (SuccesfullLogin != null)
                SuccesfullLogin(user);
        }
    }

}
