using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDemoMusic : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip demoClip;

    [SerializeField] GameObject C5S;
    [SerializeField] GameObject E5;
    [SerializeField] GameObject D5;
    [SerializeField] GameObject A4;
    [SerializeField] GameObject F4S;
    [SerializeField] GameObject B4;

    [SerializeField] float highlightTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(demoClip);
            Invoke("highlightC5S", 0f);
            Invoke("highlightE5", 0.7f);
            Invoke("highlightD5", 1.1f);
            Invoke("highlightC5S", 1.8f);
            Invoke("highlightA4", 2.3f);
            Invoke("highlightF4S", 2.9f);
            Invoke("highlightA4", 3.5f);
            Invoke("highlightB4", 4.3f);
            Invoke("highlightC5S", 5.4f);
            Invoke("highlightC5S", 5.9f);
            Invoke("highlightC5S", 6.4f);
            Invoke("highlightD5", 7.0f);
            Invoke("highlightC5S", 7.3f);




        }
    }

    private void highlightC5S()
    {
        C5S.SetActive(true);
        Invoke("disableHighlightC5S", 0.5f);
    }
    private void highlightE5()
    {
        E5.SetActive(true);
        Invoke("disableHighlightE5", 0.5f);
    }
    private void highlightD5()
    {
        D5.SetActive(true);
        Invoke("disableHighlightD5", 0.5f);
    }
    private void highlightA4()
    {
        A4.SetActive(true);
        Invoke("disableHighlightA4", 0.5f);
    }
    private void highlightF4S()
    {
        F4S.SetActive(true);
        Invoke("disableHighlightF4S", 0.5f);
    }
    private void highlightB4()
    {
        B4.SetActive(true);
        Invoke("disableHighlightB4", 0.5f);
    }

    private void disableHighlightE5()
    {
        E5.SetActive(false);
    }
    private void disableHighlightC5S()
    {
        C5S.SetActive(false);
    }
    private void disableHighlightD5()
    {
        D5.SetActive(false);
    }
    private void disableHighlightA4()
    {
        A4.SetActive(false);
    }
    private void disableHighlightF4S()
    {
        F4S.SetActive(false);
    }
    private void disableHighlightB4()
    {
        B4.SetActive(false);
    }


}
