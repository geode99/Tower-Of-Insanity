using UnityEngine;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    public float sanityRange;
    public float range = 1f;


    // Assign this in the Inspector
    public GameObject sanitySphereObject;
    public Image sanityBar;
    private SanitySphere sphere;

    void Start(){
         sphere = sanitySphereObject.GetComponent<SanitySphere>();
    }

    void Update(){
        if(SaveDataController.Current.sanity > 0){
            SaveDataController.Current.sanity -= 0.1f * Time.deltaTime;
        }
        sanitySphereObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        sanityBar.fillAmount = SaveDataController.Current.sanity / 40f;

        sanityRange = SaveDataController.Current.sanity * range;
        sphere.SetSphereScale(sanityRange);
    }
}
