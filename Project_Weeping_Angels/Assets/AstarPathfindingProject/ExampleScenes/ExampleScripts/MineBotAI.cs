using UnityEngine;
using System.Collections;
using Pathfinding.RVO;

namespace Pathfinding {
	/** AI controller specifically made for the spider robot.
	 * The spider robot (or mine-bot) which is got from the Unity Example Project
	 * can have this script attached to be able to pathfind around with animations working properly.\n
	 * This script should be attached to a parent GameObject however since the original bot has Z+ as up.
	 * This component requires Z+ to be forward and Y+ to be up.\n
	 * 
	 * It overrides the AIPath class, see that class's documentation for more information on most variables.\n
	 * Animation is handled by this component. The Animation component refered to in #anim should have animations named "awake" and "forward".
	 * The forward animation will have it's speed modified by the velocity and scaled by #animationSpeed to adjust it to look good.
	 * The awake animation will only be sampled at the end frame and will not play.\n
	 * When the end of path is reached, if the #endOfPathEffect is not null, it will be instantiated at the current position. However a check will be
	 * done so that it won't spawn effects too close to the previous spawn-point.
	 * \shadowimage{mine-bot.png}
	 * 
	 * \note This script assumes Y is up and that character movement is mostly on the XZ plane.
	 */
	[RequireComponent(typeof(Seeker))]
	public class MineBotAI : AIPath {
		
		/** Animation component.
		 * Should hold animations "awake" and "forward"
		 */
		//public Animation anim;
		
		/** Minimum velocity for moving */
		public float sleepVelocity = 0.4F;
		
		/** Speed relative to velocity with which to play animations */
		public float animationSpeed = 0.2F;
		public float rangeX;
		public float rangeX1;
		public float rangeY;
		public float rangeY1;
		public float rangeZ;
		public float rangeZ1;

		/** Effect which will be instantiated when end of path is reached.
		 * \see OnTargetReached */
		public GameObject endOfPathEffect;
		public float dectPalyerRadius = 5f;
		public GameObject player;
		private GameObject waypoint;
		public bool VR_AR;
		public new void Start () {
			
			//Prioritize the walking animation
			//anim["forward"].layer = 10;
			
			//Play all animations
			//anim.Play ("awake");
			//anim.Play ("forward");
			
			//Setup awake animations properties
			//anim["awake"].wrapMode = WrapMode.Clamp;
			//anim["awake"].speed = 0;
			//anim["awake"].normalizedTime = 1F;
			
			//Call Start in base script (AIPath)
			base.Start ();
			waypoint = new GameObject ();
			waypoint.transform.position = new Vector3(Random.Range(rangeX,rangeX1),Random.Range(rangeY,rangeY1),Random.Range(rangeZ,rangeZ1));
			target = waypoint.transform;
			player = GameObject.FindGameObjectWithTag("Player");
		}
		
		/** Point for the last spawn of #endOfPathEffect */
		protected Vector3 lastTarget;
		
		/**
		 * Called when the end of path has been reached.
		 * An effect (#endOfPathEffect) is spawned when this function is called
		 * However, since paths are recalculated quite often, we only spawn the effect
		 * when the current position is some distance away from the previous spawn-point
		*/
		public override void OnTargetReached () {

			if (endOfPathEffect != null && Vector3.Distance (tr.position, lastTarget) > 1) {
				GameObject.Instantiate (endOfPathEffect,tr.position,tr.rotation);
				lastTarget = tr.position;
			}
			CheckTarget ();//luke added

		}
		//Luke Added for check wehter is the target is palyer or not
		public void CheckTarget(){
			if (target.gameObject.tag != "Player") {
				RandomWayPoint();
			}else{//find it

			}
		}
		//Luke added for change positon at AR and VR
		public void ChangToARRandom(){
			
			//if (VR_AR) {//true then AR 
			canMove = false;
			//originPos = transform.position;// call at some whereelse
			//Debug.Log (originPos.x);
			//Destroy (gameObject.GetComponent<Rigidbody> ());
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.GetComponent<Rigidbody> ().Sleep ();
			transform.position = new Vector3 (Random.Range(64.07115f,71f),127.08f,Random.Range(-1409.4f,-1401f));// position around player;
			
			
		}
		//Luke added for change to VR
		public void ChangToVR(){
			//Debug.Log("1111111111");
			canMove = true;
			//Rigidbody newrigidBody = gameObject.AddComponent<Rigidbody> ();
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.GetComponent<Rigidbody> ().WakeUp ();
			transform.position = new Vector3(Random.Range(rangeX,rangeX1),8f,Random.Range(rangeZ,rangeZ1));// radanom postion om map
			
			
		}


		//Luke added for make the ghost fly around and change thr target to user when in range
		public void RandomWayPoint(){
			target.position = new Vector3(Random.Range(rangeX,rangeX1),Random.Range(rangeY,rangeY1),Random.Range(rangeZ,rangeZ1));
		}

		public void DectHavePalyer(){
		Collider[] coll=Physics.OverlapSphere(transform.position,dectPalyerRadius);//check the surroudning things
			for (int i =0; i<coll.Length; i++) {
				if(coll[i].tag == "Player"){
					target=player.transform;

				}
			}
		}
		/// <summary>
		/// Ends Here		/// </summary>
		/// <returns>The feet position.</returns>
		public override Vector3 GetFeetPosition ()
		{
			return tr.position;
		}
		
		protected new void Update () {
			DectHavePalyer ();
			//Get velocity in world-space
			Vector3 velocity;
			if (canMove) {
			
				//Calculate desired velocity
				Vector3 dir = CalculateVelocity (GetFeetPosition());
				
				//Rotate towards targetDirection (filled in by CalculateVelocity)
				RotateTowards (targetDirection);
				
				dir.y = 0;
				if (dir.sqrMagnitude > sleepVelocity*sleepVelocity) {
					//If the velocity is large enough, move
				} else {
					//Otherwise, just stand still (this ensures gravity is applied)
					dir = Vector3.zero;
				}

				if (navController != null) {
					velocity = Vector3.zero;
				} else if (controller != null) {
					controller.SimpleMove (dir);
					velocity = controller.velocity;
				} else {
					Debug.LogWarning ("No NavmeshController or CharacterController attached to GameObject");
					velocity = Vector3.zero;
				}
			} else {
				velocity = Vector3.zero;
			}
			
			
			//Animation
			
			//Calculate the velocity relative to this transform's orientation
			Vector3 relVelocity = tr.InverseTransformDirection (velocity);
			relVelocity.y = 0;
			
			if (velocity.sqrMagnitude <= sleepVelocity*sleepVelocity) {
				//Fade out walking animation
				//anim.Blend ("forward",0,0.2F);
			} else {
				//Fade in walking animation
				//anim.Blend ("forward",1,0.2F);
				
				//Modify animation speed to match velocity
			//	AnimationState state = anim["forward"];
				
				float speed = relVelocity.z;
			//	state.speed = speed*animationSpeed;
			}
		}
	}
}