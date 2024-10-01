using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLibrary.Objects
{
    public class TodoItem
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime Created {  get; set; }

    }
}
