using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static void ShuffleList<T>(List<T> list)
    {
        var random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }
}
