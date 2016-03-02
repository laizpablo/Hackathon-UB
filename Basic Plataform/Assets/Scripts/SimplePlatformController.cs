using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

    //HideInInspector: Makes a variable not show up in the inspector but be serialized.
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private bool _grounded = false;
    // Save reference to animator
    private Animator _anim; // Interface to control the Mecanim animatino system
    private Rigidbody2D _rb2d; // Rigidbody2D physics component for 2D sprites


    // Use this for initialization
    void Start () {
        // Init objects
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
        // Jump action
        // Physics2D.Linecast - Returns true if there is any collider intersecting the line between start and end

        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && _grounded){
            jump = true;
        }
    }

    // Fisics rules
    void FixedUpdate(){
        //lateral movements
        float h = Input.GetAxis("Horizontal");

        _anim.SetFloat("Speed", Mathf.Abs(h));

        // check if velocity is under maxSpeed
        if (h * _rb2d.velocity.x < maxSpeed)
            //Vector2.right give to you (1 , 0)
            _rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(_rb2d.velocity.x) > maxSpeed)
            _rb2d.velocity = new Vector2(Mathf.Sign(_rb2d.velocity.x) * maxSpeed, _rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump){
            _anim.SetTrigger("Jump");
            _rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    // Flip (donar la volta) animation
    void Flip(){
        facingRight = !facingRight;
        // Vector3 give you a three components vector
        Vector3 theScale = transform.localScale;
        // we change the direction from x axis
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
