using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour {

	private Rigidbody2D rb;

	private bool justChangedTimeScale = false;	//account for the first frame turing the rocket wrong direction
	private int frameWhenTimeScaleChanged = 0;


	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame, even when timescale is 0			//FIX!!!!!!!!!!!!
	void Update () {
		if (Time.timeScale != 0) {
			print (justChangedTimeScale + " " + frameWhenTimeScaleChanged + Time.frameCount);
			if (!justChangedTimeScale && Time.frameCount > 0) {	//5 frames after
				justChangedTimeScale = true;
				frameWhenTimeScaleChanged = Time.frameCount;
				return;
			}
				
			Vector2 v = rb.velocity;
			var angle = (Mathf.Atan2(v.y, v.x)-90) * Mathf.Rad2Deg;

			if (Time.frameCount > frameWhenTimeScaleChanged + 5) {
				transform.rotation = Quaternion.AngleAxis (angle + 20, Vector3.forward);
			}
				

		}
	}
}
