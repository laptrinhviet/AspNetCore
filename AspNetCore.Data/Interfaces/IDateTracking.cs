using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime CreatedDate { set; get; }

        DateTime? UpdatedDate { set; get; }

        DateTime? DeletedDate { set; get; }
    }
}
