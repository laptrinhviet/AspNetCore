using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Data.Entities;

namespace AspNetCore.Services.Systems.AuditLogs
{
    public interface IAuditLogService
    {
        void Create(Error error);

        void Save();
    }
}
