using UnityEngine;
using System.Collections;

public class RotateMenu : MonoBehaviour {

	public static bool startRotate;
	GameObject menu;
	// Use this for initialization
	void Start () {
		startRotate = false;
		menu = GameObject.FindGameObjectWithTag("Menu");
	}
	
	// Update is called once per frame
	void Update () {
		if (startRotate) {
			menu.transform.Translate(-10.15f, 0f, 0f);
		}
		Debug.Log (startRotate);
	}
}
