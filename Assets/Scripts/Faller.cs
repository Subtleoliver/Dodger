using UnityEngine;
using System.Collections;

public class Faller : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("OnHit",SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {
        if (transform.position.y < 0) Destroy(gameObject);
    }
}
