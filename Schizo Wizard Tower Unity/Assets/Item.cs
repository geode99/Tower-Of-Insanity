using UnityEngine;
using System.Linq;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;

    public Key.KeyType Key { get; internal set; }

    public virtual void UseItem()
    {
        Debug.Log("Using item: " + gameObject.name);
    }

    private void Start()
    {
        System.Func<Key.KeyType> Key = GetComponent<Key>().GetKeyType;
        if ( SaveDataController.Current.inventoryItemIDs.Contains(ID) && transform.parent == null)
        {
            Destroy(gameObject);
        }
        else
        {

        }
        // if item is in inventory and is in the world get rid of world version, do not parent world version or it will break inventory logic

        if (FindObjectsByType<Item>(FindObjectsSortMode.None).Any(item => item.gameObject != gameObject && item.ID == ID))
        {
            Debug.LogError($"Duplicate item IDs detected: {ID} {name}");
        }
    }
}
