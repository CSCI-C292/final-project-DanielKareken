using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationUI : MonoBehaviour
{
    [SerializeField] GameObject outputText;
    [SerializeField] GameObject imageUI;

    [SerializeField] RuntimeData runtimeData;

    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource denySound;

    string input = "";
    bool audioOn;

    private void Start()
    {
        GameEvents.ShowPuzzleDisplay += OnPuzzleDisplay;
        GameEvents.DisplayHide += OnDisplayHide;
        GameEvents.LevelComplete += OnLevelComplete;

        audioOn = true;
    }

    private void Update()
    {
        outputText.GetComponent<Text>().text = input;
        
    }

    public void buttonPressed(string value)
    {
        if (input.Length <= 6)
        {
            input += value;
        }

        buttonSound.Play();
    }

    public void submit()
    {
        GameEvents.InvokeSendInput(input);

        if (input == runtimeData.currentPassword)
        {
            correctSound.Play();
        }
        else
        {
            denySound.Play();
        }

        input = "";
    }

    public void clear()
    {
        input = "";
    }

    void OnPuzzleDisplay(object sender, DisplayImageEventArgs args)
    {
        imageUI.GetComponent<Image>().sprite = args.image;
        audioOn = true;
    }

    void OnLevelComplete(object sender, LevelEventArgs args)
    {
        GameEvents.ShowPuzzleDisplay -= OnPuzzleDisplay;
        GameEvents.LevelComplete -= OnLevelComplete;
    }

    void OnDisplayHide(object sender, EventArgs args)
    {
        audioOn = false;
    }
}
