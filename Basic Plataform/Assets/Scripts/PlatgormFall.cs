using UnityEngine;
using System.Collections;

public class PlatgormFall : MonoBehaviour {

    public float fallDelay = 1f;

    private Rigidbody2D _rb2d;

    // Use this for initialization
    void Start () {

        _rb2d = GetComponent<Rigidbody2D>();

    }
	

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            // Its like a sleep in C, but calling a function
            Invoke("Fall", fallDelay);
        }
    }

    void Fall()
    {
        _rb2d.isKinematic = false;
    }
}
