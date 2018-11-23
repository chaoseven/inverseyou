﻿using inverseyou.ddd.Values;
using inverseyou.utility.extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace inverseyou.ddd.Entities
{
    public class User:Entity
    {
        private User() { }
        
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public Gender GenderCode { get; set; }
        public string GenderText
        {
            get
            {
                return GenderCode.GetDescription();
            }
            set
            {
                value = GenderCode.GetDescription();
            }
        }
        public UserAccountStatus AccountStatusCode { get; set; }
        public string AccountStatusText
        {
            get
            {
                return AccountStatusCode.GetDescription();
            }
            set
            {
                value = AccountStatusCode.GetDescription();
            }
        }

        public static User CreateNewUser(string name,DateTime birthDay,string email,string mobileNumber,string password,Gender genderCode)
        {
            if(string.IsNullOrEmpty(name)
                ||string.IsNullOrEmpty(email)
                ||string.IsNullOrEmpty(mobileNumber)
                || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("用户信息不完整");
            }
            return new User
            {
                Id=-1,
                Name = name,
                BirthDay = birthDay,
                Email = email,
                MobileNumber = mobileNumber,
                Password = password,
                GenderCode = genderCode,
                AccountStatusCode = UserAccountStatus.Unactive
            };
        }

        public static User GetValidUser(int id, string name, DateTime birthDay, string email, string mobileNumber, string password, Gender genderCode,UserAccountStatus accountStatus)
        {
            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(mobileNumber)
                || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("用户信息不完整");
            }

            return new User
            {
                Id = id,
                Name = name,
                BirthDay = birthDay,
                Email = email,
                MobileNumber = mobileNumber,
                Password = password,
                GenderCode = genderCode,
                AccountStatusCode = accountStatus
            };
        }

        public void ChangeAccountStatus(UserAccountStatus accountStatusCode)
        {
            AccountStatusCode = accountStatusCode;
        }
    }
}