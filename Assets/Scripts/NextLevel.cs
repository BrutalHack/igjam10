using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int nextSceneId = 1;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextSceneId);
    }
}
