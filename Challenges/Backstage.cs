using System;
using System.Linq;
using System.Reflection;

namespace Challenges;

public static class Backstage {
    #region Fields

    public static FieldInfo? GetFieldInfo(this Type type, string fieldName) {
        return type.GetRuntimeFields()
                   .SingleOrDefault(it => it.Name == fieldName);
    }

    public static FieldInfo? GetFieldInfo(this object obj, string fieldName) {
        return obj.GetType().GetFieldInfo(fieldName);
    }

    public static object? GetFieldValue(this object obj, string fieldName) {
        return obj.GetType().GetFieldInfo(fieldName)?.GetValue(obj);
    }

    #endregion

    #region Properties

    public static PropertyInfo? GetPropertyInfo(this Type type, string propertyName) {
        return type.GetRuntimeProperties()
                   .SingleOrDefault(it => it.Name == propertyName);
    }

    public static PropertyInfo? GetPropertyInfo(this object obj, string propertyName) {
        return obj.GetType().GetPropertyInfo(propertyName);
    }

    public static object? GetPropertyValue(this object obj, string propertyName) {
        return obj.GetPropertyInfo(propertyName)?.GetValue(obj);
    }

    #endregion

    #region "Variables" (properties if possible, otherwise, fields)

    public static MemberInfo? GetVariableInfo(this Type type, string variableName) {
        return (MemberInfo?)type.GetPropertyInfo(variableName) ?? type.GetFieldInfo(variableName);
    }

    public static MemberInfo? GetVariableInfo(this object obj, string variableName) {
        return obj.GetType().GetVariableInfo(variableName);
    }

    public static object? GetVariableValue(this object obj, string variableName) {
        return obj.GetPropertyValue(variableName) ?? obj.GetFieldValue(variableName);
    }

    #endregion
}