using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalculateDistance4UI : MonoBehaviour {

	private GameObject[] slimList;
	private GameObject Player;
	private GameObject UISign;

	public float distance_threshold = 50f;
	// Use this for initialization
	void Start () {
		slimList = GameObject.FindGameObjectsWithTag ("Slime");
		Player = GameObject.FindGameObjectWithTag("Player");
		UISign = GameObject.Find ("BlinkSign");

		UISign.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		float[] distance = new float[slimList.Length];
		float shortestDis = -1f;

		for (int i = 0; i < slimList.Length; i++) {
			distance[i] = Vector3.Distance(slimList[0].transform.position, Player.transform.position);
			Debug.Log("distance is " + distance.ToString());
		}


		for (int i = 0; i < distance.Length; i++) {

			//get the shortest distance
			if(shortestDis == -1)
				shortestDis = distance[i];
			else if (shortestDis > distance[i])
				shortestDis = distance[i];
		}

		if (shortestDis != -1f && shortestDis < distance_threshold)
			UISign.SetActive (true);
		else
			UISign.SetActive (false);

		Debug.Log ("shortest distance is " + shortestDis.ToString());
	}
}
