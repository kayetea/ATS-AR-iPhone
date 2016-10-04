using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MediaButtonToggles : MonoBehaviour {

	public void ToggleVisibility(GameObject toggleObject)
	{
		Debug.Log ("enter toggle visibility");
		if (toggleObject.activeSelf)
        {
            Debug.Log("turn off");
			toggleObject.SetActive(false);
        }
		else if (!toggleObject.activeInHierarchy)
        {
            Debug.Log("turn on");
			toggleObject.SetActive(true);
        }
    }

    public void ToggleAnimation(string animState)
    {
		if(this.GetComponent<Animator>()){
			Animator animControl = this.GetComponent<Animator>();
			if(animControl.GetCurrentAnimatorStateInfo(0).IsName(animState))
			{
				if (animControl.enabled)
				{
					Debug.Log("turn off");
					animControl.enabled = false;
				}
				else if (!animControl.enabled)
				{
					Debug.Log("turn on");
					animControl.enabled = true;
				}
			}
			else{
				//change state
				animControl.CrossFade(animState, .1f);
			}
		}
		//check of animation component
		else if(this.GetComponent<Animation>()){
			foreach (AnimationState state in this.GetComponent<Animation>()){
				//pauses animation at speed 0 and plays it again at speed 1
				if(state.speed > 0){
					//pause anim
					state.speed = 0;
				}
				else{
					//play anim
					state.speed = 1;
				}
			}
		}
    }
}