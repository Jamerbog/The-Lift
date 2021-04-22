using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteChecker : MonoBehaviour
{
    [SerializeField] GameObject fireDoor;
    Animator fireDoorAnimator;

    [SerializeField] GameObject spotlight;
    Light lightController;

    AudioSource audioSource;
    [SerializeField] AudioClip clapping2;

    public string notesPlayed;
    bool finished = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fireDoorAnimator = fireDoor.GetComponent<Animator>();
        lightController = spotlight.GetComponent<Light>();
        audioSource.Play();
    }

    public void printPlayedNotes()
    {
        Debug.Log(notesPlayed);
        if (notesPlayed.Contains("C5#E5D5C5#A4F#A4B4C5#C5#C5#D5C5#") && finished == false)
        {
            finished = true;
            Invoke("finish", 1f);
        }
    }

    private void finish()
    {
        audioSource.PlayOneShot(clapping2);
        Debug.Log("POOOPIE WOOPIIE WOOP WOOP!!");
        spotlight.SetActive(true);
        fireDoorAnimator.SetTrigger("OpenDoor");
    }
}
