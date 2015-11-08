using UnityEngine;
using System.Collections;

public class MovingCharacter : MonoBehaviour {

	private GameObject player; 

	private Vector3 direction;
	private bool isMoving = false;
	public float speed;
	private teleportControl StatusController;
	void Start () {
		StatusController = GameObject.FindObjectOfType<teleportControl> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void Update () {
		isMoving = WalkingGesture.isMoving;
		if (isMoving && StatusController.current_Status == 0) {
			direction = WalkingGesture.moving_Direction;
			_moveCharacter();
		}
	}

	void _moveCharacter(){
		//speed is in m/s
		//Debug.Log ("moving character function called");
		//float speed = 30.0f;
		CharacterController controller = player.GetComponent<CharacterController> ();
		//transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		Vector3 forward = transform.TransformDirection(direction);
		//float curSpeed = speed * Input.GetAxis("Vertical");
		//controller.SimpleMove(forward * curSpeed);
		Vector3 moveDirection = Vector3.zero;
		moveDirection = new Vector3 (-direction.x * 2f, 0, direction.z);
		direction.x = -direction.x*2f;
		direction.y = 0f;
		direction.z = direction.z;
		moveDirection = transform.TransformDirection (moveDirection);
		//moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime * speed);
		//Debug.Log ("player position is " + player.transform.position);
		//Debug.Log ("direction is " + direction.ToString ());


	}
}
