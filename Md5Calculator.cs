﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashForFieldsAttribute;

public static class Md5Calculator
{
    /// <summary>
    /// Use input string to calculate MD5 hash
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string GetHashKey(string input)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
