using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject claw; // where we will save the reference to the claw (gancho)
    public bool isShooting; // True when we shoot
    public Animator minerAnimator;
    //public Claw clawScript;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && !isShooting){
            LaunchClaw();
        }
    }

    void LaunchClaw(){
        isShooting = true;
        minerAnimator.speed = 0;
        RaycastHit hit; //Structure used to get information back raycast
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, out hit, 100))
        {
            claw.SetActive(true);
            //clawScript.ClawTarget(hit.point);
        }
    }

    public void CollectedObject()
    {
        isShooting = false;
        minerAnimator.speed = 1;
    }
}
