using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookGlitch : MonoBehaviour
{
    Animator glitch;
    [SerializeField] GameObject slender;
    Transform slenderPosition;

    Animator slenderAnimation;
    AudioSource audioSource;

    float slenderDistance;
    float slenderAngle;

    public float timeLooking;
    bool caught = false;

    AudioSource glitchSound;

    void Start()
    {
        glitch = gameObject.GetComponent<Animator>();
        glitchSound = slender.GetComponent<AudioSource>();

        slenderAnimation = slender.GetComponent<Animator>();
        audioSource = slender.GetComponent<AudioSource>();
    }


    void Update()
    {
        slenderPosition = slender.GetComponent<Transform>();

        slenderDistance = Vector3.Distance(slenderPosition.position, transform.position);
        slenderAngle = Vector3.Angle(transform.forward, slenderPosition.position - transform.position);

        if (slenderDistance > 5 && slenderDistance <= 20)
        {
            slenderAnimation.SetBool("isRunning", true);
        }
        else
        {
            slenderAnimation.SetBool("isRunning", false);
        }

        if (slenderAngle < 50 && slenderDistance < 15)
        {
            glitch.SetBool("isLooking", true);
            timeLooking += Time.deltaTime;

            if (!glitchSound.isPlaying)
            {
                glitchSound.Play();
            }

            if (timeLooking > 1.5)
            {
                print("You looked too long.");
                SceneManager.LoadScene(4);
            }
        }
        else
        {
            if (!caught)
            {
                if (slenderDistance > 5 && timeLooking < 1.5 && glitchSound.isPlaying)
                {
                    glitchSound.Stop();
                }
                glitch.SetBool("isLooking", false);
                timeLooking = 0;
            }
        }

        if (slenderDistance < 5)
        {
            if (!glitchSound.isPlaying)
            {
                glitchSound.Play();
            }

            slenderAnimation.SetBool("isRunning", false);
            slenderAnimation.SetBool("isCaught", true);

            Invoke("restart", 1.5f);

            caught = true;

            glitch.SetBool("isLooking", true);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(4);
    }
}
