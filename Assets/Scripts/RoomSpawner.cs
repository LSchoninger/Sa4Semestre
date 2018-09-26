using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {
	public int openingDirection;
	//1----Need bottom door
	//2----Need top door
	//3----Need left door
	//4----Need right door

	private RoomTemplate templates;
	public int rand;
	public bool spawned;
	void Start ()
	{
		templates = GameObject.FindWithTag("Room").GetComponent<RoomTemplate>();
		Invoke("Spawn",2f);
	}

	void Spawn () {
		if (spawned == false)
		{
			if (openingDirection == 1)
			{
				//Need a prefab with a bottom door
				rand = Random.Range(0, templates.bottomDoor.Length);
				Instantiate(templates.bottomDoor[rand], transform.position,
					templates.bottomDoor[rand].transform.rotation);

			}
			else if (openingDirection == 2)
			{
				//need a prefab with a top door
				rand = Random.Range(0, templates.topDoor.Length);
				Instantiate(templates.topDoor[rand], transform.position, templates.topDoor[rand].transform.rotation);

			}
			else if (openingDirection == 3)
			{
				//need a prefab with a left door
				rand = Random.Range(0, templates.leftDoor.Length);
				Instantiate(templates.leftDoor[rand], transform.position, templates.leftDoor[rand].transform.rotation);

			}
			else if (openingDirection == 4)
			{
				//need a prefab with a right door
				rand = Random.Range(0, templates.rightDoor.Length);
				Instantiate(templates.rightDoor[rand], transform.position,
					templates.rightDoor[rand].transform.rotation);

			}

			spawned = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("SpawnPoint"))
		{
			if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
			{
				Instantiate(templates.closedRoom, transform.position, Quaternion.Euler(new Vector3(270,0,-180)));
				gameObject.SetActive(false);
			}

			spawned = true;
		}
	}
}
