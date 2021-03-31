using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] GameObject LeftDoor;
    [SerializeField] GameObject RightDoor;
    [SerializeField] KeycardChecker Keycard;

    AudioSource audiosource;
    public AudioClip doorSoundEffect;

    Animator controlLeftDoor;
    Animator controlRightDoor;

    public int hasGotKeycard;
    public bool isDoorsOpen;

    [SerializeField] float buttonCooldown;

    public void Start()
    {
        controlLeftDoor = LeftDoor.GetComponent<Animator>();
        controlRightDoor = RightDoor.GetComponent<Animator>();
        Keycard = GetComponent<KeycardChecker>();
        audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (buttonCooldown > 0)
        {
            buttonCooldown -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasGotKeycard >= 2)
        {
            openLiftDoors();
        }
    }

    public void OnMouseDown()
    {
        if (!isDoorsOpen && buttonCooldown <= 0)
        {
            openLiftDoors();
        }
        else if (isDoorsOpen && buttonCooldown <= 0)
        {
            closeLiftDoors();
        }
    }

    public void openLiftDoors()
    {
        buttonCooldown = 3f;

        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(doorSoundEffect);
        }

        controlLeftDoor.SetBool("OpenLeft", true);
        controlRightDoor.SetBool("OpenRight", true);

        controlLeftDoor.SetBool("CloseLeft", false);
        controlLeftDoor.SetBool("CloseLeft", false);

        isDoorsOpen = true;
    }

    public void closeLiftDoors()
    {
        buttonCooldown = 5f;

        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(doorSoundEffect);
        }

        controlLeftDoor.SetBool("OpenLeft", false);
        controlRightDoor.SetBool("OpenRight", false);

        controlLeftDoor.SetBool("CloseLeft", true);
        controlRightDoor.SetBool("CloseRight", true);
        Invoke("doorReset", 3f);

        isDoorsOpen = false;
    }

    public void doorReset()
    {
        controlLeftDoor.SetBool("OpenLeft", false);
        controlRightDoor.SetBool("OpenRight", false);

        controlLeftDoor.SetBool("CloseLeft", false);
        controlRightDoor.SetBool("CloseRight", false);
    }

    //autoCloseLiftDoors() closes lift doors without loading next level
    public void autoCloseLiftDoors()
    {
        buttonCooldown = 5f;

        controlLeftDoor.SetBool("OpenLeft", false);
        controlRightDoor.SetBool("OpenRight", false);

        controlLeftDoor.SetBool("CloseLeft", true);
        controlRightDoor.SetBool("CloseRight", true);

        Invoke("doorReset", 3f);

        isDoorsOpen = false;
    }


}
