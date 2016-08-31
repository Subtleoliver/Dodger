using UnityEngine;
using System.Collections;

public class Faller : MonoBehaviour {
	public float fallSpeed = 16f;
    void OnTriggerEnter(Collider other)
    {
        other.SendMessageUpwards("OnHit",SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {
        if (transform.position.y < -2) Destroy(gameObject);
        
		transform.Translate (Vector3.down * fallSpeed * Time.deltaTime);
    }
}
