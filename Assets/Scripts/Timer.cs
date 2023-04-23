using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float startTime;

    [HideInInspector] public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjectiveMet.finished)
        {
            currentTime -= Time.deltaTime;
        }
    }
}
