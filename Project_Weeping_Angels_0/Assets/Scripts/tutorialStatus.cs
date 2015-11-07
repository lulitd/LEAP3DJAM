using UnityEngine;
using System.Collections;

public class tutorialStatus : MonoBehaviour {

	private GameObject HandForward;
	private GameObject HandBackward;
	private GameObject HandRight;
	private GameObject HandLeft;

	private int status = 0;
	private float TimeLimit = 10f;

	public float limit = 3f;
	// Use this for initialization
	void Start () {
		HandForward = GameObject.Find ("hand_forward");
		HandBackward = GameObject.Find ("hand_backward");
		HandRight = GameObject.Find ("hand_right");
		HandLeft = GameObject.Find ("hand_left");

		HandForward.SetActive (false);
		HandBackward.SetActive (false);
		HandRight.SetActive (false);
		HandLeft.SetActive (false);
		TimeLimit = limit;
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();

		if (status == 1) {
			TimeLimit = limit;
			status++;

		} else if (status == 2) {
			HandForward.SetActive (true);
			HandBackward.SetActive (false);
			HandRight.SetActive (false);
			HandLeft.SetActive (false);
			//TimeLimit = 10f;
		} else if (status == 3) {
			TimeLimit = limit;
			status++;
		} else if (status == 4) {
			HandForward.SetActive (false);
			HandBackward.SetActive (true);
			HandRight.SetActive (false);
			HandLeft.SetActive (false);
		} else if (status == 5) {
			TimeLimit = limit;
			status++;
		} else if (status == 6) {
			HandForward.SetActive (false);
			HandBackward.SetActive (false);
			HandRight.SetActive (true);
			HandLeft.SetActive (false);
		} else if (status == 7) {
			TimeLimit = limit;
			status++;
		} else if (status == 8) {
			HandForward.SetActive (false);
			HandBackward.SetActive (false);
			HandRight.SetActive (false);
			HandLeft.SetActive (true);
		}
		else {
			HandForward.SetActive (false);
			HandBackward.SetActive (false);
			HandRight.SetActive (false);
			HandLeft.SetActive (false);
			//TimeLimit = 10f;
		}


	}

	void Timer() {
		if (TimeLimit > 1)
			TimeLimit -= Time.deltaTime;
		else
			status++;

		//Debug.Log ("Time Limit is " + TimeLimit.ToString());
	}
}
