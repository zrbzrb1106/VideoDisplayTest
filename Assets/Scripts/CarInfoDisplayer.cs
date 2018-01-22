using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInfoDisplayer : MonoBehaviour {

    public Text speedText;
    private int speed;
	// Use this for initialization
	void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        speed = 100;
        speedText.text = "speed: " + speed + " km/h";
	}
}
