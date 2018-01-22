using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteeringWheelController : MonoBehaviour {

    private int tilt;
    public Text upText;
    public Text downText;
	// Use this for initialization
	void Start () {
        tilt = 60;
        upText.text = "UP";
        downText.text = "DOWN";
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveForAndBack = Input.GetAxis("Vertical");
        Vector3 turnLeftRight = new Vector3(moveHorizontal, moveForAndBack, 0.0f);

        if (moveForAndBack > 0)
        {
            upText.color = new Color(255, 0, 0);

        }
        else if (moveForAndBack < 0)
        {
            downText.color = new Color(255, 0, 0);
        }
        else {
            upText.color = new Color(0, 0, 0);
            downText.color = new Color(0, 0, 0);
        }

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, -turnLeftRight.x * tilt);
    }
}
