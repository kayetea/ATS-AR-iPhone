using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuEdit : MonoBehaviour {

	public string sceneName;

	void Start() {
		if(sceneName == SceneManager.GetActiveScene().name) 
		{
			DisableButton();
		}
	}

	private void DisableButton()
	{
		GetComponent<Image>().color = new Color32(71, 71, 71, 255);
		GetComponentInChildren<Text>().color = new Color32(100, 100, 100, 255);
	}
}
