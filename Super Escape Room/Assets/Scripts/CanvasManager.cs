using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject Crosshair;

    [SerializeField] NoteUI NoteUI;

    [SerializeField] CombinationUI ComboUI;

    [SerializeField] RuntimeData runtimeData;

    // Start is called before the first frame update
    void Start()
    {
        NoteUI.gameObject.SetActive(false);
        ComboUI.gameObject.SetActive(false);

        GameEvents.NoteDisplay += OnNotePickup;
        GameEvents.ShowPuzzleDisplay += OnPuzzleDisplay;
        GameEvents.DisplayHide += OnDisplayHide;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnNotePickup(object sender, NoteEventArgs args)
    {
        NoteUI.gameObject.SetActive(true);
        NoteUI.updateText(args.description);
    }

    void OnPuzzleDisplay(object sender, EventArgs args)
    {
        ComboUI.gameObject.SetActive(true);
    }

    void OnDisplayHide(object sender, EventArgs args)
    {
        ComboUI.gameObject.SetActive(false);
        NoteUI.gameObject.SetActive(false);
    }
}
