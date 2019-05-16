using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Task
    {
        public long Id { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }
    }
}