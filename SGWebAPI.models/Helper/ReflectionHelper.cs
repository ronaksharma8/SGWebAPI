using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Helper
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Determines whether the expression is a member expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static bool IsMemberExpression<T>(Expression<Func<T>> exp)
        {
            var memberExpr = exp.Body as MemberExpression;

            return memberExpr != null;
        }

        /// <summary>
        /// Determines whether Determines whether the expression is a lambda expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static bool IsLambdaExpression<T>(Expression<Func<T>> exp)
        {
            var lambdaExpr = exp.Body as LambdaExpression;

            return lambdaExpr != null;
        }

        /// <summary>
        /// Determines whether Determines whether the expression is a unary expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static bool IsUnaryExpression<T>(Expression<Func<T>> exp)
        {
            var unaryExpr = exp.Body as UnaryExpression;

            return unaryExpr != null;
        }

        /// <summary>
        /// Gets the name of the member expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetMemberName<T>(Expression<Func<T>> exp)
        {
            return (exp.Body as MemberExpression).Member.Name;
        }

        /// <summary>
        /// Gets the name of the lambda expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetLambdaName<T>(Expression<Func<T>> exp)
        {
            return ((LambdaExpression)exp.Body).Name;
        }

        /// <summary>
        /// Gets the name of the unary expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetUnaryName<T>(Expression<Func<T>> exp)
        {
            var operand = ((UnaryExpression)exp.Body).Operand;

            return (operand as MemberExpression).Member.Name;
        }

        /// <summary>
        /// Gets the name of the expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetExpressionName<T>(Expression<Func<T>> exp)
        {
            if (IsMemberExpression(exp))
            {
                return GetMemberName(exp);
            }

            if (IsLambdaExpression(exp))
            {
                return GetLambdaName(exp);
            }

            if (IsUnaryExpression(exp))
            {
                return GetUnaryName(exp);
            }

            return null;
        }

        public static IDictionary<string, object> GetPropertiesDictionary(object obj)
        {
            var dict = GetPropertiesDictionary(obj,
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance
                );

            return dict;
        }

        public static IDictionary<string, object> GetPropertiesDictionary(object obj, BindingFlags bindingFlags)
        {
            if (obj == null)
            {
                return null;
            }

            var dict = GetPropertiesForType(obj.GetType(), bindingFlags)
                .ToDictionary(
                    pi => pi.Name,
                    pi => pi.GetValue(obj)
                );

            return dict;
        }

        public static IList<PropertyInfo> GetPropertiesForType(Type type)
        {
            var list = GetPropertiesForType(
                type,
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance
                );

            return list;
        }

        public static IList<PropertyInfo> GetPropertiesForType(Type type, BindingFlags bindingFlags)
        {
            var propertyInfos = type.GetProperties(bindingFlags);

            return propertyInfos;
        }

        public static IList<PropertyInfo> GetPropertiesForTypes(IEnumerable<Type> types)
        {
            var list = GetPropertiesForTypes(
                types,
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance
                );

            return list;
        }

        public static IList<PropertyInfo> GetPropertiesForTypes(IEnumerable<Type> types, BindingFlags bindingFlags)
        {
            var properties = types
                .SelectMany(t => GetPropertiesForType(t, bindingFlags))
                .ToList();

            return properties;
        }

        public static PropertyInfo GetPropertyInfoByName(this object instance, string propertyName)
        {
            var propertyNames = propertyName.Split(".".ToCharArray());

            var instancePropertyName = propertyNames
                .FirstOrDefault();

            var childPropertyNames = propertyNames
                .Skip(1)
                .ToList();
            var childPropertyNamesText = childPropertyNames.Any()
                ? string.Join(".", childPropertyNames)
                : string.Empty;

            var propertyInfo = instance == null
                ? null
                : GetPropertiesForType(instance.GetType())
                    .FirstOrDefault(p => p.Name.Equals(instancePropertyName, StringComparison.CurrentCultureIgnoreCase));

            var instanceValue = propertyInfo == null
                ? null
                : propertyInfo.GetValue(instance, null);

            var returnValue = childPropertyNames.Any()
                ? GetPropertyInfoByName(instanceValue, childPropertyNamesText)
                : propertyInfo;

            return returnValue;
        }

        public static bool IsPropertyNameValid(this object instance, string propertyName)
        {
            var propertyInfo = GetPropertyInfoByName(instance, propertyName);

            var exists = propertyInfo != null;

            return exists;
        }

        public static object GetPropertyValueByName(this object instance, string propertyName)
        {
            var propertyNames = propertyName.Split(".".ToCharArray());

            var instancePropertyName = propertyNames
                .FirstOrDefault();

            var childPropertyNames = propertyNames
                .Skip(1)
                .ToList();
            var childPropertyNamesText = childPropertyNames.Any()
                ? string.Join(".", childPropertyNames)
                : string.Empty;

            var propertyInfo = GetPropertiesForType(instance.GetType())
                .FirstOrDefault(p => p.Name.Equals(instancePropertyName, StringComparison.CurrentCultureIgnoreCase));

            var instanceValue = propertyInfo == null
                ? null
                : propertyInfo.GetValue(instance, null);

            var returnValue = childPropertyNames.Any()
                ? GetPropertyValueByName(instanceValue, childPropertyNamesText)
                : instanceValue;

            return returnValue;
        }

        public static string GetMemberName<T>(this Expression<T> expression)
        {
            switch (expression.Body)
            {
                case MemberExpression m:
                    return m.Member.Name;
                case UnaryExpression u when u.Operand is MemberExpression m:
                    return m.Member.Name;
                default:
                    throw new NotImplementedException(expression.GetType().ToString());
            }
        }
    }
}
