using UnityEngine;
using System.Collections;

public class ApplyDamage : MonoBehaviour {

	public static bool AR;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (AR + "AR+++++++++++++");
		if(AR){
		//Debug.Log("AR is in");

		Collider[]collider = Physics.OverlapSphere (transform.position,1f);
		foreach (Collider coll in collider) {
			if(coll.tag == "Slime"){
				Debug.Log ("Collide the Slime ");
				Destroy(coll.gameObject);
				Destroy(gameObject);
				}
			}
		}
	}


}
