using System.Collections.Generic;
using UnityEngine;

public static class WeaponFlyweightFactory
{
    private static readonly Dictionary<string, WeaponFlyweight> Cache = new();

    public static WeaponFlyweight Get(string id)
    {
        if (Cache.TryGetValue(id, out var fw)) return fw;

        fw = Resources.Load<WeaponFlyweight>($"Weapons/{id}");
        if (!fw)
            Debug.LogError($"WeaponFlyweight '{id}' not found in Resources/Weapons");
        else
            Cache[id] = fw;

        return fw;
    }
}