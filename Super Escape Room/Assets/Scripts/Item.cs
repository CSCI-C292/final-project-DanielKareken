using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Key, Note, Button }

public class Item : MonoBehaviour
{
    [SerializeField] RuntimeData runtimeData;

    public GameObject visual;

    //data
    public int id;
    public string description;
    public ItemType type;

    public void OnMouseDown()
    {
        visual.SetActive(false);
        runtimeData.keysCollected[id] = this.gameObject;
    }

}
