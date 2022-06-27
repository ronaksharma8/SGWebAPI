using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnOrderAttribute : Attribute
    {
        public int Sequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnOrderAttribute"/> class.
        /// </summary>
        /// <param name="sequence"></param>
        public ColumnOrderAttribute(int sequence)
        {
            Sequence = sequence;
        }
    }
}
