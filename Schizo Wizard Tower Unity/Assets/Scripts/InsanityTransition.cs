using UnityEngine;

public class InsanityTransition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    // Disable this GameObject when it hits a trigger collider from "Sanity Sphere"
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "SanitySphere"){
            gameObject.SetActive(false);
        }
    }
}
