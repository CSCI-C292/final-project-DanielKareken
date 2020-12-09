using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject musicToggleText;

    [SerializeField] RuntimeData runtimeData;

    bool musicOn;

    // Start is called before the first frame update
    void Start()
    {
        musicOn = true;
        runtimeData.musicOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (musicOn)
        {
            musicToggleText.GetComponent<Text>().text = "ON";
            musicToggleText.GetComponent<Text>().color = Color.green;
        }
        else
        {
            musicToggleText.GetComponent<Text>().text = "OFF";
            musicToggleText.GetComponent<Text>().color = Color.red;
        }
        
    }

    public void toggleMusic()
    {
        if (musicOn)
        {
            musicOn = false;
        }
        else
        {
            musicOn = true;
        }
        runtimeData.musicOn = musicOn;
    }
}
