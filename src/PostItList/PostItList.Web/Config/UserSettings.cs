/* Copyright (c) 2017 Jonathan Jensen, David Stamper
 This work is available under the "MIT license".
 Please see the file COPYING in this distribution
 for license terms.*/
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostItList.Web.Config
{
    public class UserSettings
    {
        public string APIURL { get; set; }
    }
}
