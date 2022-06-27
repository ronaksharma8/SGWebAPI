using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ColumnHiddenAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnHiddenAttribute"/> class.
        /// </summary>
        public ColumnHiddenAttribute()
        {
        }
    }
}
