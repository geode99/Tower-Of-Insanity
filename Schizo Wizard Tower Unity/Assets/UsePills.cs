using Unity.VisualScripting;
using UnityEngine;

public class UsePills : MonoBehaviour
{
    public GameObject Player;
    public GameObject hotbar;

    private PlayerSanity playerSanity;
    private hotbarController HotbarController;
    private itemDictionary Itemdictionary;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerSanity = Player.GetComponent<PlayerSanity>();
            HotbarController = hotbar.GetComponent<hotbarController>();
            Itemdictionary = FindFirstObjectByType<itemDictionary>();
            // Check if the first slot in the hotbar has an item
            Slot slot = hotbar.transform.GetChild(0).GetComponent<Slot>();
            if (slot.CurrentItem != null)
            {
                Item item = slot.CurrentItem.GetComponent<Item>();
                if (item.itemName == "Pills")
                {
                    // Use the pills to increase sanity
                    playerSanity.sanity += 5f;
                    if (playerSanity.sanity > 40f)
                    {
                        playerSanity.sanity = 40f; // Cap sanity at 100
                    }
                    // Remove the pills from the hotbar
                    Destroy(slot.CurrentItem);
                    slot.CurrentItem = null;
                }
            }
        }
    }
}

}
