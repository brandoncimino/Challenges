using System;
using System.Reflection;

namespace Challenges;

public static class Backstage {
    public static object? GetFieldValue(this object obj, string fieldName) {
        return obj.GetType().GetRuntimeField(fieldName)?.GetValue(obj);
    }

    public static object? GetPropertyValue(this object obj, string propertyName) {
        return obj.GetType().GetRuntimeField(propertyName)?.GetValue(obj);
    }

    public static MemberInfo? GetVariable(this Type type, string variableName) {
        return (MemberInfo?)type.GetRuntimeProperty(variableName) ?? type.GetRuntimeField(variableName);
    }

    public static object? GetVariableValue(this object obj, string variableName) {
        return obj.GetPropertyValue(variableName) ?? obj.GetFieldValue(variableName);
    }
}