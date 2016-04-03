using UnityEngine;
using System.Collections;

public class ParticleAccelerator : MonoBehaviour {
	public float TimeToAccelerate = 100f;
	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem> ().Simulate (TimeToAccelerate,true,false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
