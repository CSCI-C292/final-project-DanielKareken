using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Key, Note, Button, LockedContainer, Container }

public class Puzzle : MonoBehaviour
{
    public GameObject visual;

    //data
    public int id;
    public string description;
    public ItemType type;
}
