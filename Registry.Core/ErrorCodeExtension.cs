using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Core
{
    public static class ErrorCodeExtension
    {
        public static string GetErrorDescription(this int? code)
        {
            return code switch
            {
                100 => "User not found",
                101 => "User already exists",
                _ => "An Error Occured",
            };
        }
    }
}
