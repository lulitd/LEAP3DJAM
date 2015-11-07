using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ClockTime : MonoBehaviour {
    private Text CTime;
	// Use this for initialization
	void Start () {
        CTime = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        CTime.text = System.DateTime.Now.ToString("hh:mm");
    }

   
}
