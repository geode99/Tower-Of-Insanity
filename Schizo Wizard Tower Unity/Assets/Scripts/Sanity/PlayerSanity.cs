using Unity.VisualScripting;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
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
        if(SaveDataController.Current.sanity > 0){
            SaveDataController.Current.sanity -= 0.1f * Time.deltaTime;
        }
        sanityBar.transform.localScale = new Vector3(1f, SaveDataController.Current.sanity / 40, 1f);
        sanitySphereObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        sanityRange = SaveDataController.Current.sanity * range;
        sphere.SetSphereScale(sanityRange);
    }
}
