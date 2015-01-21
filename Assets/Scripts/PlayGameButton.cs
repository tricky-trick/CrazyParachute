using UnityEngine;
using System.Collections;

public class PlayGameButton : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1 || Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

	void OnGUI () {
		int score = PlayerPrefs.GetInt("score");
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = 20;
		GUI.Label (new Rect (Screen.width/2-50, Screen.height/2-25, 100, 50), "Score: " + score.ToString(), centeredStyle);
	}
}
