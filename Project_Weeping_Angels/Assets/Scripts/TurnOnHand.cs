using UnityEngine;
using System.Collections;

public class TurnOnHand : MonoBehaviour {

	GameObject hand;
	// Use this for initialization
	void Start () {
		hand = GameObject.FindGameObjectWithTag("Hand");
	}
	
	// Update is called once per frame
	void Update () {
		hand.SetActive (true);

	}
}
