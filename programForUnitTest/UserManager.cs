using System;
using System.Text.RegularExpressions;

namespace programForUnitTest
{
    public class UserManager
    {
        public void Add(string username, string phone, string email)
        {
            if(!Regex.IsMatch(email, @"^.+@.+\..+$"))
            {
                throw new Exception("Некорректный формат e-mail");
            }

            if(!Regex.IsMatch(username, @"^[а-яА-Яa-zA-Z ]+$"))
            {
                throw new Exception("Некорректное имя пользователя");
            }

            if(!Regex.IsMatch(phone, @"\d{11}"))
            {
                throw new Exception("Некорректный номер телефона");
            }
        }
    }
}
