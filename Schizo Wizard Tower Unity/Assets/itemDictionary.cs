using System.Collections.Generic;
using UnityEngine;

public class itemDictionary : MonoBehaviour
{
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> ItemDictionary = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject GetItemPrefab(int itemID)
    {
        ItemDictionary.TryGetValue(itemID, out GameObject prefab);
        if(prefab == null)
        {
            Debug.LogWarning("Item with ID "+ itemID +" not found in dictionary");
        }
        return prefab;
    }
}




