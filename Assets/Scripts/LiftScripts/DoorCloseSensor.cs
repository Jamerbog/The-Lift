using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseSensor : MonoBehaviour
{
    [SerializeField] GameObject button;
    StaticLift closeLiftDoor; 

    void Start()
    {
        closeLiftDoor = button.GetComponent<StaticLift>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("It worked!");
            closeLiftDoor.closeLiftDoors();
        }
    }
}
