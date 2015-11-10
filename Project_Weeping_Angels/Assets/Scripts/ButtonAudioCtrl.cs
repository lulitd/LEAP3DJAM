using UnityEngine;
using System.Collections;

public class ButtonAudioCtrl : MonoBehaviour {

	public AudioClip audio;
	public float vol = 1.0f;
	public static bool isPressed = false;
	public static bool playFirstTime = true;

	private AudioSource source;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (isPressed && playFirstTime) {
			source.PlayOneShot (audio, vol);
			playFirstTime = false;	// to prevent it from playing multiple times
		}
	}
}
