using UnityEngine;

public class SanitySphere : MonoBehaviour
{
    // Call this method from another script to resize the sphere
    public void SetSphereScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }
}
