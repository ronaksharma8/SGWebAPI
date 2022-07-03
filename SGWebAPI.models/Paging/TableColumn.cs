using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SGWebAPI.Models.Attributes;
using SGWebAPI.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Paging
{
    public class TableColumn
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string DataType { get; set; }
        public bool Hidden { get; set; }
        public bool Editable { get; set; }
        public bool Sortable { get; set; }
        public int? ColumnOrder { get; set; }
        public int? ColumnWidth { get; set; }
        public bool IsKey { get; set; }
        public string[] Values { get; set; }
        public IList<TableColumn> Columns { get; set; }

        private static IList<PropertyInfo> GetProperties(Type type)
        {
            var properties = ReflectionHelper.GetPropertiesForType(type);

            return properties;
        }

        /// <summary>
        ///     retrieves the names of the properties of the items in the list passed
        /// </summary>
        /// <returns>a list of property names</returns>
        private static IDictionary<string, PropertyInfo> GetPropertyNames(Type type)
        {
            var properties = GetProperties(type);

            var propertyDict = properties
                .GroupBy(c => c.Name)
                .ToDictionary(
                    g => g.Key,
                    g => g.First()
                );

            return propertyDict;
        }

        /// <summary>
        ///     creates a list of columns dynamically from the items passed
        /// </summary>
        /// <returns>a list of <c>TableColumn</c> instances</returns>
        public static IList<TableColumn> CreateDynamicColumnsByList(Type type)
        {
            var propertyNames = GetPropertyNames(type);
            var tableColumns = BuildTableColumns(propertyNames);

            return tableColumns;
        }

        public static IList<TableColumn> CreateDynamicColumnsByType(Type type)
        {
            var propertyNames = ReflectionHelper.GetPropertiesForType(type)
                .GroupBy(c => c.Name)
                .ToDictionary(
                    g => g.Key,
                    g => g.First()
                );

            var tableColumns = BuildTableColumns(propertyNames);

            return tableColumns;
        }

        private static IList<TableColumn> BuildTableColumns(IDictionary<string, PropertyInfo> properties)
        {
            var tableColumns = new List<TableColumn>();

            foreach (var property in properties)
            {
                if (!property.Value.CanRead)
                {
                    continue;
                }

                var customAttributes = property.Value.GetCustomAttributes(true);

                var nameAttribute = GetAttribute<ColumnNameAttribute>(customAttributes);
                var descriptionAttribute = GetAttribute<DescriptionAttribute>(customAttributes);
                var columnDataTypeAttribute = GetAttribute<ColumnDataTypeAttribute>(customAttributes);
                var columnHiddenAttribute = GetAttribute<ColumnHiddenAttribute>(customAttributes);
                var columnEditableAttribute = GetAttribute<ColumnEditableAttribute>(customAttributes);
                var queryPropertyAttribute = GetAttribute<QueryPropertyAttribute>(customAttributes);
                var columnOrderAttribute = GetAttribute<ColumnOrderAttribute>(customAttributes);
                var columnWidthAttribute = GetAttribute<ColumnWidthAttribute>(customAttributes);
                var isSerializedAsString = GetAttribute<JsonConverterAttribute>(customAttributes)?.ConverterType == typeof(StringEnumConverter);
                var keyAttribute = GetAttribute<KeyAttribute>(customAttributes);

                var columnDataType = isSerializedAsString
                    ? ColumnDataType.String
                    : columnDataTypeAttribute == null
                        ? CreateColumnDataType(property.Value)
                        : columnDataTypeAttribute.ColumnDataType;

                var tableColumn = new TableColumn
                {
                    Name = nameAttribute?.Name,
                    Text = descriptionAttribute != null
                        ? descriptionAttribute.Description
                        : property.Key.SeparateWordsByTitleCase(),
                    DataType = columnDataType.ToString().SeparateWordsByCamelCase(),
                    Values = columnDataTypeAttribute?.Items,
                    Hidden = columnHiddenAttribute != null,
                    Editable = columnEditableAttribute != null,
                    Sortable = queryPropertyAttribute != null,
                    ColumnOrder = columnOrderAttribute?.Sequence,
                    ColumnWidth = columnWidthAttribute?.Width,
                    IsKey = keyAttribute != null,
                };

                tableColumns.Add(tableColumn);
            }

            return tableColumns;

            T GetAttribute<T>(object[] attributes)
            {
                for (var i = 0; i < attributes.Length; i++)
                {
                    if (attributes[i] is T match)
                    {
                        return match;
                    }
                }

                return default;
            }
        }

        private static ColumnDataType CreateColumnDataType(PropertyInfo property)
        {
            var propertyType = property.PropertyType;

            if (!propertyType.IsValueType ||
                (propertyType == typeof(char)) ||
                (propertyType == typeof(string)))
            {
                return ColumnDataType.String;
            }

            if (propertyType == typeof(bool))
            {
                return ColumnDataType.Boolean;
            }

            if (propertyType == typeof(DateTime))
            {
                return ColumnDataType.Date;
            }

            if (propertyType == typeof(DateTime?))
            {
                return ColumnDataType.Date;
            }

            if (propertyType.ToString() == "SingleSelect")
            {
                return ColumnDataType.SingleSelect;
            }

            return ColumnDataType.Number;
        }
    }
}
