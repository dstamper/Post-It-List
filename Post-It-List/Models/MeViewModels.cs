using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Post_It_List.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}