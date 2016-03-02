using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

    public float jumpHeight=500;
    public bool isJumping = false;

    private Rigidbody2D _rb2d; // Rigidbody2D physics component for 2D spritess

    // Use this for initialization
    void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
        Debug.Log("Start");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            _rb2d.AddForce(Vector2.up * jumpHeight);
            isJumping = true;
        }
	
	}

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("collison");
        if(col.gameObject.tag == "Ground"){
            isJumping = false;
        }
    }

}
