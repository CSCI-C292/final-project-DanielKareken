using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType { Key, Button, Keypad, None }

public class Door : Puzzle
{
    [SerializeField] RuntimeData runtimeData;

    [SerializeField] AudioSource slidingSound;

    public TriggerType triggerType;

    Animator anim;
    bool unlocked;
    bool open;

    // Start is called before the first frame update
    void Start()
    {
        if (puzzleType == PuzzleType.Locked)
        {
            unlocked = false;
        }
        else
        {
            unlocked = true;
        }

        anim = gameObject.GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        unlocked = true;
    }

    public void OnMouseDown()
    {
        //regular door
        if (puzzleType != PuzzleType.Locked)
        {
            OpenDoor();
        }

        else
        {
            //key door
            if (triggerType == TriggerType.Key)
            {
                if (runtimeData.keysCollected[id] && !unlocked)
                {
                    OpenDoor();
                    unlocked = true;
                }
                else if (!unlocked)
                {
                    GameEvents.InvokePickupItem("This door is locked. Find the key.");
                }
            }

            //combo door
            else if (triggerType == TriggerType.Keypad)
            {
                if (!unlocked)
                {
                    GameEvents.InvokePickupItem("This door is locked. Find the keypad and enter the password.");
                }
                else
                {
                    OpenDoor();
                }
            }

            //button door
            else if (triggerType == TriggerType.Button)
            {
                if (!unlocked)
                {
                    GameEvents.InvokePickupItem("This door is locked. Find the button.");
                }
                else
                {
                    OpenDoor();
                }
            }

            else
            {
                print("Wrong case");
            }
        }        
    }

    public void OpenDoor()
    { 
        if (!open)
        {
            anim.SetTrigger("Open");
            open = true;
        }
        else
        {
            anim.SetTrigger("Closed");
            open = false;
        }
        slidingSound.Play();
    }
}
