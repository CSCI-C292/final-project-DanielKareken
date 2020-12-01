using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour
{
    [SerializeField] GameObject text;

    public void updateText(string description)
    {
        text.GetComponent<Text>().text = description;
    }
}
