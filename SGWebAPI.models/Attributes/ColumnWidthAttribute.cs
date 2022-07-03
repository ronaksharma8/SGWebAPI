using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnWidthAttribute : Attribute
    {
        public int Width { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnOrderAttribute"/> class.
        /// </summary>
        /// <param name="sequence"></param>
        public ColumnWidthAttribute(int width)
        {
            Width = width;
        }
    }
}
