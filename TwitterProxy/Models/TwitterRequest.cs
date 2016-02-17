using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterProxy.Models
{
    public class TwitterRequest
    {
        
        public int Limit { get; set; }

        public string HashTag { get; set; }
    }
}