using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSensor : MonoBehaviour
{
    [SerializeField] GameObject Button;
    LoadNextFloor openLiftDoor;
    private void Start()
    {
        openLiftDoor = Button.GetComponent<LoadNextFloor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            openLiftDoor.openLiftDoors();
        }
    }
}
