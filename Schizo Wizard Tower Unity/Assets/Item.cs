using UnityEngine;
using System.Linq;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;

    public virtual void UseItem()
    {
        Debug.Log("Using item: " + gameObject.name);
    }

    private void Start()
    {
        if( SaveDataController.Current.inventoryItemIDs.Contains(ID) && transform.parent == null)
        {
            Destroy(gameObject);
        }

        if (FindObjectsByType<Item>(FindObjectsSortMode.None).Any(item => item.gameObject != gameObject && item.ID == ID))
        {
            Debug.LogError($"Duplicate item IDs detected: {ID} {name}");
        }
    }
}
