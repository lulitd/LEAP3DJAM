using UnityEngine;
using System.Collections;

public class ButtonAudioCtrl : MonoBehaviour {

	public AudioClip audio;
	public float vol = .5f;
	public static bool playAudio = false;

	private AudioSource source;
	public static bool playFirstTime = true;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (playAudio && playFirstTime) {
			source.PlayOneShot (audio, vol);
			playFirstTime = false;
		}
	}
}
