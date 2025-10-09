using System.Collections.Generic;
using UnityEngine;

public class itemDictionary : MonoBehaviour
{
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> ItemDictionary;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        ItemDictionary = new Dictionary<int, GameObject>();

        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i + 1;
            }

            foreach (Item item in itemPrefabs)
            {
                ItemDictionary[item.ID] = item.gameObject;
            }
        }
    }

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




