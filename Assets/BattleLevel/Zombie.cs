using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Zombie : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		home = GameObject.FindGameObjectWithTag("Home");
		speed = .005f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distance = home.transform.position - transform.position;
		distance.Normalize();

		transform.position = transform.position + Vector3.Scale (distance, new Vector3(speed, speed, speed));	

		foreach (Canvas obj in GetComponentsInChildren<Canvas>())
		{
			foreach (Text text in obj.GetComponentsInChildren<Text>())
				text.text = word;
		}
	}

	private GameObject home;

	// set by BaseScript
	public float speed; 
	public string word;

	public GameObject textLabel;
}
