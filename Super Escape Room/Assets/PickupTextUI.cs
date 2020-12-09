using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupTextUI : MonoBehaviour
{
    [SerializeField] GameObject PickupText;

    Animator anim;

    Text pickup;

    string item;
    bool active;
    

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.ItemPickup += OnItemPickup;
        anim = gameObject.GetComponent<Animator>();
        pickup = PickupText.GetComponent<Text>();
        PickupText.SetActive(false);
        item = "";
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnItemPickup(object sender, PickupEventArgs args)
    {
        if (!active)
        {
            active = true;
            item = args.item;
            pickup.text = item;
            PickupText.SetActive(true);
            anim.SetTrigger("pickup");
        }
    }

    void disableText()
    {
        PickupText.SetActive(false);
        active = false;
    }
}
