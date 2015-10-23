/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

// Class to setup a rigged hand based on a model.
public class LukeUIHand : HandModel
{
	
	public Vector3 modelFingerPointing = Vector3.forward;
	public Vector3 modelPalmFacing = -Vector3.up;
	public GameObject prefeb;
	public GameObject preLightEff;
	private bool haveWatch = false;
	
	public override void InitHand()
	{
		UpdateHand();
	}
	
	public Quaternion Reorientation()
	{
		return Quaternion.Inverse(Quaternion.LookRotation(modelFingerPointing, -modelPalmFacing));
	}
	
	public override void UpdateHand()
	{
		if (palm != null)
		{
			palm.position = GetPalmPosition();
			palm.rotation = GetPalmRotation() * Reorientation();
		}
		
		if (forearm != null)
			forearm.rotation = GetArmRotation() * Reorientation();
		
		for (int i = 0; i < fingers.Length; ++i)
		{
			if (fingers[i] != null)
			{
				fingers[i].fingerType = (Finger.FingerType)i;
				fingers[i].UpdateFinger();
			}
		}
		updateUIPos();
		ShowUI();
		
	}
	
	//added function by luke
	public void ShowUI()
	{// rotate to show
		float QuaternionW = GetPalmRotation().w;
		// Debug.Log(QuaternionW);
		if (haveWatch == false)
		{
			
			if (QuaternionW<0)
			{
				
				Instantiate(prefeb, new Vector3(0F, 0, -10), Quaternion.identity);
				Instantiate(preLightEff, new Vector3(0F, 0, -10), Quaternion.AngleAxis(270,Vector3.right));      
				haveWatch = true;
			}
		}
		else
		{
			if (QuaternionW>0)
			{
				
				Destroy(GameObject.FindGameObjectWithTag("UIWatch"));
				Destroy(GameObject.FindGameObjectWithTag("LightEff"));
				haveWatch = false;
			}
		}
		
	}
	public void updateUIPos()
	{ //keep UI around head
		GameObject temp = GameObject.FindGameObjectWithTag("UIWatch");
		GameObject temp1 = GameObject.FindGameObjectWithTag("LightEff");
		if (temp != null)
		{
			if (haveWatch == true)
			{
				Vector3 UIPosition = GetPalmPosition() + Vector3.up * 2f ;
				temp.transform.position = UIPosition;
				Vector3 LightPosition = GetPalmPosition()+ Vector3.up * 0.5f;
				temp1.transform.position = LightPosition;
			}
		}
	}
	
}