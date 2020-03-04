using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMagnet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private bool attract = false;
    public float blueStrength;

    void Start()
    {
        
        // gameObject.GetComponentInChildren<Renderer>().material.color = Color.blue;
        var a = gameObject.GetComponentsInChildren<Renderer>(); 
        foreach( Renderer r in a)
        {
            r.material.color = Color.cyan;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attract = true;
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            attract = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        
        //attract blue
        if(rb != null && attract && other.gameObject.tag == "BlueObj")
        {
            rb.AddForce((Player.transform.position - rb.transform.position)*blueStrength);
            rb.gameObject.GetComponent<BlueAsteriod>().magnetized = true;
        }

        //repel red
        if (rb != null && attract && other.gameObject.tag == "RedObj")
        {
            rb.AddForce((rb.transform.position - Player.transform.position)*blueStrength *1.5f);
            rb.gameObject.GetComponent<RedAsteriod>().magnetized = true;
        }
    }
}
