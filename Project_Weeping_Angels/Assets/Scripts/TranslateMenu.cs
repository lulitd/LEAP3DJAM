using UnityEngine;
using System.Collections;

public class TranslateMenu : MonoBehaviour {
	
	//public static bool startTranslate;
	public static bool isOptions;
	public static bool isCredits;
	public static bool isOptBack;
	public static bool isCreBack;

	public Transform targetOpt;
	public Transform targetCre;
	public Transform targetMenu;

	public float speed;

	GameObject menu;
	// Use this for initialization
	void Start () {
		isOptions = false;
		isCredits = false;
		isOptBack = false;
		isCreBack = false;
		targetOpt = GameObject.FindGameObjectWithTag("OptMarker").transform;
		targetCre = GameObject.FindGameObjectWithTag ("CreditMarker").transform;
		targetMenu = GameObject.FindGameObjectWithTag ("MenuMarker").transform;

		menu = GameObject.FindGameObjectWithTag("Menu");
		speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {



		if (isOptions) {

			//Debug.Log ("isOptions" + isOptions);
			//float step = speed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, targetOpt.position, step);
			menu.transform.position = -1f * targetOpt.position;
			//isOptBack = false;
			//isCreBack = false;

		}
		if (isCredits) {
			//Debug.Log ("isCredits" + isCredits);
			//float step = speed * Time.deltaTime;
			//menu.transform.position = Vector3.MoveTowards(transform.position, targetCre.position, step);
			menu.transform.position = -1f * targetCre.position;
			//isOptBack = false;
			//isCreBack = false;

		}
		if (isOptBack) {

			//Debug.Log ("isOptBack" + isOptBack);
			menu.transform.position = -1f * targetMenu.position;

			//isOptions = false;
		}
		if (isCreBack) {
			
			//Debug.Log ("isCreBack" + isCreBack);
			menu.transform.position = -1f * targetMenu.position;
			//isCredits = false;
		}

//		if (isOptBack || isCreBack) {
//			isOptions = false;
//			isCredits = false;
//		}

	}


}
