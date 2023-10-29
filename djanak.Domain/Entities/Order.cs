﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace djanak.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime DataTimeCreated { get; protected set; }
        public string OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }

        //public User User { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}