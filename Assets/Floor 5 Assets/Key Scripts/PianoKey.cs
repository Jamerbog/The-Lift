using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    [SerializeField] GameObject keyPivot;
    Animator keyAnimation;
    AudioSource audioSource;
    [SerializeField] AudioClip note;

    void Start()
    {
        keyAnimation = keyPivot.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        keyAnimation.SetTrigger("KeyPress");
        audioSource.PlayOneShot(note);
    }
}
