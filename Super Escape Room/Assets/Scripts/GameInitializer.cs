using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] RuntimeData runtimeData;

    // Start is called before the first frame update
    void Start()
    {
        int length = runtimeData.keysCollected.Length;
        for (int i = 0; i < length; i++)
        {
            runtimeData.keysCollected[i] = false;
        }

        runtimeData.currentPassword = "";        
    }

}
