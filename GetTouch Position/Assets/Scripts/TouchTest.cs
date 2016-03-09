using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //Touch myTouch = Input.GetTouch(0);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void OnGUI()
    {
        foreach (Touch touch in Input.touches)
        {
            string texto = "";
            texto += "ID: " + touch.fingerId + "\n";
            texto += "TapCount: " + touch.tapCount + "\n";
            // The touch phase refers to the action the finger has taken on the most recent frame update.
            texto += "phase: " + touch.phase.ToString() + "\n";
            texto += "Pos X: " + touch.position.x + "\n";
            texto += "Pos Y: " + touch.position.y + "\n";

            int num = touch.fingerId;

            GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), texto);
        }
    }
}
