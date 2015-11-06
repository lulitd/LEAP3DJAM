using UnityEngine;
using System.Collections;

public class changeSkybox : MonoBehaviour {

	public Material defaultSkybox;
	public int Status = -1;
	private int current_Status = -1;
	//status
	//-1 = default
	//0 = on terrain (VR)
	//1 = in the box (AR)


	// Use this for initialization
	void Start () {
		if (Application.loadedLevel != 0)
			RenderSettings.skybox = defaultSkybox;
	}
	
	// Update is called once per frame
	void Update () {
		if (teleportPlayer.ToAR)
			RenderSettings.skybox = null;
		else if (teleportPlayer.ToVR)
			RenderSettings.skybox = defaultSkybox;


		if (Input.GetKeyDown (KeyCode.LeftShift))
			RenderSettings.skybox = null;


	}
}
