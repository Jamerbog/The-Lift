using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddD5 : MonoBehaviour
{
    [SerializeField] GameObject hintButton;
    noteChecker noteChecker;
    void Start()
    {
        noteChecker = hintButton.GetComponent<noteChecker>();
    }
    private void OnMouseDown()
    {
        noteChecker.notesPlayed += "D5";
        noteChecker.printPlayedNotes();
    }


}
