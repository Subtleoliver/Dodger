using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public float reloadTime = 5f;
	public float timeLeft = 0f;

	public int maxAmmo = 1;
	public int ammo = 1;

	GameObject bullet;
	Texture bulletTex;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<GameObject> ("Bullet");
		bulletTex = bullet.GetComponent<SpriteRenderer> ().sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && ammo > 0) {

			//Create Object.
			GameObject.Instantiate(bullet,new Vector3(transform.position.x,transform.position.y + 0.5f),Quaternion.identity);

			timeLeft = reloadTime;
			ammo -= 1;
		}

		if (timeLeft > 0f)
			timeLeft -= Time.deltaTime;
		else if (ammo < maxAmmo)
			ammo = maxAmmo;
			
	}
		
	float GetImageSize(){
		return Screen.width / 50f;
	}

	void OnGUI(){
		float size = GetImageSize ();
		for(int i = 0; i < ammo; i++)GUI.DrawTexture (new Rect (size*i, 0, size, size), bulletTex);
	}
}
