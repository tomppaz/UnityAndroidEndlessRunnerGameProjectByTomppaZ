using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


	//Movement script also PlayerController script XD
	public float movementSpeed;
	public float jumpForce;

	private float moveSpeedStore;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;

	public float speedIncreaseMilestone;
	public float speedMilestoneCount;
	public float speedMultiplier;

	public float jumpTime;
	private float jumpTimeCounter;

	public Rigidbody2D myRigidbody;

	public bool isGrounded;
	public LayerMask whatIsGround;

	private GameObject myGameObject;
	private Collider2D myCollider;
	private CapsuleCollider2D myCapsuleCollider;

	private Animator myAnimator;

	public GameManager theGameMan;

	public BGScroll bgScroll;

	public Transform groundLevel;
	private float distanceFromGround;
	public float distanceNeededFromGround;

	// Use this for initialization
	void Start () {

		myGameObject = this.gameObject;

		myCapsuleCollider = myGameObject.GetComponent<CapsuleCollider2D> ();

		myRigidbody = GetComponent<Rigidbody2D> ();

		myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = movementSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		if (transform.position.x > speedMilestoneCount && movementSpeed < 13) {
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			movementSpeed = movementSpeed * speedMultiplier;
			//bgScroll.speed = bgScroll.speed * speedMultiplier;
		}
			
		myRigidbody.velocity = new Vector2 (movementSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) || (Input.GetMouseButtonDown (0))) {
			if (isGrounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}
		if (isGrounded) {
			jumpTimeCounter = jumpTime;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", isGrounded);

		distanceFromGround = Vector3.Distance(groundLevel.position, transform.position);

		if (distanceFromGround > distanceNeededFromGround) {
			myCollider.offset = new Vector2 (-0.01776f, 0.0159f);
			myCapsuleCollider.size = new Vector2 (0.237f, 0.4182f);
		} else {
			myCollider.offset = new Vector2 (-0.01776f, -2.384186e-08f);
			myCapsuleCollider.size = new Vector2 (0.1104228f, 0.45f);
		}

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "kill") {
			theGameMan.RestartGame ();
			movementSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			print ("Game Over");
		}
	}
}
