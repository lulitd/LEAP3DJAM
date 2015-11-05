using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	public GameObject weaponsPrefab;
	public List<Transform> weapons;

	// Use this for initialization
	void Start () {
		weapons = new List<Transform>();

		// Instantiate weapons
		GameObject weaponGroup = (GameObject)Instantiate (weaponsPrefab, new Vector3(62.72f, 20.0f, -7.94f), Quaternion.identity);

		// get each weapon from children of the prefab
		Transform[] children = weaponGroup.GetComponentsInChildren<Transform> ();

		foreach (Transform child in children){
//			Debug.Log ("tag is weapon?: " + child.CompareTag("Weapon"));
			if(child.CompareTag("Weapon")==true){
				Debug.Log ("current weapon " + child.gameObject.name + " is tagged Weapon");
//				Debug.Log("length of respawns is"  + respawns.Length);
				weapons.Add (child);
			}

		}

//		if (respawns.Length == 0) {
//			Debug.Log("WeaponManager: respawns.Length = " + respawns.Length + "No game objects are tagged with Weapon");
//		} else {
//			foreach (GameObject respawn in respawns) {
//				Debug.Log("gameobject: " + respawn.gameObject.name);
//			}
//		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void respawnWeaponsRandom(){
		foreach (Transform weapon in weapons){
			weapon.gameObject.transform.position = getRandomPosition();
		}
	}

	public void respawnWeaponRandom(GameObject weapon){
		weapon.transform.position = getRandomPosition();
	}

	Vector3 getRandomPosition(){
		Vector3 position = new Vector3(Random.Range(-108.0f, 25.0f), 4.0f ,Random.Range(-66.0f, -52.0f));
		return position;
	}

	void enableWeapon(GameObject weapon){
		weapon.SetActive (true);
	}

	void disableWeapon(GameObject weapon){
		weapon.SetActive (false);
	}
}
