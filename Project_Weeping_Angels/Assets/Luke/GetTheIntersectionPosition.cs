using UnityEngine;
using System.Collections;

public class GetTheIntersectionPosition : MonoBehaviour {
	private Collider coll;
	// Use this for initialization
	void Start () {
		coll = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Collider Enter");
		Vector3 closestPoint = coll.ClosestPointOnBounds(other.transform.position);// get 
		


	}
}
