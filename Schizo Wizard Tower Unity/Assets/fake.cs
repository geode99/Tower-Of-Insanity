using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
     

        private void OnTriggerEnter2D(Collider2D collider)
        {
            Key key = collider.GetComponent<Key>();
            if (key != null)
            {
                // Start a coroutine to wait in real time, then destroy the key object.
                StartCoroutine(DestroyAfterRealtime(key.gameObject, 1f));
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



