using SGWebAPI.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ColumnDataTypeAttribute : Attribute
    {
        public ColumnDataType ColumnDataType { get; private set; }

        /// <summary>
        ///     Initialises the <c>ColumnDataTypeAttribute</c>
        /// </summary>
        /// <param name="columnDataType">Type of the column data</param>
        public ColumnDataTypeAttribute(ColumnDataType columnDataType)
        {
            ColumnDataType = columnDataType;
        }
    }
}
