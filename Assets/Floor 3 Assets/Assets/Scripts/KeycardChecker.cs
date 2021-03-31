using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeycardChecker : MonoBehaviour
{
    [SerializeField] GameObject LockedDoor;
    LockedDoor keycard;
    [SerializeField] GameObject textDisplay;
    Text text;

    public void Start()
    {
        keycard = LockedDoor.GetComponent<LockedDoor>();
        text = textDisplay.GetComponent<Text>();
    }

    public void OnMouseDown()
    {
        keycard.hasGotKeycard += 1;
        Destroy(gameObject);
    }

    void Update()
    {
        text.text = keycard.hasGotKeycard.ToString() + "/2 KEYCARDS FOUND";
    }
}
