using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BlinkQuickSwitcher : MonoBehaviour {

	//this is the class to control quickswitcher and the blink function
	//has bugs to fix
	private bool isBlinkFinished = false;
	private QuickSwitcher switcher;
	private BlinkQuad blinker;
	private bool isSwipedGesture = false;

	void Start(){
		switcher = GameObject.FindObjectOfType<QuickSwitcher> ();
		blinker = GameObject.FindObjectOfType<BlinkQuad> ();
	}

	void Update(){
		isBlinkFinished = BlinkQuad.hasFinished;

		//something wrong with the isSwiped value, may need another variable to save the status

		//--------------------------------------------------
		//assign a new valua after finishing tween to position???


		if (isSwipedGesture && isBlinkFinished) {
			if(switcher.m_lastLockedState == QuickSwitcher.TransitionState.OFF)
				switcher.TweenToOnPosition();
			else
				switcher.TweenToOffPosition();
		}

		if (isSwipedGesture != switcher.isSwiped && switcher.Completed_Status == 1)
			isSwipedGesture = switcher.isSwiped; 
	}

}
