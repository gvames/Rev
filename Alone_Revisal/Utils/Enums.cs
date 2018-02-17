using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Utils
{
    public enum ErrorType : int
    {
        
    }

    public enum SQLExceptions : int
    {
        Ok = 0,
        NetworkPathNotFound = 1,
        UpdateFailed = 2,
    }
}
