using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Loading Scene " + SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }
}
