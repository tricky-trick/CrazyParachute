using UnityEngine;
using System.Collections;

public class GenerateSnowroad : MonoBehaviour {

	public GameObject snowRoad;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 0.0f, 10.7f);
	}
	
	void CreateObstacle()
	{
		Instantiate(snowRoad);
	}
}
