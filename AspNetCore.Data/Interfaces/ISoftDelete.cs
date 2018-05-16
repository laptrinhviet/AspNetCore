using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { set; get; }
    }
}
