using UnityEngine;
using System.Collections;

public class GenerateWall: MonoBehaviour {

	public GameObject wall;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 0.0f, 15.0f);
	}
	
	void CreateObstacle()
	{
		Instantiate(wall);
	}
}
