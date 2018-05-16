using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data.Interfaces
{
    interface IMustHaveTenant
    {
      Guid TenantId { get; set; }

    }
}
