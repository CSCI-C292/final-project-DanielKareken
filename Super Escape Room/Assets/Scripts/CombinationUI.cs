using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationUI : MonoBehaviour
{
    [SerializeField] GameObject outputText;

    [SerializeField] RuntimeData runtimeData;

    string input = "";

    private void Update()
    {
        outputText.GetComponent<Text>().text = input;
    }

    public void buttonPressed(string value)
    {
        if (input.Length != runtimeData.currentPassword.Length)
        {
            input += value;
            //runtimeData.playerInput += value;
        }
    }

    public void submit()
    {
        GameEvents.InvokeSendInput(input);

    }
}
