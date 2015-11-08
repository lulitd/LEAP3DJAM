using UnityEngine;
using System.Collections;

public class materialSwitch : MonoBehaviour
{

	#region PUBLIC_MEMBERS
	public  static bool swap;
	public Texture newMainTexture;
	public Texture emptyTexture;
	public Texture originalTexture;
	public Color secondaryColor;
	public Color mainColor;
	public  static bool noTexture;


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
				//Debug.Log (r + ":" + r.material.mainTexture);
				if (r.material.GetTexture ("_MainTex") == null) {
					r.material.SetColor ("_Color",secondaryColor);
					//Debug.Log ("no texture !");	
				} else {
					//prevTexture= r.material.mainTexture;
					r.material.mainTexture = newMainTexture;
					// set to white so there is no colour distortion
					r.material.SetColor ("_Color", mainColor);
				}
			}
			//Debug.Log("Swap complete!");
			swap = false;
		} 

		if (!swap  && !noTexture) {

			foreach (Renderer r in rend) {
				//Debug.Log (r + ":" + r.material.mainTexture);
				if (r.material.GetTexture ("_MainTex") == null) {
					r.material.SetColor ("_Color",Color.yellow);
					//Debug.Log ("no texture !");	
				} else {
					//prevTexture= r.material.mainTexture;
					r.material.mainTexture = originalTexture;
					// set to white so there is no colour distortion
					r.material.SetColor ("_Color",Color.white);
				}
			}
			//Debug.Log("Swap complete!");
			swap = false;
		}
	
		if (noTexture) {
			Debug.Log ("THERE SHOULD BE NO TEXTURE");	
			foreach (Renderer r in rend) {	
				Debug.Log (r + ":" + r.material.mainTexture);
				if (r.material.GetTexture ("_MainTex") == null) {
					r.material.SetColor ("_Color",Color.white);
					//Debug.Log ("no texture: texture ==null");	
				} else {
					//prevTexture= r.material.mainTexture;
					r.material.mainTexture = emptyTexture;
					// set to white so there is no colour distortion
					r.material.SetColor ("_Color", Color.white);
					//Debug.Log ("no texture: texture ==newtexture");	
				}

				}

		}


	
	}
}
	






