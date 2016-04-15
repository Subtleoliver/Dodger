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
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxisRaw("Horizontal")*speed*multiplier,0));

		Quaternion oldRotation = gameObject.transform.rotation;
		if (Input.GetAxisRaw ("Horizontal") > 0.1) {
			Quaternion newRotation = Quaternion.Euler (0f, -50f, 0f);
			gameObject.transform.rotation = Quaternion.LerpUnclamped (oldRotation, newRotation, Time.deltaTime * 1f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0.1) {
			Quaternion newRotation = Quaternion.Euler (0f, 50f, 0f);
			gameObject.transform.rotation = Quaternion.LerpUnclamped (oldRotation, newRotation, Time.deltaTime * 1f);
		}
		if (!Input.GetButton ("Horizontal")) {
			Quaternion newRotation = Quaternion.Euler (0f, 0f, 0f);
			gameObject.transform.rotation = Quaternion.LerpUnclamped (oldRotation, newRotation, Time.deltaTime * 1f);
		}
	}

    public void OnHit()
    {
        GameObject.FindObjectOfType<ScoreKeeper>().OnGameEnd();
    }
}
