using UnityEngine;
using System.Collections;

public class GenerateNextLevel: MonoBehaviour {

	public GameObject nextLevel;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 60.0f, 30.0f);
	}
	
	void CreateObstacle()
	{
		Instantiate(nextLevel);
	}
}
