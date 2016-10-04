using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

	public string sceneName;

    //private GoogleAnalyticsV4 googleAnalytics;

	// Use this for initialization
	void Start () {
       // googleAnalytics = GameObject.Find("GAv4").GetComponent<GoogleAnalyticsV4>();
	}
	
	public void Exit() {
		Application.Quit(); 
	}

	public void ChangeScene(){
        SceneManager.LoadScene(sceneName);
		Resources.UnloadUnusedAssets ();

       // googleAnalytics.LogScreen(sceneName);
	}

	public void OnMouseDown(){
        SceneManager.LoadScene(sceneName);
        Resources.UnloadUnusedAssets ();
      //  googleAnalytics.LogScreen(sceneName);
    }
}
