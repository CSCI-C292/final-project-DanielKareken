using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableShelf : Puzzle
{
    [SerializeField] AudioSource slidingSound;

    Animator anim;
    bool open;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HandleMouseDown()
    {
        print("handling");
        if (!open)
        {
            anim.SetTrigger("Open");
            open = true;
            slidingSound.Play();
        }

    }
}
