using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForces : MonoBehaviour {

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();


		rb.AddForce (transform.up*77);
	}

	// Update is called once per frame
	void FixedUpdate () {

		GameObject[] gravitationalObjects = GameObject.FindGameObjectsWithTag("ObjectWithMass");

		foreach (GameObject gravityObject in gravitationalObjects) {

			if (gravityObject.name != this.name) {
				
				Vector2 diff = gravityObject.transform.position - transform.position;

				//m1*m2/distance, avoid divide by zero
				float gravitationalForceMagnitude = (rb.mass * gravityObject.GetComponent<Rigidbody2D>().mass) / (diff.magnitude);

				rb.AddForce(diff.normalized * gravitationalForceMagnitude);	//gravitationalForceMagnitude

			}
			

		}

	}
}
