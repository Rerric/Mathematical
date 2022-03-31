using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemData
{
    public static Item[] Items { get; private set; }

    private static void Initialize() => Items = Resources.LoadAll<Item>(path: "Items/")
   
}
