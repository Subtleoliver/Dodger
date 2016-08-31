using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed = 100f;

    public float rotationThreshold = 10f;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector2(getMovementFromGyro(),0f));
    }

    public float getMovementFromGyro()
    {
        Input.gyro.enabled = true;
        return ((Input.gyro.attitude.eulerAngles.x-180)/360) * speed * 2;
    }

    public void OnHit()
    {
        GameObject.FindObjectOfType<ScoreKeeper>().OnGameEnd();
    }

    public void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(Screen.width / 10f);
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Gyro: " + (Input.gyro.attitude.eulerAngles.ToString()));
    }
}
