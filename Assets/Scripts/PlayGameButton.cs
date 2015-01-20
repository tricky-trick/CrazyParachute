using UnityEngine;
using System.Collections;

public class PlayGameButton : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1 || Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
