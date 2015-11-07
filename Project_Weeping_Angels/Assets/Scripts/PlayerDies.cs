using UnityEngine;
using System.Collections;

public class PlayerDies : MonoBehaviour {
	public static bool hasAudioPlayed = false;
	//this script is used to add the fade effect and send player to the game over scene
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("is audio play " + collisionDetectPlayer.PlayAudio.ToString());
		if (collisionDetectPlayer.isPlayerDead) {


			QuadFadeIn fader = GameObject.FindObjectOfType<QuadFadeIn> ();
			fader.fadeSpeed = 0.6f;
			fader.EndScene (2);
			//
		}

		if(collisionDetectPlayer.PlayAudio && !hasAudioPlayed){
			Debug.Log("play audio");
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			AudioSource audio = player.GetComponent<AudioSource>();
			audio.mute = false;
			audio.PlayOneShot(audio.clip, 0.5f);
			hasAudioPlayed = true;
			collisionDetectPlayer.PlayAudio = false;
		}
		
	}
}
