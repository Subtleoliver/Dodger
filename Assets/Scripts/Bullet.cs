using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed = 12f;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
			Destroy (other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= 10)
			Destroy (gameObject);

		transform.Translate (Vector3.up * speed * Time.deltaTime);

	}
}
