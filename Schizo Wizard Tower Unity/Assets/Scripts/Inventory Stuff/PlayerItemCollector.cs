using System.Collections;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;
    private Collider2D currentCollision;

    // If false, pressing E will be ignored until re-enabled.
    private bool canPickup = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
    }

    private void Update()
    {
        if (currentCollision != null && canPickup && Input.GetKeyDown(KeyCode.E))
        {
            print("Pressed E to collect the item");

            if (currentCollision.TryGetComponent(out Item item))
            {
                bool itemAdded = inventoryController.AddItem(currentCollision.gameObject);
                if (itemAdded)
                {
                    // Disable further pickups for 1 second.
                    canPickup = false;
                    StartCoroutine(EnablePickupAfterDelay(1f));

                    // Capture the GameObject and clear the current collision to avoid further processing.
                    GameObject toDestroy = currentCollision.gameObject;
                    currentCollision = null;
                    StartCoroutine(DestroyAfterDelay(toDestroy, 1f));
                }
            }
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject go, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        if (go != null)
        {
            Destroy(go);
        }
    }

    private IEnumerator EnablePickupAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        canPickup = true;
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
