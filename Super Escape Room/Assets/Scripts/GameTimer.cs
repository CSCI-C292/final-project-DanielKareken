using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public RuntimeData runtimeData;

    bool gameTimerOn;

    // Start is called before the first frame update
    void Start()
    {
        gameTimerOn = true;
        GameEvents.gameTimer = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEvents.gameTimer > 0)
        {
            GameEvents.gameTimer -= Time.deltaTime * 1f;
        }
        else if (GameEvents.gameTimer <= 0 && gameTimerOn)
        {
            //end game
            gameTimerOn = false;
        }
    }
}
