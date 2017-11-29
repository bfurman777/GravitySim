using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour {

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = rb.velocity;
		var angle = (Mathf.Atan2(v.y, v.x)-90) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
