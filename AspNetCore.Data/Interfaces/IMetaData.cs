using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data.Interfaces
{
    public interface IMetaData
    {
        string PageAlias { set; get; }
        string PageTitle { set; get; }     
        string MetaKeywords { set; get; }
        string MetaDescription { get; set; }
    }
}
