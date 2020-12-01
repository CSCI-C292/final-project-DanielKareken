using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Puzzle
{
    //[SerializeField] GameObject itemStored;

    [SerializeField] RuntimeData runtimeData;

    Animator anim;

    public string password;
    bool locked;

    // Start is called before the first frame update
    void Start()
    {
        locked = true;

        GameEvents.PlayerInput += OnPlayerInput;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        //visual.SetActive(false);
        GameEvents.InvokePuzzleDisplay();
        runtimeData.currentPassword = password;
    }

    void OnPlayerInput(object sender, PuzzleEventArgs args)
    {
        print("input recieved");
        if (args.playerInput == password)
        {
            locked = false;
            anim.SetTrigger("Open");
        }
        
    }
}
