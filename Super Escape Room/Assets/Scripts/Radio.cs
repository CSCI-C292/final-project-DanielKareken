using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource click;

    [SerializeField] RuntimeData runtimeData;

    [SerializeField] GameObject player;

    bool on;
    bool disable;

    // Start is called before the first frame update
    void Start()
    { 
        if (runtimeData.musicOn)
        {
            on = true;
            music.Play();
        }
        else
        {
            on = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        disable = player.GetComponent<Player>().locked;
    }

    void OnMouseDown()
    {
        if (!disable)
        {
            if (on)
            {
                music.Stop();
                on = false;
            }   
            else
            {
                music.Play();
                on = true;
            }

            click.Play();
        }
    }
}
