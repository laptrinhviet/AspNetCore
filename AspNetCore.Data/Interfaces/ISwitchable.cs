using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
