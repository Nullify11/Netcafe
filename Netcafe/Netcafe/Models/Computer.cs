using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netcafe.Models
{
    public enum Performance
    {
        Low,
        Medium,
        High
    }

    public class Computer
    {
        public int Id { get; set; }

        public bool isOn { get; set; }

        public Performance Performance { get; set; }
    }
}