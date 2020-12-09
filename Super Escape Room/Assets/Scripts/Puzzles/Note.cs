using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Puzzle
{
    [SerializeField] AudioSource rustlingSound;

    public void OnMouseDown()
    {
        //visual.SetActive(false);
        GameEvents.InvokeNoteDisplay(description);
        rustlingSound.Play();
    }
}
