using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEventArgs : EventArgs
{
    public string description;
}

public class PuzzleEventArgs : EventArgs
{
    public string playerInput;
}

public class GameEvents
{
    //UI events
    public static event EventHandler<NoteEventArgs> NoteDisplay;
    public static event EventHandler<PuzzleEventArgs> PlayerInput;
    public static event EventHandler ShowPuzzleDisplay;
    public static event EventHandler DisplayHide;

    //Object broadcasts
    public static event EventHandler UnlockPuzzle;

    public static float gameTimer;

    public static void InvokeNoteDisplay(string desc)
    {
        NoteDisplay(null, new NoteEventArgs { description = desc });
    }

    public static void InvokePuzzleDisplay()
    {
        ShowPuzzleDisplay(null, EventArgs.Empty);
    }

    public static void InvokeDisplayHide()
    {
        DisplayHide(null, EventArgs.Empty);
    }

    public static void InvokeSendInput(string input)
    {
        PlayerInput(null, new PuzzleEventArgs { playerInput = input });
    }
}
