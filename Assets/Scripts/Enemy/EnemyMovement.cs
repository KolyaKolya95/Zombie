using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	 Transform player; 

	 float speed = 0.05f;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update()
	{
	transform.position = Vector3.MoveTowards (transform.position,player.position, + speed + Time.deltaTime);
	}
}
