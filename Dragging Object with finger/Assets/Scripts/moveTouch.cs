using UnityEngine;
using System.Collections;

public class moveTouch : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        speed = 0.02f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.touchCount == 1)
        {
            transform.Translate(Input.touches[0].deltaPosition.x * speed, Input.touches[0].deltaPosition.y * speed,0);
        }
	}
}
