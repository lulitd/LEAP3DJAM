using UnityEngine;
using System.Collections;

public class BlinkQuadControl : MonoBehaviour {

	public static bool isBlink = false;
	private BlinkQuad blinker;
	
	// Use this for initialization
	void Start () {
		blinker = GameObject.FindObjectOfType<BlinkQuad>();
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
