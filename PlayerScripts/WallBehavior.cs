using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer r = gameObject.GetComponent<Renderer>();
        if(gameObject.tag == "RedWall")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (gameObject.tag == "BlueWall")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x, 0.0f, -rb.velocity.z);
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        if(rb != null)
        {
           
         rb.velocity = (new Vector3(-rb.velocity.x, 0.0f, rb.velocity.z) );
                
               
        }

       
    }
}
