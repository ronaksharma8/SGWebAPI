using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute : Attribute
    {
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnNameAttribute"/> class.
        /// </summary>
        /// <param name="sequence"></param>
        public ColumnNameAttribute(string name)
        {
            Name = name;
        }
    }
}
