using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleType { Key, Note, Button, Locked, Container, Exit }

public class Puzzle : MonoBehaviour
{
    public GameObject visual;

    //data
    public int id;
    public string description;
    public PuzzleType puzzleType;
}
