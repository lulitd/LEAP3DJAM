/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

// The model for our rigid hand made out of various polyhedra.
public class RigidHand : SkeletalHand {
	
	//================Yuyu and Luke Modified=================
	
	public float filtering = 0.5f;
	public float detectRaduis;
	private GameObject rock;
	private GameObject chickenLeg;
	private GameObject shield;
	private GameObject stick;
	
	private int index_W;
	
	public static bool AR_;
	
	private bool rockInHand;
	private bool chickenInHand;
	private bool shieldInHand;
	private bool stickInHand;
	
	private GameObject manager;
	
	
	
	public override void InitHand() {
		base.InitHand();
		detectRaduis = 1f;
		rock = GameObject.FindGameObjectWithTag ("Rock");
		chickenLeg = GameObject.FindGameObjectWithTag ("ChickenLeg");
		shield = GameObject.FindGameObjectWithTag("Shield");
		
		
		index_W = 0;
		rockInHand = false;
		chickenInHand = false;
		shieldInHand = false;
		stickInHand = false;

	}
	
	void DetectAroundHands(){
		Collider [] colls = Physics.OverlapSphere (GetPalmCenter(),detectRaduis);
		foreach(Collider coll in colls ){
			if(coll.tag =="Rock"){
				index_W = 1;
				weaponValue.weaponIndex = 1;
				Debug.Log("Rock" + index_W);
				rockInHand = true;
				
			}else if(coll.tag =="ChickenLeg"){
				
				index_W = 2;
				weaponValue.weaponIndex = 2;
				Debug.Log("Chicken" + index_W);
				chickenInHand = true;
				
			}
			else if(coll.tag =="Shield"){
				
				index_W = 3;
				weaponValue.weaponIndex = 3;
				//Debug.Log("Shield" + index_W);
				shieldInHand = true;
				
			}else if(coll.tag == "Ground"){

			}
			
		}
	}
	
	
	void Update(){
		DetectAroundHands ();

		if (weaponValue.weaponIndex == 1 && rock != null) {
			rock.transform.position = GetPalmCenter();
		}
		if (weaponValue.weaponIndex == 2 && chickenLeg != null) {
			chickenLeg.transform.position = GetPalmCenter();
		}
		if (weaponValue.weaponIndex == 3 && shieldInHand != null) {
			shield.transform.position = GetPalmCenter();
		}
	//	Debug.Log ("AR " + AR_);
//	//	Debug.Log ("weaponValue weaponIndex" + weaponValue.weaponIndex);
//		//Debug.Log(GetPalmCenter().x + ", " + GetPalmCenter().y + ", " +  GetPalmCenter().z);
	}
	
	//======================Modification End==========================


	public override void UpdateHand() {

		if (palm != null) {
			bool useVelocity = false;
			Rigidbody palmBody = palm.GetComponent<Rigidbody>();
			if (palmBody) {
				if (!palmBody.isKinematic) {
					useVelocity = true;
					
					// Set palm velocity.
					Vector3 target_position = GetPalmCenter();
					palmBody.velocity = (target_position - palm.position) * (1 - filtering) / Time.deltaTime;
					
					// Set palm angular velocity.
					Quaternion target_rotation = GetPalmRotation();
					Quaternion delta_rotation = target_rotation * Quaternion.Inverse(palm.rotation);
					float angle = 0.0f;
					Vector3 axis = Vector3.zero;
					delta_rotation.ToAngleAxis(out angle, out axis);
					
					if (angle >= 180) {
						angle = 360 - angle;
						axis = -axis;
					}
					if (angle != 0) {
						float delta_radians = (1 - filtering) * angle * Mathf.Deg2Rad;
						palmBody.angularVelocity = delta_radians * axis / Time.deltaTime;
					}
				}
			}
			if (!useVelocity) {
				palm.position = GetPalmCenter();
				palm.rotation = GetPalmRotation();
			}
		}
		
		if (forearm != null) {
			// Set arm dimensions.
			CapsuleCollider capsule = forearm.GetComponent<CapsuleCollider> ();
			if (capsule != null) {
				// Initialization
				capsule.direction = 2;
				forearm.localScale = new Vector3 (1f, 1f, 1f);
				
				// Update
				capsule.radius = GetArmWidth () / 2f;
				capsule.height = GetArmLength () + GetArmWidth ();
			}
			
			bool useVelocity = false;
			Rigidbody forearmBody = forearm.GetComponent<Rigidbody> ();
			if (forearmBody) {
				if (!forearmBody.isKinematic) {
					useVelocity = true;
					
					// Set arm velocity.
					Vector3 target_position = GetArmCenter ();
					forearmBody.velocity = (target_position - forearm.position) * (1 - filtering) / Time.deltaTime;
					
					// Set arm velocity.
					Quaternion target_rotation = GetArmRotation ();
					Quaternion delta_rotation = target_rotation * Quaternion.Inverse (forearm.rotation);
					float angle = 0.0f;
					Vector3 axis = Vector3.zero;
					delta_rotation.ToAngleAxis (out angle, out axis);
					
					if (angle >= 180) {
						angle = 360 - angle;
						axis = -axis;
					}
					if (angle != 0) {
						float delta_radians = (1 - filtering) * angle * Mathf.Deg2Rad;
						forearmBody.angularVelocity = delta_radians * axis / Time.deltaTime;
					}
				}
			}
			if (!useVelocity) {
				forearm.position = GetArmCenter();
				forearm.rotation = GetArmRotation();
			}
		}




	}
}
