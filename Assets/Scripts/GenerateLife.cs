using UnityEngine;
using System.Collections;

public class GenerateLife: MonoBehaviour {

	public GameObject life;
	
	// Use this for initialization
	void Start()
	{
		GameObject life = GameObject.Find("life5");
		if(life.renderer.enabled == false)
			InvokeRepeating("CreateObstacle", Random.Range(30.0F, 60.0F), Random.Range(30.0F, 60.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(life);
	}
}
