using UnityEngine;
using System.Collections;

public class disableSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(collisionDetectPlayer.isPlayerDead)
		{
			float volume = gameObject.GetComponent<AudioSource>().volume;
			if(volume > 0.1f)
			{
				volume -= 0.9f * Time.deltaTime;
				gameObject.GetComponent<AudioSource>().volume = volume;
			}
		}
	}
}
