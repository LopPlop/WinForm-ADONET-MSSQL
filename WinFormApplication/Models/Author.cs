using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApplication.Models
{
    internal class Author : IDbModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
