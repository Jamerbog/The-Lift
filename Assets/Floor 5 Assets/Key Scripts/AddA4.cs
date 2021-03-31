using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddA4 : MonoBehaviour
{
    [SerializeField] GameObject hintButton;
    noteChecker noteChecker;
    void Start()
    {
        noteChecker = hintButton.GetComponent<noteChecker>();
    }
    private void OnMouseDown()
    {
        noteChecker.notesPlayed += "A4";
        noteChecker.printPlayedNotes();
    }


}
