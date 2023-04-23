using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveMet : MonoBehaviour
{
    public static bool finished;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    void Update()
    {
        if (finished)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            finished = true;
        }
    }
}
