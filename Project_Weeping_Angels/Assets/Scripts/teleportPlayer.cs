using UnityEngine;
using System.Collections;

public class teleportPlayer : MonoBehaviour {

	private GameObject Player;
	private GameObject PlaceHolder;
	private Vector3 pre_position;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		PlaceHolder = GameObject.Find ("PlayerPlaceHolder");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {

			//decide where the player is 
			if(Player.transform.position != PlaceHolder.transform.position)
			{
				//store current position first before teleporting
				pre_position = Player.transform.position;
				Player.transform.position = PlaceHolder.transform.position;
			}else
			{
				Player.transform.position = pre_position;
				pre_position = Vector3.zero;
			}
		}
	}
}
