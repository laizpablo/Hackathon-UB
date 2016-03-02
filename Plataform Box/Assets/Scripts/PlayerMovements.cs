using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour {


    [HideInInspector] public bool isJumping = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 500f;

    private Rigidbody2D _rb2d;
    // Use this for initialization
    void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
            _rb2d.AddForce(Vector2.up * jumpForce);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            _rb2d.AddForce(Vector2.right * moveForce);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            _rb2d.AddForce(Vector2.left * moveForce);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name == "DownBorder"){
            Debug.Log("DownBorder");
            isJumping = false;
        }
    }
}
