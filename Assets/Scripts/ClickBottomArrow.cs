using UnityEngine;
using System.Collections;

public class ClickBottomArrow : MonoBehaviour {

	private GameObject player;
	private Vector2 down;
	void Update () {
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0))) 
		{
//			int isJetPack = PlayerPrefs.GetInt("isJetPack");
//
			player = GameObject.FindGameObjectWithTag("Player");
//			if (isJetPack == 0){
//				down = new Vector2(0, -50);
//			}
//			else{
//				down = new Vector2(0, -100);
//			}
//			down = new Vector2(0, -100);
			player.rigidbody2D.AddForce(new Vector2(0,-100));

		}
	}
}
