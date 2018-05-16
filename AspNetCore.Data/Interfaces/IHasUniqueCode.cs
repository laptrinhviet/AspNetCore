using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data.Interfaces
{
    public interface IHasUniqueCode
    {
        string UniqueCode { set; get; }
    }
}
