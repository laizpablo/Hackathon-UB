using UnityEngine;
using System.Collections;

public class man : MonoBehaviour {

    private const int STOP_ANIMATION = 0;
    private const int WALK_ANIMATION = 1;
    private const int RUN_ANIMATION = 2;

    Animator _animator;


	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)){
            Debug.Log("walk_animation");
            _animator.SetInteger("State", WALK_ANIMATION);
        }
        if (Input.GetKey(KeyCode.R)){
            Debug.Log("run_animation");
            _animator.SetInteger("State", RUN_ANIMATION);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("stop_animation");
            _animator.SetInteger("State", STOP_ANIMATION);
        }
    }
}
