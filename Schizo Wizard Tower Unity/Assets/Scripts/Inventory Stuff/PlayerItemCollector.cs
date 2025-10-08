using System;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;
    private Collider2D currentCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
    }
    private void Update()
    {
        if (currentCollision != null && Input.GetKeyDown(KeyCode.E))
        {
            print("Pressed E to collect the item");

            if (currentCollision.TryGetComponent(out Item item))
            {
                bool itemAdded = inventoryController.AddItem(currentCollision.gameObject);
                if (itemAdded)
                {
                    Destroy(currentCollision.gameObject);
                }
            }
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            currentCollision = collision;
            Debug.Log("Player entered the item trigger area. Press 'E' to collect the item.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (currentCollision == collision)
            {
                currentCollision = null;
                Debug.Log("Player exited the item trigger area.");
            }
        }
    }
}
