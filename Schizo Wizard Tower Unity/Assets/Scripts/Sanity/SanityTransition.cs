using UnityEngine;

public class SanityTransition : MonoBehaviour
{
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    // Disable this GameObject when it hits a trigger collider from "Sanity Sphere"
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "SanitySphere"){
            gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
            gameObject.SetActive(false);
    }
}
