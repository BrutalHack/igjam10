﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        int nextSceneId = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneId >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneId = 0;
        }
        SceneManager.LoadScene(nextSceneId);
    }
}