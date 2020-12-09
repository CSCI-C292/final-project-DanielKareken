using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject condtionText;

    bool allowNext;
    string cond;

    // Start is called before the first frame update
    void Start()
    {
        allowNext = false;
        cond = "";
        GameEvents.LevelComplete += OnLevelComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowNext)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }

        condtionText.GetComponent<Text>().text = cond;
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnLevelComplete(object sender, LevelEventArgs args)
    {
        print(args.condition);
        if (args.condition.Equals("timeout"))
        {
            allowNext = false;
            cond = "FAILED: Ran out of time";
        }
        else if (args.condition.Equals("complete") && SceneManager.GetActiveScene().buildIndex != 2)
        {
            allowNext = true;
            cond = "Job well done. Keep up the good work.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            allowNext = false;
            cond = "Alright, you've passed all the tests. Or did you pass ALL of them?";
        }
    }
}
