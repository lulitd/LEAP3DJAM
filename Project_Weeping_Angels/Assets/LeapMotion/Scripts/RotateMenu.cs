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
			menu.transform.Rotate (Vector3.up, 10f * Time.deltaTime);
		}
		Debug.Log (startRotate);
	}
}
