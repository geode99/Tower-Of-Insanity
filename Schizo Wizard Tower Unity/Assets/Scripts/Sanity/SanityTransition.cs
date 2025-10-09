using UnityEngine;

public class SanityTransition : MonoBehaviour
{
    public GameObject appear;

    // Disable this GameObject when it hits a trigger collider from "Sanity Sphere"
    private void Update()
    {
        transform.position = appear.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SanitySphere")
        {
            appear.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "SanitySphere")
        {
            appear.SetActive(false);
        }
    }
}
