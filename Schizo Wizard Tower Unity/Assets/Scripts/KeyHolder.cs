using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            // Start a coroutine to wait in real time, then destroy the key object.
            StartCoroutine(DestroyAfterRealtime(key.gameObject, 1f));
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
           if (ContainsKey(keyDoor.GetKeyType()))
           {
                //Currently holding Key to open this door
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
           }
        }
    }

    private IEnumerator DestroyAfterRealtime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}
