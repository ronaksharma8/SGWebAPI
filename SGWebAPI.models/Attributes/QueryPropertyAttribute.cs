using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    /// <summary>
    /// Defines property queryability as well as mapping
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryPropertyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the target property
        /// </summary>
        /// <value>
        /// The target property to map to when projecting queries
        /// </value>
        public string TargetProperty { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPropertyAttribute"/> class.
        /// </summary>
        /// <param name="targetProperty">The target property to map to when querying</param>
        /// <remarks>When <paramref name="targetProperty"/> is null the target is reconciled using the source property name alone</remarks>
        public QueryPropertyAttribute(string targetProperty = null)
        {
            TargetProperty = targetProperty;
        }
    }
}
