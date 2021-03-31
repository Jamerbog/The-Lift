using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDemoMusic : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip demoClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(demoClip);
        }
    }


}
