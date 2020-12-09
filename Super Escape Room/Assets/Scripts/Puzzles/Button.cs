using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Puzzle
{
    [SerializeField] AudioSource pushSound;

    [SerializeField] GameObject target;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        anim.SetTrigger("Pushed");
        pushSound.Play();
        gameObject.layer = 2;

        if (target.CompareTag("Player"))
        {
            target.GetComponent<Player>().teleport();
        }

        else if (target.tag == "Door")
        {
            target.GetComponent<Door>().Unlock();
        }
    }
}
