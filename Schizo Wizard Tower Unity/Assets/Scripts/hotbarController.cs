using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;


public class hotbarController : MonoBehaviour
{
    public GameObject hotbarPanel;
    public GameObject slotPrefab;
    public int slotCount = 1;

    private itemDictionary Itemdictionary;

    private UnityEngine.InputSystem.Key[] hotbarKeys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  private void Awake()
    {
        Itemdictionary = FindFirstObjectByType<itemDictionary>();

        hotbarKeys = new UnityEngine.InputSystem.Key[slotCount];
        for(int i = 0; i < slotCount; i++)
        {
            hotbarKeys[i] = i < 9 ? (UnityEngine.InputSystem.Key)((int)UnityEngine.InputSystem.Key.Digit1 + i) : UnityEngine.InputSystem.Key.Digit0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slotCount; i++)
        {
            if (Keyboard.current[hotbarKeys[i]].wasPressedThisFrame)
            {
                // Check if the slot has an item and use it
                UseItemSlot(i);
            }
        }
    }
    void UseItemSlot(int index)
    {
        Slot slot = hotbarPanel.transform.GetChild(index).GetComponent<Slot>();
        if(slot.CurrentItem != null)
        {
        Item item = slot.CurrentItem.GetComponent<Item>();

            item.UseItem();
        }
    }
}
