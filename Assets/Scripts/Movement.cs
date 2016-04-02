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
        if (Input.GetButton("Horizontal"))
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal")*speed*multiplier,0));

	}

    public void OnHit()
    {
        GameObject.FindObjectOfType<ScoreKeeper>().OnGameEnd();
    }
}
