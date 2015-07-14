﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Domain.Models
{
    public interface IPageModel
    {
        IPageInfo Page { get; }
    }
        
    public interface IPageInfo
    {
        string Title { get; }
        string HeadCustom { get; }
        string MetaDescription { get; }
        string MetaKeywords { get; }
        string CanonicalURLs { get; }
        string FaviconURL { get; }
        bool DisplayProfiler { get; }
    }    
}
