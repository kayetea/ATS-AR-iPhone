using UnityEngine;
using System.Collections;

public class CamOrbit : MonoBehaviour {

	public Transform target;
	public float xSpeed = 125.0f;
	public float ySpeed = 50f;

	public float  resetTime = 1.0f; //How long to take to reset

	private Vector3 startDirection = Vector3.zero; //How far away to orbit

	private float x = 0.0f; 
	private float y = 0.0f;
	private float z = 0.0f; 

	private Quaternion startRotation;
	private Quaternion rotation;

	private bool resetting = false;
	private float resetTimer = 0.0f;

	void LateUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{    startDirection = (transform.position - target.position);
			startRotation = transform.rotation;
			x = 0.0f;
			y = 0.0f;
			z = 0.0f;
		} 

		if (Input.GetMouseButton(0))
		{
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			z = 0.0f;
			Reorient();
		} 
	}

	void Reorient()
	{
		rotation = Quaternion.Euler(y, x, z);
		transform.rotation = rotation * startRotation;
		transform.position = rotation * startDirection + target.position;
	}
}