using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	//Movement
	public float speed;
	public float jump;
	float moveVelocity;

	//Grounded Vars
	bool grounded = true;

	int playernumber;

	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			playernumber = 1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			playernumber = 2;
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			playernumber = 3;
		}
		//Jumping	
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W))  & playernumber == 1  ) 
		{
			if(grounded)
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
			}
		}



		moveVelocity = 0;

		//Left Right Movement
		if ((Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) & playernumber == 1 ) 
		{
			moveVelocity = -speed;
		}
		if ((Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) & playernumber == 1 ) 
		{
			moveVelocity = speed;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

	}

	//Check if on the ground
	void OnTriggerEnter2D()
	{
		grounded = true;
	}
	void OnTriggerExit2D()
	{
		grounded = false;
	}
}