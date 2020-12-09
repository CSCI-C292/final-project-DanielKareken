using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour
{
    [SerializeField] GameObject text;

    private void Start()
    {
        GameEvents.NoteDisplay += OnNotePickup;
        GameEvents.LevelComplete += OnLevelComplete;
    }

    public void OnNotePickup(object sender, NoteEventArgs args)
    {
        text.GetComponent<Text>().text = args.description;
    }

    void OnLevelComplete(object sender, LevelEventArgs args)
    {
        GameEvents.NoteDisplay -= OnNotePickup;
        GameEvents.LevelComplete -= OnLevelComplete;
    }
}
