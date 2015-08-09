using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


	public float bulletSpeed;
	public Camera mainCamera; // Init
	public GameObject bullet;

	void Update ()
	{
		Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition); // Get mouse position according to the camera

		float bulletAngle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * 180 / Mathf.PI; // Get angle from mouse and player positions

		if(Input.GetButtonDown("Fire1")) // Fires bullets
		{
			Rigidbody2D rigidBody; // Create rigidbody for bullet
			rigidBody = (Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, bulletAngle)) as GameObject).GetComponent<Rigidbody2D> (); // Create bullet 

			Vector2 bulletDirection = mousePos - new Vector2(transform.position.x, transform.position.y); // Create vector with direction from mouse and player

			bulletDirection = bulletDirection.normalized * bulletSpeed; // Normalizes vector and multiplay it by bullet speed

			rigidBody.velocity = bulletDirection; // Bullet moves according to the vector
		}

	}
}
