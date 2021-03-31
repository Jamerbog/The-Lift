using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddB4 : MonoBehaviour
{
    [SerializeField] GameObject hintButton;
    noteChecker noteChecker;
    void Start()
    {
        noteChecker = hintButton.GetComponent<noteChecker>();
    }
    private void OnMouseDown()
    {
        noteChecker.notesPlayed += "B4";
        noteChecker.printPlayedNotes();
    }


}
