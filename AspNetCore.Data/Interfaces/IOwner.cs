using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data.Interfaces
{
    public interface IOwner<T>
    {
        T OwnerId { set; get; }


    }
}
