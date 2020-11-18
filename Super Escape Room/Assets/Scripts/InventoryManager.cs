using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] RuntimeData runtimeData;

    [SerializeField] GameObject inventory;

    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = inventory.GetComponentsInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //find next open slot
    /*public int getNextAvailableSlot()
    {
        int index = -1;

        for (int i = 0; i < slots.Length; i++)
        {
            if (runtimeData.inventoryItems[i] != null)
            {
                index = i;
                break;
            }
        }

        return index;
    }*/

    //add item to inventory
    /*void addItem(GameObject item)
    {
        int openSlot = getNextAvailableSlot();

        if (openSlot == -1)
        {
            print("inventory full");
            //print message for player
        }

        else
        {
            
        }
    }*/

    //remove item from inventory
    void removeItem()
    {

    }
}
