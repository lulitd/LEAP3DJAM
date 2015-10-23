using UnityEngine;
using System.Collections;

public class FadeTransparency : MonoBehaviour {

	public GameObject fader;

	private Renderer renderer;
	public float fadeSpeed = 1.5f;
	public bool sceneStarting = true;

	void Start () {
		renderer = fader.GetComponent<Renderer> ();
		renderer.material.color = Color.clear;
	}
	
	void Update()
	{
		// If the scene is starting...
		if (sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}
	
	
	void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		renderer.material.color = Color.Lerp(renderer.material.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		renderer.material.color = Color.Lerp(renderer.material.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if (renderer.material.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the RawImage.
			renderer.material.color = Color.clear;
			fader.SetActive(false);
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene(int SceneNumber)
	{
		// Make sure the RawImage is enabled.
		fader.SetActive(true);
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if (renderer.material.color.a >= 0.95f)
			// ... reload the level
			Application.LoadLevel("Environment");
	}
}
