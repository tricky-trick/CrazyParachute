using UnityEngine;
using System.Collections;

public class PlayGameButton : MonoBehaviour {

	int fontSize;

	int score;

	int highscore;

	void Start()
	{
		score = PlayerPrefs.GetInt("score");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

		Vector2 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0))) 
		{
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.tag == "next_level_button" ){
					if (Application.loadedLevelName == "SceneEnd"){
						highscore = PlayerPrefs.GetInt("highscore");
						if (score > highscore){
							highscore = score;
						}
						PlayerPrefs.SetInt("highscore", highscore);
						PlayerPrefs.SetInt("score", 0);
						Application.LoadLevel(0);
					}
					else{
						Application.LoadLevel(Application.loadedLevel + 1);
					}
				}
			}
		}
	}

	void OnGUI () {
		GetFontSize();
		int score = PlayerPrefs.GetInt("score");
		int highscore = PlayerPrefs.GetInt("highscore");
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.normal.textColor = Color.green;
		centeredStyle.fontSize = fontSize;
		GUI.Label (new Rect (Screen.width/2-150, Screen.height/2-25, 300, 200), "Score: " + score.ToString() + "\nHighscore: " + highscore.ToString(), centeredStyle);
	}

	void GetFontSize()
	{
		if (Screen.height <= 800 )
		{
			fontSize = 30;
		}
		
		else if (Screen.height > 800 && Screen.height <= 1280)
		{
			fontSize = 40;
		}
		
		else if (Screen.height > 1280 && Screen.height <= 2000)
		{
			fontSize = 50;
		}
		
		else
		{
			fontSize = 60;
		}
	}
}
