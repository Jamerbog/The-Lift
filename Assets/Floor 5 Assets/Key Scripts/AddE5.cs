using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddE5 : MonoBehaviour
{
    [SerializeField] GameObject hintButton;
    noteChecker noteChecker;
    void Start()
    {
        noteChecker = hintButton.GetComponent<noteChecker>();
    }
    private void OnMouseDown()
    {
        noteChecker.notesPlayed += "E5";
        noteChecker.printPlayedNotes();
    }


}
