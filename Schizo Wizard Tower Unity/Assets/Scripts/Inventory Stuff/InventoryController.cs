using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public List<GameObject> itemPrefabs; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < SaveDataController.Current.inventoryItemIDs.Count; i++)
        {
            GameObject item = GetComponent<itemDictionary>().itemPrefabs[SaveDataController.Current.inventoryItemIDs[i]].gameObject;
            itemPrefabs.Add(item);
        }

        for(int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
            if(i < itemPrefabs.Count)
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.CurrentItem = item;
            }
        }
    }
    public bool AddItem(GameObject itemPrefab)
    {
        foreach( Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.CurrentItem == null)
          
        
            {
                GameObject newItem = Instantiate(itemPrefab, slotTransform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.CurrentItem = newItem;
                SaveDataController.Current.inventoryItemIDs.Add(itemPrefab.GetComponent<Item>().ID);
                return true; // Item added successfully
            }
        }
        Debug.Log("Inventory Full!");
        return false; // Inventory full
    }
    
}
