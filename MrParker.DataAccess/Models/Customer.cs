﻿using MrParker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class Customer : IModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string AddrLine2 { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}
