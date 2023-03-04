using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApplication.Models
{
    class Book : IDbModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
