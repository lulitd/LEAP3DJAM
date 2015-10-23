using UnityEngine;
using System.Collections;

public class FadeControl : MonoBehaviour {

	public static bool isFade;
	private FadeTransparency fader;
	// Use this for initialization
	void Start () {
		isFade = false;
		fader = GameObject.FindObjectOfType<FadeTransparency> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(isFade)
			fader.EndScene (1);

	}
}
