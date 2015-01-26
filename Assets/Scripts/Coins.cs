using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		Vector2 velocity = new Vector2(Random.Range(-1.0F, 1.0F), Random.Range(1.0F, 3.0F));
		rigidbody2D.velocity = velocity;
	}

	void Update()
	{
		if(rigidbody2D.transform.position.y > 10)
			Destroy(rigidbody2D.gameObject);
	}

}
