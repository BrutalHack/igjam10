using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextScene = "Demo";

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
