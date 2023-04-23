using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    [Header("Play UI")]
    public GameObject playScreen;
    public TMP_Text infectedScore;
    public TMP_Text timer;

    [Header("Game Complete Screen")]
    public GameObject finishScreen;
    public TMP_Text finishPrompt;
    public TMP_Text finishInfect;
    public TMP_Text finishTimer;

    [Header("Trackers")]
    public ScoreTracker score;
    public Timer time;

    // Start is called before the first frame update
    void Start()
    {
        playScreen.SetActive(true);
        finishScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (time.currentTime <= 0)
        {
            finishPrompt.text = "Infection Failed";
            ObjectiveMet.finished = true;
        }

        if (!ObjectiveMet.finished)
        {
            infectedScore.text = "Infected: " + ScoreTracker.currentScore;
            timer.text = "Time Left: " + time.currentTime.ToString("F2");
        }
        else
        {
            finishInfect.text = infectedScore.text;
            finishTimer.text = timer.text;

            playScreen.SetActive(false);
            finishScreen.SetActive(true);
        }
    }
}
