using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PageCounter : MonoBehaviour
{
    [SerializeField] GameObject displayUI;
    public int pageCount = 0;

    RaycastHit hit;
    MeshRenderer meshRenderer;

    Collider collider;
    Light light;

    [SerializeField] GameObject flashlight;

    Text pageDisplay;
    AudioSource audioSource;

    [SerializeField] AudioClip pageSound;
    [SerializeField] GameObject terrain;

    [SerializeField] GameObject spotlight;
  
    bool scarierMusic = false;
    Transform liftTransform;

    [SerializeField] GameObject staticLift;
    [SerializeField] GameObject upLift;

    [SerializeField] bool liftExists = false;

    [SerializeField] GameObject slender;
    NavMeshAgent slenderNavigation;

    [SerializeField] GameObject blocker;
    

    void Start()
    {
        liftTransform = staticLift.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
            {
                Debug.Log("You hit: " + hit.transform.gameObject.name);

                if (hit.transform.tag == "Page")
                {
                    meshRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
                    collider = hit.transform.gameObject.GetComponent<Collider>();
                    audioSource = GetComponent<AudioSource>();
                    light = hit.transform.gameObject.GetComponent<Light>();

                    audioSource.PlayOneShot(pageSound);
                    collider.enabled = false;
                    meshRenderer.enabled = false;

                    light.enabled = false;
                    pageCount += 1;
                }
            }

        }
        pageDisplay = displayUI.GetComponent<Text>();
        pageDisplay.text = pageCount.ToString() + "/6 pages found";

        //this code stops the soundtrack playing on the terrain, and changes the audioSource variable to the one attached to the firstpersoncharacter (the one with the scarier music). 

        if (pageCount >= 5 && !scarierMusic)
        {
            audioSource = terrain.GetComponent<AudioSource>();
            audioSource.Stop();

            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            scarierMusic = true;

            slenderNavigation = slender.GetComponent<NavMeshAgent>();
            slenderNavigation.speed = 4;
            
        }

        if (pageCount >= 6 && !liftExists)
        {
            EnableFinish();
        }
    }

    private void EnableFinish()
    {
        Destroy(staticLift);
        Instantiate(upLift, liftTransform.position, liftTransform.rotation);
        spotlight.SetActive(true);
        liftExists = true;
    }

    public void finishLevel()
    {
        displayUI.SetActive(false);
        Destroy(flashlight);
        blocker.SetActive(true);
        
    }

}
