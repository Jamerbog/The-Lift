using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject firstPersonCharacter;

    NavMeshAgent enemy;
    AudioSource audioSource;

    Transform playerPosition;
    PageCounter pageCount;

    bool isDestroyed = false;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerPosition = player.GetComponent<Transform>();

        if (!isDestroyed)
        {
            enemy.SetDestination(playerPosition.position);
        }
    }

    public void DestroySlender()
    {
        audioSource = firstPersonCharacter.GetComponent<AudioSource>();
        audioSource.enabled = false;
        isDestroyed = true;
        enemy.enabled = false;
        transform.position = transform.position + new Vector3(-1000, -1000, -1000);
    }
}
