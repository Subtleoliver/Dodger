using UnityEngine;
using System.Collections;

public class Faller : MonoBehaviour {
	public float fallSpeed = 16f;
    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("OnHit",SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {
        if (transform.position.y < -2) Destroy(gameObject);

		transform.Translate (Vector3.down * fallSpeed * Time.deltaTime);
    }
}
