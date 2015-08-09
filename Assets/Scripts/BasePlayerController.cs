using UnityEngine;
using System.Collections;

public class BasePlayerController : MonoBehaviour 
{
	public float acceleration;
	public float maxMovementSpeed;

	Rigidbody2D rigidBody;


	void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		Vector2 changeVelocity = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));	//creates a Vector2 with the change to velocity (if there is any)
		changeVelocity = changeVelocity.normalized * acceleration;		//applies acceleration to changeVelocity

		rigidBody.velocity = rigidBody.velocity + changeVelocity;
		if (rigidBody.velocity.magnitude > maxMovementSpeed) 			//caps the movementSpeed
		{
			rigidBody.velocity = rigidBody.velocity.normalized*maxMovementSpeed;
		}
	}


	void Update () 
	{
	
	}
}
