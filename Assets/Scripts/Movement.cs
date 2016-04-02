using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed = 1f;
    public float multiplier = 16f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal")*speed*multiplier,0));
		GetComponent<Animator> ().SetFloat ("Horizontal", Input.GetAxis ("Horizontal"));

	}

    public void OnHit()
    {
        GameObject.FindObjectOfType<ScoreKeeper>().OnGameEnd();
    }
}
