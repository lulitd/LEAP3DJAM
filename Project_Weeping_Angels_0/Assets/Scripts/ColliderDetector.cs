using UnityEngine;
using System.Collections;

public class ColliderDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collision cl){
		Debug.Log (cl.collider.gameObject.name);

	}
}
