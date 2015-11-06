using UnityEngine;
using System.Collections;

public class teleportControl : MonoBehaviour {
	private bool isInBox = false;
	public int Status = -1;
	private int current_Status = -1;
	//status
	//-1 = default
	//0 = on terrain (VR)
	//1 = in the box (AR)


	void Start () {
		//set the status
		Status = 0; current_Status = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (current_Status == 0 && Status == 1) {
			//if currently in VR and quick switch gesture has been detected,
			//then teleport to the box
			teleportPlayer.ToAR = true;
			current_Status = 1;
			Debug.Log("ToAR is " + teleportPlayer.ToAR.ToString());
		} else if (current_Status == 1 && Status == 0) {
			//if currently in AR and quick switch gesture has been detected,
			//then teleport to the terrain
			teleportPlayer.ToVR = true;
			current_Status = 0;
		}

		Debug.Log ("current status is " + current_Status.ToString());
	}
}
