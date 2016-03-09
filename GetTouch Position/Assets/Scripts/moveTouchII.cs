using UnityEngine;
using System.Collections;

public class moveTouchII : MonoBehaviour {

    private Touch _touch;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        _touch = Input.GetTouch(0);
        float x = -7.5f + 16*_touch.position.x /Screen.width;
        float y = -4.5f + 16 * _touch.position.y / Screen.height;
        transform.position = new Vector3(x, y, 0);
    }
}
