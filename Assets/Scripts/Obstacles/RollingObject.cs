using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingObject : MonoBehaviour
{
    // How fast object rolls
    public float rollSpeed;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3 playerDir = col.transform.position - new Vector3(rb.transform.position.x, col.transform.position.y, rb.transform.position.z);
            playerDir = playerDir.normalized;
            rb.AddForce((playerDir * rollSpeed), ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Metal");
        }
    }
}
