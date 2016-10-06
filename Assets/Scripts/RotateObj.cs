
using UnityEngine; 
using System.Collections; 

public class RotateObj: MonoBehaviour{ 
	public Transform target;
	public float distance = 5.0f; 
	public float xSpeed = 60.0f; 
	public float ySpeed = 60.0f; 
	public float yMinLimit = 10f;
	public float yMaxLimit = 60f; 
	public float distanceMin = 5f; 
	public float distanceMax = 10f; 
	float x = 0.0f; 
	float y = 0.0f; 

	void Start() { 
		Vector3 angles = transform.eulerAngles; 
		x = angles.y; 
		y = angles.x; 

		// Make the rigid body not change rotation 
		if(GetComponent<Rigidbody>()) 
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	} 

	void Update(){ 
		Debug.Log("beep");
		//Just orbit touch without movement
		if (target && Input.touchCount == 1 && Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{ 
			Debug.Log("Orbiting! 1 touch"); 
			Orbit(Input.GetTouch(0)); 
		} 
		else if (Input.touchCount == 2) 
		{ 
			if(Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Orbit(Input.GetTouch(0)); //Movement was touched second 
			}
			else if (Input.GetTouch(1).position.x > Screen.width / 2 && Input.GetTouch(1).phase == TouchPhase.Moved) 
			{
				Orbit(Input.GetTouch(1)); //Movement was touched first 
			}
		} 
	} 

	void Orbit(Touch touch) {
		x += touch.deltaPosition.x * xSpeed * 0.02f /* * distance*/; 
		y -= touch.deltaPosition.y * ySpeed * 0.02f /* * distance*/; 
		y = ClampAngle(y, yMinLimit, yMaxLimit); 

		Quaternion rotation = Quaternion.Euler(y, x, 0); 

		//distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax); 

		RaycastHit hit; 

		if (Physics.Linecast(target.position, transform.position, out hit)) 
		{ 
			// distance -= hit.distance; 
		} 

		Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance); 
		Vector3 position = rotation * negDistance + target.position; transform.rotation = rotation;
		transform.position = position; 
	} 

	public static float ClampAngle(float angle, float min, float max) 
	{ 
		if (angle < -360F)
		{
			angle += 360F; 
		}
		if (angle > 360F) 
		{
			angle -= 360F; 
		}

		return Mathf.Clamp(angle, min, max); 
	} 

}