using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    public TMP_Text infectedScore;
    public TMP_Text timer;

    public ScoreTracker score;
    public Timer time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        infectedScore.text = "Infected: " + ScoreTracker.currentScore;
        timer.text = "Time Left: " + time.currentTime.ToString("F2");
    }
}
