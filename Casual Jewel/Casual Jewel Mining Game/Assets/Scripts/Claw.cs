using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {

    public Transform origin;
    public float speed = 4f;
    public Gun gun;
    //public ScoreManager scoreManager;

    private Vector3 _target;
    private int _jewelValue = 100;
    private GameObject _childObject;
    private LineRenderer _lineRenderer;
    private bool _hitJewel;
    private bool _retracting; // for claw traveling back

    // Use this for initialization
    void Start () {
        _lineRenderer = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target, step);
        _lineRenderer.SetPosition(0, origin.position);
        _lineRenderer.SetPosition(1, transform.position);
        if (transform.position == origin.position && _retracting){
            gun.CollectedObject();
            if (_hitJewel){
                //scoreManager.AddPoints(_jewelValue);
                _hitJewel = false;
            }
            Destroy(_childObject);
            gameObject.SetActive(false);
        }
    }

    public void ClawTarget(Vector3 pos){
        _target = pos;
    }

    void OnTriggerEnter(Collider other){
        _retracting = true;
        _target = origin.position;

        if (other.gameObject.CompareTag("Jewel")){
            _hitJewel = true;
            _childObject = other.gameObject;
            other.transform.SetParent(this.transform);
        }

        else if (other.gameObject.CompareTag("Rock")){
            _childObject = other.gameObject;
            other.transform.SetParent(this.transform);
        }
    }
}
