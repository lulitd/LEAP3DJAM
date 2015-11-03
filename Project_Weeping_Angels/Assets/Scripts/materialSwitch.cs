using UnityEngine;
using System.Collections;

public class materialSwitch : MonoBehaviour
{

	#region PUBLIC_MEMBERS
	public  bool swap;
	public Texture newMainTexture;
	public Texture emptyTexture;
	public Color secondaryColor;
	public Color mainColor;
	public bool noTexture;


	#endregion// PUBLIC_MEMBERS

	private Renderer[] rend;
	
	void  Awake ()
	{
		rend = gameObject.GetComponentsInChildren<Renderer> ();

		if (rend == null) {
			//	Debug.Log ("root null!");
		}
	}


	// Update function
	void  Update ()
	{
		if (swap) {

			foreach (Renderer r in rend) {
				Debug.Log (r + ":" + r.material.mainTexture);
				if (r.material.GetTexture ("_MainTex") == null) {
					r.material.SetColor ("_Color",secondaryColor);
					Debug.Log ("no texture !");	
				} else {
					//prevTexture= r.material.mainTexture;
					r.material.mainTexture = newMainTexture;
					// set to white so there is no colour distortion
					r.material.SetColor ("_Color", mainColor);
				}
			}
			Debug.Log("Swap complete!");
			swap = false;
		} else if (noTexture) {
			
			foreach (Renderer r in rend) {	
				Debug.Log (r + ":" + r.material.mainTexture);
				if (r.material.GetTexture ("_MainTex") == null) {
					r.material.SetColor ("_Color",Color.white);
					Debug.Log ("no texture !");	
				} else {
					//prevTexture= r.material.mainTexture;
					r.material.mainTexture = emptyTexture;
					// set to white so there is no colour distortion
					r.material.SetColor ("_Color", Color.white);
				}

				}

			noTexture= false;
		}

	
	}
}
	






