using UnityEngine;
using System.Collections;

public class BlinkControl : MonoBehaviour {

	private bool isBlink = false;
	private Blink blinker;

	// Use this for initialization
	void Start () {
		blinker = GameObject.FindObjectOfType<Blink>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			isBlink = true;
		else
			isBlink = false;


		if (isBlink)
			blinker.isBlinking = true;


	}
}
