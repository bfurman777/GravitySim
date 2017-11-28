using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public static List<Attractor> Attractors;
	public int phase = 0; //0=place, 1=addForces, 2=actionAndControlCamera
	//arrowKeys to add force
	//thrust on your rocket?
	//online?
	//timescale?

	void Start () {
		Attractors = new List<Attractor>();
	}

	void Update () {
		
	}
}
