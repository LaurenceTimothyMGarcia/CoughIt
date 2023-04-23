using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // Speed elevator goes up
    public float repelSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        float mass = col.gameObject.GetComponent<Rigidbody>().mass;
        col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, repelSpeed * mass, 0), ForceMode.Impulse);
        FindObjectOfType<AudioManager>().Play("Boing");
    }
}
