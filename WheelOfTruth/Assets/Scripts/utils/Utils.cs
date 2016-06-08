using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class Utils
{
    private static readonly Dictionary<string, Dictionary<string, AbilitiesPropertyCache>> propertyCache =
        new Dictionary<string, Dictionary<string, AbilitiesPropertyCache>>();

    public static void TransferData(object source, object target, bool addPercent = false)
    {
        string type1 = source.GetType().ToString();
        string type2 = target.GetType().ToString();
        Dictionary<string, AbilitiesPropertyCache> dic = null;
        Dictionary<string, AbilitiesPropertyCache> dic2 = null;
        if (propertyCache.ContainsKey(type1))
        {
            dic = propertyCache[type1];
        }
        if (propertyCache.ContainsKey(type2))
        {
            dic2 = propertyCache[type2];
        }
        if (dic == null && !propertyCache.ContainsKey(type1))
        {
            CacheProperty(source.GetType(), ref dic);
        }
        if (dic2 == null && !propertyCache.ContainsKey(type2))
        {
            CacheProperty(target.GetType(), ref dic2);
        }
        foreach (var info in dic)
        {
            PropertyInfo propertyInfo = info.Value.propertyInfo;

            AbilitiesAttribute attribute = info.Value.abilitiesAttribute;
            if (dic2.ContainsKey(attribute.GetName()))
            {
                PropertyInfo p = dic2[attribute.GetName()].propertyInfo;
                object val = propertyInfo.GetValue(source, null);
                switch (attribute.GetTransferType())
                {
                    case TransferType.PLUS:
                        Modify(propertyInfo, p, source, target, true, false);
                        break;
                    case TransferType.PLUS_PERCENT:
                        Modify(propertyInfo, p, source, target, true, addPercent);
                        break;
                    case TransferType.MINUS:
                        Modify(propertyInfo, p, source, target, false, false);
                        break;
                    case TransferType.MINUS_PERCENT:
                        Modify(propertyInfo, p, source, target, false, addPercent);
                        break;
                    default:
                        if (val != null)
                            p.SetValue(target, val, null);
                        break;
                }
            }
        }
    }

    private static void CacheProperty(Type type, ref Dictionary<string, AbilitiesPropertyCache> dic)
    {
        dic = new Dictionary<string, AbilitiesPropertyCache>();
        PropertyInfo[] p1 = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        for (int i = 0; i < p1.Length; i++)
        {
            PropertyInfo propertyInfo = p1[i];
            if (propertyInfo.IsDefined(typeof(AbilitiesAttribute), true))
            {
                object[] attributes = propertyInfo.GetCustomAttributes(typeof(AbilitiesAttribute), false);
                if (attributes.Length >= 0)
                {
                    var attribute = attributes[0] as AbilitiesAttribute;
                    var cache = new AbilitiesPropertyCache(attribute, propertyInfo);
                    dic.Add(attribute.GetName(), cache);
                }
            }
        }
        propertyCache.Add(type.ToString(), dic);
    }

    private static void Modify(PropertyInfo sourcePropertyInfo, PropertyInfo targetPropertyInfo, object source,
        object target, bool add, bool percent)
    {
        int dir = (add) ? 1 : -1;
        object target1 = targetPropertyInfo.GetValue(target, null);
        object val = sourcePropertyInfo.GetValue(source, null);
        if (target1 is int)
        {
            int source1Vaue = (int)val;
            int target1Value = (int)target1;
            int v = (percent)
                ? (int)(target1Value * (1 + source1Vaue / 100f * dir))
                : (int)(source1Vaue + target1Value);
            targetPropertyInfo.SetValue(target, v, null);
        }
        else
        {
            double source1Vaue = (double)val;
            double target1Value = (double)target1;
            double v = (percent)
                ? (double)(target1Value * (1 + source1Vaue / 100f * dir))
                : (double)(source1Vaue + target1Value);
            targetPropertyInfo.SetValue(target, v, null);
        }
    }

#region Inner classes
    private class AbilitiesPropertyCache
    {
        public readonly AbilitiesAttribute abilitiesAttribute;
        public readonly PropertyInfo propertyInfo;

        public AbilitiesPropertyCache(AbilitiesAttribute abilitiesAttribute, PropertyInfo propertyInfo)
        {
            this.abilitiesAttribute = abilitiesAttribute;
            this.propertyInfo = propertyInfo;
        }
    }
#endregion

}
