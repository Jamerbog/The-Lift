using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticLift : MonoBehaviour
{
    [SerializeField] GameObject LeftDoor;
    [SerializeField] GameObject RightDoor;

    Animator controlLeftDoor;
    Animator controlRightDoor;

    AudioSource audioSource;
    [SerializeField] AudioClip negativeFeedback;

    public bool isDoorsOpen;

    [SerializeField] float buttonCooldown;

    public void Start()
    {
        controlLeftDoor = LeftDoor.GetComponent<Animator>();
        controlRightDoor = RightDoor.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Invoke("openLiftDoors", 0.5f);
    }

    private void Update()
    {
        if (buttonCooldown > 0)
        {
            buttonCooldown -= Time.deltaTime;
        }
    }

    public void OnMouseDown()
    {
        audioSource.PlayOneShot(negativeFeedback);
    }

    public void openLiftDoors()
    {
        buttonCooldown = 3f;

        controlLeftDoor.SetBool("OpenLeft", true);
        controlRightDoor.SetBool("OpenRight", true);

        controlLeftDoor.SetBool("CloseLeft", false);
        controlLeftDoor.SetBool("CloseLeft", false);

        isDoorsOpen = true;
    }

    public void closeLiftDoors()
    {
        buttonCooldown = 3f;

        controlLeftDoor.SetBool("OpenLeft", false);
        controlRightDoor.SetBool("OpenRight", false);

        controlLeftDoor.SetBool("CloseLeft", true);
        controlRightDoor.SetBool("CloseRight", true);

        isDoorsOpen = false;
    }






}
