using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public SaveDataController saveDataController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HELLO HELLO");

        if(collision.gameObject.tag == "Player")
        {
           
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        saveDataController.SaveGame();
    }
}
