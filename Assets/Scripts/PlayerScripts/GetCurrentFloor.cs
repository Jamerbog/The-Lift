using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCurrentFloor : MonoBehaviour
{

    public static int currentFloor;

    void Start()
    {
        currentFloor = SceneManager.GetActiveScene().buildIndex;
    }
}
