using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New RuntimeData")]

public class RuntimeData : ScriptableObject
{
    public bool[] keysCollected;
    public string currentPassword;

    //public GameplayState CurrentGameplayState;
}
