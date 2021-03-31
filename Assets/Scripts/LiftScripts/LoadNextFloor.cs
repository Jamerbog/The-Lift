using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextFloor : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject alarm;

    [SerializeField] GameObject LeftDoor;
    [SerializeField] GameObject RightDoor;

    [SerializeField] AudioClip liftDing;
    [SerializeField] AudioClip liftMusic;

    [SerializeField] GameObject fire;
    [SerializeField] GameObject firstPersonCharacter;

    [SerializeField] GameObject finishCanvas;
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject thankYouForPlaying;
    [SerializeField] GameObject yourTime;
    [SerializeField] GameObject timerObject;
    [SerializeField] GameObject crosshair;
    timer timerClass;
    
    AudioSource soundtrack;

    [SerializeField] GameObject player;
    [SerializeField] GameObject terrain;

    Animator controlLeftDoor;
    Animator controlRightDoor;

    AudioSource audioSource;

    public bool isDoorsOpen;

    public float buttonCooldown;

    Scene currentScene;
    [SerializeField] int sceneInt;

    public void Start()
    {
       
        controlLeftDoor = LeftDoor.GetComponent<Animator>();
        controlRightDoor = RightDoor.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();

        sceneInt = currentScene.buildIndex;
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
        if (!isDoorsOpen && buttonCooldown <= 0)
        {
            openLiftDoors();
        }
        else if (isDoorsOpen && buttonCooldown <=0)
        {
            closeLiftDoors();
        }
    }

    void loadNextFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        buttonCooldown = 20f;

        if (sceneInt == 2 || sceneInt == 3)
        {
            stopSoundtrack();
        }

        if (sceneInt == 3)
        {
            Destroy(alarm);
            Destroy(canvas);
            Destroy(fire);
        }

        if (sceneInt == 4)
        {
            FindObjectOfType<PageCounter>().finishLevel();
            FindObjectOfType<SlenderController>().DestroySlender();
        }

        audioSource.PlayOneShot(liftDing);

        controlLeftDoor.SetBool("OpenLeft", false);
        controlRightDoor.SetBool("OpenRight", false);

        controlLeftDoor.SetBool("CloseLeft", true);
        controlRightDoor.SetBool("CloseRight", true);

        if (sceneInt < 5)
        {
            Invoke("loadNextFloor", 18f);
            Invoke("doorReset", 3f);
        }
        else
        {
            finishCanvas.SetActive(true);
            Invoke("spawnMenu", 1.5f);
        }

        isDoorsOpen = false;
    }

    private void spawnMenu()
    {
        audioSource.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(crosshair);
        Destroy(player);
        Invoke("displayThankYouForPlaying", 2f);

    }

    private void displayThankYouForPlaying()
    {
        thankYouForPlaying.SetActive(true);
        Invoke("displayYourTime", 2f);
    }

    private void displayYourTime()
    {
        timerClass = timerObject.GetComponent<timer>();
        timerClass.stopTimer();
        yourTime.SetActive(true);

        Invoke("displayMenuButtons", 2f);
    }

    private void displayMenuButtons()
    {
        menuButtons.SetActive(true);
    }

    void stopSoundtrack()
    {
        soundtrack = terrain.GetComponent<AudioSource>();
        if (soundtrack.isPlaying)
        {
            soundtrack.Stop();
        }
    }

    public void doorReset()
    {
        controlLeftDoor.SetBool("OpenLeft", false);
        controlRightDoor.SetBool("OpenRight", false);

        controlLeftDoor.SetBool("CloseLeft", false);
        controlRightDoor.SetBool("CloseRight", false);

        audioSource.PlayOneShot(liftMusic);
    }

    }






