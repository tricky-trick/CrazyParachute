using UnityEngine;
using System.Collections;

public class GenerateBullet: MonoBehaviour {

	public GameObject bullet;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", Random.Range(0.0F, 1.0F), Random.Range(15.0F, 15.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(bullet);
	}
}
