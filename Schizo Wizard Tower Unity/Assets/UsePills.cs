using UnityEngine;
using UnityEngine.InputSystem;

public class UsePills : MonoBehaviour
{
    public GameObject Player;
    public GameObject hotbar;

    private PlayerSanity playerSanity;
    private InventoryController InventoryController;
    private itemDictionary Itemdictionary;
    private Item Item;

    private void Start()
    {
        if (Player != null)
            playerSanity = Player.GetComponent<PlayerSanity>();
        if (hotbar != null)
            InventoryController = hotbar.GetComponent<InventoryController>();
        Itemdictionary = FindFirstObjectByType<itemDictionary>();
    }
    // getting a quick way to use pills from Inventory or hotbar
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Q))
            return;

        if (playerSanity == null && Player != null)
            playerSanity = Player.GetComponent<PlayerSanity>();
        if (hotbar == null)
            return;


        for (int i = 0; i < hotbar.transform.childCount; i++)
        {
            var slotTransform = hotbar.transform.GetChild(i);
            if (slotTransform == null)
                continue;

            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot == null || slot.CurrentItem == null)
                continue;

            Item item = slot.CurrentItem.GetComponent<Item>();
            if (item != null && item.Name == "Pills")
            {

                SaveDataController.Current.sanity += 5f;
                if (SaveDataController.Current.sanity > 40f)
                    SaveDataController.Current.sanity = 40f;

                
                Destroy(slot.CurrentItem);
                slot.CurrentItem = null;
                SaveDataController.Current.inventoryItemIDs.Remove(item.ID);

                break;
            }
        }
    }

}

