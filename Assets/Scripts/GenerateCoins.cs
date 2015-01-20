using UnityEngine;
using System.Collections;

public class GenerateCoins: MonoBehaviour {

	public GameObject coins;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, Random.Range(1.0F, 3.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(coins);
	}
}
