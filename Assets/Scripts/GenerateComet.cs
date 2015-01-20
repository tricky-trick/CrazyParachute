using UnityEngine;
using System.Collections;

public class GenerateComet: MonoBehaviour {

	public GameObject comet;

	void Start()
	{
		InvokeRepeating("CreateObstacle", Random.Range(30.0F, 60.0F), Random.Range(30.0F, 60.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(comet);
	}
}
