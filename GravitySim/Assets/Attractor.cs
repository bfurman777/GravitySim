using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public static List<Attractor> Attractors;

    public float mass = 1;
    public float initalRotationDegreesClockwise = 0;
    public float initalVelocity = 0;

    private float G = 1f;
    private Rigidbody2D rb;
	//private GameManagerScript gameManagerScript;

    void Start()
    {
		//GameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        rb.mass = mass;
        transform.Rotate(new Vector3(0, 0, -initalRotationDegreesClockwise));
		rb.velocity = (transform.up * initalVelocity);
    }


    void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        rb = this.GetComponent<Rigidbody2D>();

        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    //add force to everyone but yourself
    void Attract(Attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}

