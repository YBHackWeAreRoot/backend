﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class Provider
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public byte ProviderType { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

    }
}
