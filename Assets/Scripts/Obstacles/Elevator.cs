using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Speed elevator goes up
    public float elevatorSpeed;
    // Height elevator goes up to
    public float elevatorHeight;

    public Rigidbody rb;

    private bool isFlying;

    // Start is called before the first frame update
    void Start()
    {
        isFlying = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y == 0)
        {
            isFlying = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && !isFlying)
        {
            rb.AddForce(new Vector3(0, elevatorSpeed, 0), ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Elevator");
            isFlying = true;
        }
    }
}
