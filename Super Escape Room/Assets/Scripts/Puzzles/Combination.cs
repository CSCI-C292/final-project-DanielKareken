using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboType { Safe, Keypad }

public class Combination : Puzzle
{
    [SerializeField] RuntimeData runtimeData;

    [SerializeField] HUDAesthetic hudAesthetic;

    [SerializeField] GameObject target;

    [SerializeField] AudioSource unlockSound;

    public string password;
    public ComboType comboType;

    Animator anim;
    bool locked;

    // Start is called before the first frame update
    void Start()
    {
        locked = true;

        GameEvents.PlayerInput += OnPlayerInput;
        GameEvents.LevelComplete += OnLevelComplete;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        GameEvents.InvokePuzzleDisplay(hudAesthetic.aesthetic);
        runtimeData.currentPassword = password;
    }

    void OnPlayerInput(object sender, PuzzleEventArgs args)
    {
        if (args.playerInput == password && comboType == ComboType.Safe)
        {
            locked = false;
            anim.SetTrigger("Open");
            gameObject.layer = 2;
            unlockSound.Play();
        }

        else if (args.playerInput == password && comboType == ComboType.Keypad)
        {
            if (target.tag == "Door")
            {
                target.GetComponent<Door>().Unlock();
            }
            unlockSound.Play();
        }       
    }

    void OnLevelComplete(object sender, LevelEventArgs args)
    {
        GameEvents.PlayerInput -= OnPlayerInput;
        GameEvents.LevelComplete -= OnLevelComplete;
    }
}
