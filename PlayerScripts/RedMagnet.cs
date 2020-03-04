using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMagnet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private bool attract = false;
    public float redStrength;

    void Start()
    {
        //set color
        var a = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in a)
        {
            r.material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attract = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            attract = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        //attract red
        if (rb != null && attract && other.gameObject.tag == "RedObj")
        {
            rb.AddForce((Player.transform.position - rb.transform.position)*redStrength);
            rb.gameObject.GetComponent<RedAsteriod>().magnetized = true;
        }

        //repel blue
        if (rb != null && attract && other.gameObject.tag == "BlueObj")
        {
            rb.AddForce((rb.transform.position - Player.transform.position)*redStrength*1.5f);
            rb.gameObject.GetComponent<BlueAsteriod>().magnetized = true;
        }
    }
}
