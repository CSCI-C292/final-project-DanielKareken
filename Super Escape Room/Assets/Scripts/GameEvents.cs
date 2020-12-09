using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEventArgs : EventArgs
{
    public string description;
}

public class DisplayImageEventArgs : EventArgs
{
    public Sprite image;
}

public class PuzzleEventArgs : EventArgs
{
    public string playerInput;
}

public class LevelEventArgs : EventArgs
{
    public string condition;
}

public class PickupEventArgs : EventArgs
{
    public string item;
}

public class GameEvents
{
    //UI events
    public static event EventHandler<NoteEventArgs> NoteDisplay;
    public static event EventHandler<DisplayImageEventArgs> ShowPuzzleDisplay;
    public static event EventHandler<PuzzleEventArgs> PlayerInput;
    public static event EventHandler DisplayHide;
    public static event EventHandler<LevelEventArgs> LevelComplete;
    public static event EventHandler<PickupEventArgs> ItemPickup;

    //Object broadcasts
    public static event EventHandler UnlockPuzzle;

    public static float gameTimer;

    public static void InvokeNoteDisplay(string desc)
    {
        NoteDisplay(null, new NoteEventArgs { description = desc });
    }

    public static void InvokePuzzleDisplay(Sprite img)
    {
        ShowPuzzleDisplay(null, new DisplayImageEventArgs { image = img });
    }

    public static void InvokeDisplayHide()
    {
        DisplayHide(null, EventArgs.Empty);
    }

    public static void InvokeSendInput(string input)
    {
        PlayerInput(null, new PuzzleEventArgs { playerInput = input });
    }

    public static void InvokeLevelOver(string cond)
    {
        LevelComplete(null, new LevelEventArgs { condition = cond });
    }

    public static void InvokePickupItem(string obj)
    {
        ItemPickup(null, new PickupEventArgs { item = obj });
    }
}
