using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Target indicator;

    private bool isInfected;

    // Start is called before the first frame update
    void Start()
    {
        indicator.SetColor(Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "NPC") && !isInfected)
        {
            isInfected = true;
            indicator.SetColor(Color.green);
            Debug.Log("Infected");
        }
    }
}
