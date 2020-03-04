using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAsteriod : AsteriodBehavior
{
    // Start is called before the first frame update
    public ParticleSystem deathParticles;


    public override void Start()
    {
        startPosition = new Vector3(Random.Range(-30f, -80f), 0f, Random.Range(70f, 80f));
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        base.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "RedObj")
        {
            Destroy(true);
            if (magnetized)
            {
                particlesDestroyed++;
            }

        }

        if (collision.collider.tag == "Player")
        {
            Destroy(true);
        }

       
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void Destroy(bool particles)
    {
        if (particles)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
        }
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        base.Destroy();
    }


}
