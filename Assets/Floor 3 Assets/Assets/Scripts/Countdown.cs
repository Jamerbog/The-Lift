using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject explosion1;
    [SerializeField] Text CountDown;

    [SerializeField] GameObject player;
    Transform playerPosition;

    public float timeLeft;
    float endTime;

    void Start()
    {
        timeLeft = 90f;
        endTime = 0f;
    }

    void Update()
    {
        playerPosition = player.GetComponent<Transform>();
        if (timeLeft > endTime)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= endTime)
            {
                timeLeft = endTime;
                Instantiate(explosion1, playerPosition);
                Invoke("reset", 2.5f);

            }
            print(timeLeft.ToString());
            CountDown.text = "Meltdown: " + timeLeft.ToString("0.00");
        }
    }

    void reset()
    {
        print("level reset");
        SceneManager.LoadScene(3);
    }
}
