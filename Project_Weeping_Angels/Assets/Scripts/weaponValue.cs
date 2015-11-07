using UnityEngine;
using System.Collections;

public class weaponValue : MonoBehaviour {
	
	
	
	public static int weaponIndex;
	
	// Use this for initialization
	void Start () {
		weaponIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setIndex(int index){
		
		weaponIndex = index;
		Debug.Log ("WeaponIndex " + weaponIndex);
	}
	
	
}
