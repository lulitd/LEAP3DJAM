using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//-------------------------------------------------------
//THIS SCRIPT HAS BEEN HACKED 
//DONT USE IT FOR OTHER PROJECTS
//-------------------------------------------------------

public class QuickSwitcher : MonoBehaviour {
	
	public bool m_enabled = false;
	[SerializeField]
	private HandController m_handController;
	[SerializeField]
	private LeapCameraAlignment m_cameraAlignment;
	[SerializeField]
	private float m_minProgressToStartTransition;
	[SerializeField]
	private float m_fractionToLockTransition;
	[SerializeField]
	private Vector3 m_wipeOutPosition;
	[SerializeField]
	private List<LeapImageRetriever> m_imageRetriever;
	
	private Vector3 m_startPosition;
	
	public enum TransitionState { ON, OFF, MANUAL, TWEENING }; // changed from private to public by Danni
	private TransitionState m_currentTransitionState;
	// Know what the last locked state was so we know what we're transitioning to.
	public TransitionState m_lastLockedState;  //changed from private to public by Danni
	
	// Where are we transitioning to and from
	private Vector3 m_from; 
	private Vector3 m_to;
	
	private delegate void TweenCompleteDelegate();
	private BlinkQuad blinker;
	
	//------------- Flag for On and Off -------------------
	//Added by Danni
	//public bool IS_ON = false;
	public bool isSwiped = false;
	public int Completed_Status = -1;
	private teleportControl teleportController;
	//Completed status:
	//-1: init
	// 0: On Complete == null
	// 1: On complete != null
	
	// Use this for initialization
	void Start () {
		m_startPosition = transform.localPosition;
		m_from = m_startPosition;
		m_to = m_wipeOutPosition;
		m_lastLockedState = TransitionState.ON;
		SystemWipeRecognizerListener.Instance.SystemWipeUpdate += onWipeUpdate;
		TweenToOffPosition();
		
		//---------------- Added by Danni -----------------------
		blinker = GameObject.FindObjectOfType<BlinkQuad> ();
		teleportController = GameObject.FindObjectOfType<teleportControl> ();
	}
	
	private void onWipeUpdate(object sender, SystemWipeArgs eventArgs) {
		if ( !m_enabled ) { return; }
		
		string debugLine = "Debug";
		if ( eventArgs.WipeInfo.Status == Leap.Util.Status.SwipeAbort ) {
			debugLine += " | Abort";
			// If the user aborts, tween back to original location
			if ( m_lastLockedState == TransitionState.ON ) {
				TweenToOnPosition();
			}
			else {
				TweenToOffPosition();
			}
		}
		
		if ( m_currentTransitionState == TransitionState.MANUAL ) {
			
			debugLine += " | Manual Control";
			float fraction = Mathf.Clamp01(eventArgs.WipeInfo.Progress);
			
			debugLine += ": " + fraction;
			transform.localPosition = Vector3.Lerp(m_from, m_to, fraction);
			
			// If we're sure of the gesture, just go make the transition
			if ( fraction >= m_fractionToLockTransition ) {
				//debugLine += " | Transition Cofirmed";
				
				//THIS SECTION HAS BEEN MODIFIED TO FIT THE LEAP 3D JAM
				isSwiped = true;
				// luke added
				GameObject[] slimes = GameObject.FindGameObjectsWithTag ("Slime");
				foreach (GameObject slime in slimes) {
					slime.SendMessage("ChangToARRandom");
					
				}

				//==================Yuyu and Luke added it=====================
				//Set the AR to be true in other two classes
				//RigidHand.AR_ = true;
				ApplyDamage.AR = true;
				//=========================End===============================
				//blinker.isBlinking = true;
				if ( m_lastLockedState == TransitionState.OFF) {
					TweenToOnPosition();
					blinker.isBlinking = true;
					//BlinkQuadControl.isBlink = true;
					Debug.Log("on position");
					teleportController.Status = 1;
					//IS_ON = true;
				}
				else {
					//if(Blink.hasFinished)
					//{
					blinker.isBlinking = true;
					TweenToOffPosition();
					//BlinkQuadControl.isBlink = true;
					teleportController.Status = 0;
					Debug.Log("off position");
					//IS_ON = false;
					//}

					//======================LUKE added==========================
					ApplyDamage.AR = false;
					
					foreach (GameObject slime in slimes) {
						slime.SendMessage("ChangToVR");
						
					}
					
					//=========================End===============================
				}
			}else
				isSwiped = false; // else added by Danni
		}
		else if ( m_currentTransitionState == TransitionState.TWEENING ) {
			debugLine += " | Currently Tweening";
			//Debug.Log(debugLine);
			return;
		}
		else { // We're either on or off
			debugLine += " | Locked";
			if ( eventArgs.WipeInfo.Progress >= m_minProgressToStartTransition ) {
				debugLine += " | Go To Manual";
				m_currentTransitionState = TransitionState.MANUAL; 
			}
		}
		
		Debug.Log(debugLine);
	}
	
	private void onOnPosition() {
		//Debug.Log("onOnPosition");
		m_currentTransitionState = TransitionState.ON;
		m_lastLockedState = TransitionState.ON;
		m_from = m_startPosition;
		m_to = m_wipeOutPosition;
		m_handController.gameObject.SetActive(false);
		if (m_cameraAlignment != null)
			m_cameraAlignment.enabled = true;
	}
	
	private void onOffPosition() {
		//Debug.Log("onOffPosition");
		m_currentTransitionState = TransitionState.OFF;
		m_lastLockedState = TransitionState.OFF;
		m_from = m_wipeOutPosition;
		m_to = m_startPosition;
		if ( m_imageRetriever != null ) {
			foreach (LeapImageRetriever image in m_imageRetriever) {
				image.enabled = false;
			}
		}
		else {
			Debug.LogError("No image retreiver on: " + gameObject.name);
		}
		m_handController.gameObject.SetActive(true);
		if (m_cameraAlignment != null)
			m_cameraAlignment.enabled = false;
	}
	
	public void TweenToOnPosition() {
		//Debug.Log("tweenToOnPosition");
		if ( m_imageRetriever != null ) {
			foreach (LeapImageRetriever image in m_imageRetriever) {
				image.enabled = true;
			}
		}
		StopAllCoroutines();
		StartCoroutine(doPositionTween(0.0f, 0.1f, onOnPosition));
	}
	
	public void TweenToOffPosition() {
		//		Debug.Log("tweenToOffPosition");
		StopAllCoroutines();
		StartCoroutine(doPositionTween(1.0f, 0.1f, onOffPosition));
	}
	
	public void TweenToPosition(float fraction, float time = 0.4f) {
		m_currentTransitionState = TransitionState.TWEENING;
		StopAllCoroutines();
		StartCoroutine(doPositionTween(fraction, time));
	}
	
	private IEnumerator doPositionTween(float goalPercent, float transitionTime, TweenCompleteDelegate onComplete = null) {
		//		Debug.Log("doPositionTween: " + goalPercent);
		float startTime = Time.time;
		
		Vector3 from = transform.localPosition;
		Vector3 to = Vector3.Lerp(m_startPosition, m_wipeOutPosition, goalPercent);
		
		while ( true ) { 
			float fraction = Mathf.Clamp01((Time.time - startTime)/transitionTime);
			//			Debug.Log("Tween step: " + fraction);
			
			transform.localPosition = Vector3.Lerp(from, to, fraction);
			if (m_cameraAlignment != null)
				m_cameraAlignment.tween = fraction;
			
			// Kick out of the loop if we're done
			if ( fraction == 1 ) {
				break;
			} else { // otherwise continue
				yield return 1;
			}
		}
		
		if (onComplete != null) {
			//added by Danni
			Completed_Status = 1;
			
			
			onComplete ();
		} else
			Completed_Status = 0; // added by Danni
	}
}

