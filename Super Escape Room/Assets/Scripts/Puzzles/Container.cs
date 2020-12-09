using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Puzzle
{
    [SerializeField] AudioSource openSound;
    [SerializeField] AudioSource closeSound;

    Animator anim;
    bool open;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (open)
        {
            anim.SetTrigger("Close");
            open = false;
            closeSound.Play();
        }
        else
        {
            anim.SetTrigger("Open");
            open = true;
            openSound.Play();
        }

    }
}
