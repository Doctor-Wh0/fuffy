﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Logic : IBLL
    {
        IDAL dal;
        public Logic()
        {
            dal = new DBWork();
        }       

        public bool AddUser(User user)
        {
            if (CheckLogin(user.login))
            {
                dal.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckLogin(string Login)     //true - проверка пройдена, дубликат не найден,
        {                                        //false - такой логин уже существует
            if (dal.GetAllUser().FirstOrDefault(x => x.login == Login) != null)
                return false;
            else
                return true;
        }
    }
}
