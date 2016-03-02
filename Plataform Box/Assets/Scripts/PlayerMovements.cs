using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour {


    [HideInInspector] public bool isJumping = false;

    [HideInInspector] public float moveForce = 150f;
    [HideInInspector] public float maxSpeed = 5f;
    [HideInInspector] public float jumpForce = 500f;

    private Rigidbody2D _rb2d;
    // Use this for initialization
    void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {


        

    }
    
    void FixedUpdate() {
        //lateral movements

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _rb2d.AddForce(Vector2.up * jumpForce);
            //isJumping = true;
        }

        // check if velocity is under maxSpeed
        if ( _rb2d.velocity.x < maxSpeed && Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Vector2.right give to you (1 , 0)
            _rb2d.AddForce(Vector2.right * moveForce);
        }
        if ( _rb2d.velocity.x < maxSpeed && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Vector2.right give to you (1 , 0)
            _rb2d.AddForce(Vector2.left * moveForce);
        }

    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name == "DownBorder"){
            isJumping = false;
        }
    }
}
