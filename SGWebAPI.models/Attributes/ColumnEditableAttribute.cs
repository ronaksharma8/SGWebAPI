using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ColumnEditableAttribute : Attribute
    {
        public ColumnEditableAttribute()
        {

        }
    }
}
