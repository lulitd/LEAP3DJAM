using UnityEngine;
using System.Collections;

public class PrefebChange : MonoBehaviour {
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0F;

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {

	}


    public void UpdateColor()
    {
        GameObject[] things;
       things = GameObject.FindGameObjectsWithTag("PreFebTry");
        foreach (GameObject thing in things)
        {
           Renderer rend = thing.GetComponent<Renderer>();
           float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
    }

}
