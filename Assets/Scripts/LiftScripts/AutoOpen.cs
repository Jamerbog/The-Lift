using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AutoOpen : MonoBehaviour
{
    Scene currentScene;
    int sceneInt;

    LoadNextFloor doorControls;
    bool doorsOpen = false;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        doorControls = GetComponent<LoadNextFloor>();
        sceneInt = currentScene.buildIndex;
    }

    void Update()
    {
        if (sceneInt == 4 && !doorsOpen)
        {
            doorControls.openLiftDoors();
            doorsOpen = true;
        }
    }

}
