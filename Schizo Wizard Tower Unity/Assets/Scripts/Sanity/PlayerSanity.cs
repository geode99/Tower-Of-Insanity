using Unity.VisualScripting;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public float sanity = 100f;
    public float sanityRange;
    public float range = 1f;


    // Assign this in the Inspector
    public GameObject sanitySphereObject;
    public GameObject sanityBar;
    private SanitySphere sphere;

    void Start(){
         sphere = sanitySphereObject.GetComponent<SanitySphere>();
    }

    void Update(){
        if(sanity > 0){
            sanity -= 0.1f * Time.deltaTime;
        }
        sanityBar.transform.localScale = new Vector3(1f, sanity/40, 1f);
        sanitySphereObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        sanityRange = sanity * range;
        sphere.SetSphereScale(sanityRange);
    }
}
