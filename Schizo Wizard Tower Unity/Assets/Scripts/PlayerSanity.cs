using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public float sanity = 100f;
    public float sanityRange = 1f;
    public float range = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sanity -= 0.05f * Time.deltaTime;
        sanityRange = sanity*range;
    }
}
