﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Softjc.models
{
    public class KeyGenerator
    {
        public  string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            
            byte[] data = new byte[size];
            
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            
            StringBuilder result = new StringBuilder(size);
            
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            
            return result.ToString();
        }
    }
}