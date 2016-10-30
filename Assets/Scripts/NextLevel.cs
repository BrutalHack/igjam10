using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Loading Scene " + SceneManager.GetActiveScene().buildIndex + 1);
        int nextSceneId = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneId >= SceneManager.sceneCount)
        {
            nextSceneId = 0;
        }
        SceneManager.LoadScene(nextSceneId);
    }
}
