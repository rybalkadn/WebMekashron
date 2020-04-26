﻿using System;

namespace WebMekashron.Security
{
    [Serializable]
    public class UserData
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}