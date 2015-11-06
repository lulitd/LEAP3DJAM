using UnityEngine;
using System.Collections;

public class changeSkybox : MonoBehaviour {

	public Material defaultSkybox;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevel != 0)
			RenderSettings.skybox = defaultSkybox;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift))
			RenderSettings.skybox = null;
	}
}
