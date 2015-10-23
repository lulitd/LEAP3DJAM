using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

	private int count = 0;

	public Image BlinkImg;
	public float BlinkSpeed = 1.5f;

	private int blinkRound;

	public bool isBlinking = false;

	void Start(){
		//set blink img to clear when loading scene
		BlinkImg.color = Color.clear;
	}

	void Awake(){
		BlinkImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}

		
	void Update () {
		if (isBlinking) {
			//Debug.Log ("is blinking  = true");
			SceneBlink ();

			if (count > 5) {
				count = 0;
				isBlinking = false;
			}
			//Debug.Log ("count is " + count.ToString ());
		} else {
			count = 0; blinkRound = 0;isBlinking = false;
		}
	}

	void SceneBlink(){
		//Debug.Log ("sceneBlink function called");
		if (blinkRound == 0) {
			if(BlinkImg.color.a > 0.95f)
			{
				blinkRound = 1;
				count++;
			}else
				FadeToBlack ();

		} else if (blinkRound == 1) {
			if(BlinkImg.color.a < 0.05f)
			{
				blinkRound = 0;
				count++;
			}else
				FadeToClear();

		}

	}

	void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		BlinkImg.color = Color.Lerp(BlinkImg.color, Color.clear, BlinkSpeed * Time.deltaTime);
		Debug.Log ("fade to clear a is " + BlinkImg.color.a.ToString () + "count is " + count.ToString () + "blink round is " + blinkRound.ToString ());
	}
	
	
	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		BlinkImg.color = Color.Lerp(BlinkImg.color, Color.black, BlinkSpeed * Time.deltaTime);
		Debug.Log ("fade to black a is " + BlinkImg.color.a.ToString () + "count is " + count.ToString () + "blink round is " + blinkRound.ToString ());

	}
}
