using UnityEngine;
using System.Collections;

public class BlinkQuad : MonoBehaviour {

	private int count = 0;
	
	public GameObject Blinker_Quad;

	private Renderer renderer;

	public float BlinkSpeed = 1.5f;
	
	public int blinkRound;
	
	public bool isBlinking = false;
	public static bool hasFinished = false;
	
	void Start(){
		//set blink img to clear when loading scene
		renderer = Blinker_Quad.GetComponent<Renderer> ();
		renderer.material.color = Color.clear;
	}
	

	void Update () {
		if (isBlinking) {
			//Debug.Log ("is blinking  = true");


			SceneBlink ();
			
			if (count > 5) {
				count = 0;
				isBlinking = false;
				hasFinished = true;
			}else
				hasFinished = false;
			//Debug.Log ("count is " + count.ToString ());
		} else {
			count = 0; blinkRound = 0;isBlinking = false;
		}
	}
	
	void SceneBlink(){
		renderer.gameObject.SetActive (true);
		Debug.Log ("sceneBlink function called");
		if (blinkRound == 0) {
			if(renderer.material.color.a > 0.95f)
			{
				blinkRound = 1;
				count++;
			}else
				FadeToBlack ();
			
		} else if (blinkRound == 1) {
			if(renderer.material.color.a < 0.05f)
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
		renderer.material.color = Color.Lerp(renderer.material.color, Color.clear, BlinkSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		renderer.material.color = Color.Lerp(renderer.material.color, Color.black, BlinkSpeed * Time.deltaTime);
	}

}
