using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler  {

    public Canvas Padre;
    public float radio= 25;

    private Vector2 Axis;

    public Vector2 axis{
        get{
            return Axis;
        }
    }

    public float Horizontal{
        get{
            return Axis.x;
        }
    }

    public float Vertical{
        get{
            return Axis.y;
        }
    }
    public bool isMoving{
        get{
            return Axis != Vector2.zero;
        }
    }

    Vector3 PosInicial;

	// Use this for initialization
	void Start () {
        PosInicial = transform.position;
         
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag(PointerEventData point){
        int PosToque = point.pointerId;
        Vector2 pos; // Posicio del button joystick 
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Padre.transform as RectTransform, point.position, Padre.worldCamera, out pos);
        Vector2 newpos = Padre.transform.TransformPoint(pos)-PosInicial; // Mantinene el jostick donde esta el raton
        newpos.x = Mathf.Clamp(newpos.x, -radio, radio);
        newpos.y = Mathf.Clamp(newpos.y, -radio, radio);

        Axis = newpos / radio;
        transform.localPosition = newpos;
    }
    
    public void OnEndDrag(PointerEventData point){
        transform.position = PosInicial;
        Axis = Vector2.zero;
    }
}
