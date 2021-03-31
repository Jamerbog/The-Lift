using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] GameObject shotgun;

    [SerializeField] AudioClip explosionSound;

    Animator shotgunAnimation;

    AudioSource audioSource;

    [SerializeField] AudioClip gunShot;

    public float targetsHit = 0;

    [SerializeField] GameObject building;

    ParticleSystem explosion;

    MeshRenderer meshRenderer;

    Collider collider;

    [SerializeField] float gunCooldown;

    [SerializeField] float soundCooldown;

    void Start()
    {
        shotgunAnimation = shotgun.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (gunCooldown > 0)
        {
            gunCooldown -= Time.deltaTime;
        }

        if (soundCooldown > 0)
        {
            soundCooldown -= Time.deltaTime;
        }

        if (gunCooldown <= 0)
        {
            shotgunAnimation.SetBool("shootMotion", false);
        }

        void Shoot()
        {

            RaycastHit hit;

            if (gunCooldown <= 0)
            {
                if (soundCooldown <= 0)
                {
                    audioSource.PlayOneShot(gunShot);
                    soundCooldown += 0.35f;
                }

                shotgunAnimation.SetBool("shootMotion", true);
                gunCooldown += 0.1f;
               
                if (Physics.Raycast(transform.position, transform.forward, out hit, 500))
                {
                    Debug.Log("You hit: " + hit.transform.gameObject.name);
                    if (hit.transform.tag == "Destroyable")
                    {
                        explosion = hit.transform.gameObject.GetComponent<ParticleSystem>();

                        if (!explosion.isPlaying)
                        {
                            explosion.Play();
                        }

                        audioSource = GetComponent<AudioSource>();

                        audioSource.PlayOneShot(explosionSound);

                        meshRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
                        collider = hit.transform.gameObject.GetComponent<CapsuleCollider>();
                        collider.enabled = false;

                        meshRenderer.enabled = false;
                        targetsHit += 1;

                    }
                }
            }

            

        }

        if (targetsHit >= 7)
        {
            destroyBuilding();
        }

        void destroyBuilding()
        {
            Destroy(building);
        }

            
    }

}



