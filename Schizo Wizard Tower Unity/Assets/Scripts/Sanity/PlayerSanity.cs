using Unity.VisualScripting;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public float sanity = 100f;
    public float sanityRange;
    public float range = 1f;

    // Assign this in the Inspector
    public GameObject sanitySphereObject;
    private SanitySphere sphere;

    void Start(){
         sphere = sanitySphereObject.GetComponent<SanitySphere>();
    }

    void Update(){
        if(sanity > 0){
            sanity -= 0.1f * Time.deltaTime;
        }
        sanityRange = sanity * range;
        if(sphere != null){
            sphere.SetSphereScale(sanityRange);
        }
    }
}
