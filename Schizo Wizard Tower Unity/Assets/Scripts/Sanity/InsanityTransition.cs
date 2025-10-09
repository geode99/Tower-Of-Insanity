using UnityEngine;

public class InsanityTransition : MonoBehaviour
{
    public GameObject disappear;

    // Disable this GameObject when it hits a trigger collider from "Sanity Sphere"
    private void Update()
    {
        transform.position = disappear.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "SanitySphere"){
            disappear.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "SanitySphere"){
            disappear.SetActive(true);
        }
    }
}
