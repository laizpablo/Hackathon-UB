using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //Touch myTouch = Input.GetTouch(0);

	}

    void OnGUI()
    {
        foreach (Touch touch in Input.touches)
        {
            string texto = "";
            texto = "ID: " + touch.fingerId + "\n";
            int num = touch.fingerId;

            GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), texto);
        }
    }
}
