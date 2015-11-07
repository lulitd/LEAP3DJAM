using UnityEngine;
using System.Collections;

public class ApplyDamage : MonoBehaviour {

	public static bool AR;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(AR){
		Collider[]collider = Physics.OverlapSphere (transform.position,1f);
		foreach (Collider coll in collider) {
			if(coll.tag == "Slime"){
				Destroy(coll.gameObject);
				Destroy(gameObject);
				}
			}
		}
	}


}
