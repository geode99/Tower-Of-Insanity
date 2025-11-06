using UnityEngine;


public class KeyDoor : MonoBehaviour
{
    [SerializeField] public Key.KeyType keyType;
   
    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        // Deactivate the door visually/physically
        gameObject.SetActive(false);

        // Safely remove the key of this type from the saved inventory
        
    }
 
}
