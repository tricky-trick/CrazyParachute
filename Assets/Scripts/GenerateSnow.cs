using UnityEngine;
using System.Collections;

public class GenerateSnow : MonoBehaviour {

	public GameObject snow;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 0.0f, 7.0f);
	}
	
	void CreateObstacle()
	{
		Instantiate(snow);
	}
}
