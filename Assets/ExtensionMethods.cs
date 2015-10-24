using UnityEngine;
using System.Collections;

public static partial class ExtensionMethods
{
    public static T GetRandom<T>(this T[] self)
    {
        if (self.Length > 0)
        {
            return self[Random.Range(0, self.Length)];
        }
        else
        {
            return default(T);
        }
    }
}
