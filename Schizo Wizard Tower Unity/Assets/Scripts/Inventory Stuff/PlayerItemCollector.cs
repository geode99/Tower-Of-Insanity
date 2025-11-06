using System.Collections;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;
    private Collider2D currentCollision;
    public GameObject Player;

    // If false, pressing E will be ignored until re-enabled.
    private bool canPickup = true;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
        Player.GetComponent<PlayerMovement>().CanMove = true;
    }

    private void Update()
    {
        if (currentCollision != null && canPickup && Input.GetKeyDown(KeyCode.E)|| currentCollision != null && currentCollision.CompareTag("Keys"))
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
                    Player.GetComponent<PlayerMovement>().CanMove = false;
                    StartCoroutine(EnableMovmentAfterDelay(1f));
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
    private IEnumerator EnableMovmentAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Player.GetComponent<PlayerMovement>().CanMove = true;
    }
    private IEnumerator EnablePickupAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        canPickup = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item")|| (collision.CompareTag("Keys")))
        {
            currentCollision = collision;
            Debug.Log("Player entered the item trigger area. Press 'E' to collect the item.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || (collision.CompareTag("Keys")))
        {
            if (currentCollision == collision)
            {
                currentCollision = null;
                Debug.Log("Player exited the item trigger area.");
            }
        }
    }
}
