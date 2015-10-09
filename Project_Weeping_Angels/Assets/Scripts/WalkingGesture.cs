using UnityEngine;
using System.Collections;
using Leap;

public class WalkingGesture : MonoBehaviour {

	Controller _controller;

	public bool isLeftHanded = false;

	void Start () {
		_controller = new Controller ();
	}
	
	void Update () {

		//store the frame object
		Frame frame = _controller.Frame ();

		//check the hand list
		HandList _handlist = frame.Hands;
		if (_handlist.Count == 0)
			return;

		//Save left and right hand
		Hand leftHand = null; Hand rightHand = null;
		for (int i = 0; i < _handlist.Count; i++) {
			//*** may add a if statement to check if the hand is valid
			//check and assign left or right hand  
			if(_handlist[i].IsLeft)
				leftHand = _handlist[i];
			else if(_handlist[i].IsRight)
				rightHand = _handlist[i];
		}

		//using right hand as the controller for the player
		FingerList fingers = rightHand.Fingers;
		Finger Index_Finger = new Finger();
		for (int i = 0; i < fingers.Count; i++) {
			Debug.Log(fingers[i].Type);
			if(fingers[i].Type.Equals(Finger.FingerType.TYPE_INDEX))
			{
				Debug.Log("index finger found!");
				Index_Finger = fingers[i];
			}
		}
		//finger index: 
		//TYPE_THUMB = = 0 -
//		TYPE_INDEX = = 1 -
//		TYPE_MIDDLE = = 2 -
//		TYPE_RING = = 3 -
//		TYPE_PINKY = = 4 - 



		//store the middle finger
		Finger Middle_Finger = rightHand.Finger (2);

		//the walking gesture: index finger pointing forward
		if(Index_Finger.IsValid)
		Debug.Log ("index finger direction is " + Index_Finger.Direction.ToString ());
	
	}
}
