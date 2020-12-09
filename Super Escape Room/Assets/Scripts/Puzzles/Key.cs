using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Puzzle
{
    [SerializeField] RuntimeData runtimeData;

    [SerializeField] AudioSource keySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        visual.SetActive(false);
        runtimeData.keysCollected[id] = true;
        keySound.Play();
        GameEvents.InvokePickupItem("+ Got key");
    }
}
