using System;
using System.Collections.Generic;
using Project.AVIew.Models;
using System.IO;

namespace Project.AVIew.Logic
{
    public static class Database
    {
        public static List<UserModel> Users;

        static Database()
        {
            string[] lines = File.ReadAllLines("App_Data/users.txt");

            Users = new List<UserModel>();

            foreach (string line in lines)
            {
                string[] items = line.Split(';');

                UserModel user = new UserModel();
                user.Id = Guid.Parse(items[0].Trim());
                user.Login = items[1].Trim();
                user.PasswordHash = PasswordHasher.HashPassword(items[2].Trim());
                Users.Add(user);
            }
        }

        public static void AddUser(Guid IdGuid, string Login, string Password)
        {
            var newUser = new UserModel()
            {
                Id = IdGuid,
                Login = Login,
                PasswordHash = PasswordHasher.HashPassword(Password)
            };

            //WriterAndReadService wArSeirvice = new WriterAndReadService();

            //wArSeirvice.FileWriter($"{IdGuid}; {Login} ; {Password}", getfile: @"\users.txt", getdirectory: @"App_Data");
            Users.Add(newUser);
        }
    }
}
