using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [HideInInspector] public static int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }
}
