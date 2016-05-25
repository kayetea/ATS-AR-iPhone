using UnityEngine;
using System.Collections;

public class PauseAnimationOnClick : MonoBehaviour {

	private Animator anim; 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	public void OnMouseDown()
	{
		//turn on or off the animation when clicking on 3d model
		if (anim.enabled)
		{
			anim.enabled = false;
		}
		else{
			anim.enabled = true; 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}