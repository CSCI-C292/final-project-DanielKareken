using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] RuntimeData runtimeData;

    [SerializeField] GameObject key;

    public int id;
    bool unlocked;

    // Start is called before the first frame update
    void Start()
    {
        unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (runtimeData.keysCollected[id] == key && !unlocked)
        {
            unlockDoor();
        }
        else if (runtimeData.keysCollected[id] != key)
        {
            print("This door is locked and needs a key.");
        }
    }

    public void unlockDoor()
    {
        transform.position = Vector3.up;
        unlocked = true;
    }
}
