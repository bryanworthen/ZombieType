using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		spawns = GameObject.FindGameObjectsWithTag("Spawn");
		print("Spawns " + spawns.Length);

		allowDeletes = true;

		foreach (string word in getWords(MainMenuScript.chosenLevel))
			words.Add(word);
	}

	string[] getWords(int level)
	{
		switch (level)
		{
		case MainMenuScript.LeftHome:
			string [] arrayLeftHome = { 
				"as", "sas", "dad", "sas", "fas", 
				"asdf", "fdsa", "daf", "fad", "sad", 
				"asf", "fsd", "asf", "sass", "dfs", "dsa",
				"asdfdsa", "sdfdfs", "ssdsad", "ddfssf" }; return arrayLeftHome;
		case MainMenuScript.RightHome:
			string [] arrayRightHome = {
				"jad", "kaf", "laf", "lad", "kas",
				"jaj", "jsf", "ksa", "kla", "lak;",
				"ask", "lass", "lask", "ask;", "flask",
				"jals", "fals", "kdsa", "alsk", "flaj",
				"falk", "jas;", "ksdls", "jdksal", "akjsd;das" }; return arrayRightHome;
		}
		string [] arrayDefault = { "you", "did", "something", "bad" };
		return arrayDefault;
	}

	// Update is called once per frame
	void Update () {
		// find the unassociated spawn points
		HashSet<GameObject> usedSpawnPoints = new HashSet<GameObject>();
		foreach (GameObject spawnPoint in zombieSpawnPointMap.Values)
			usedSpawnPoints.Add (spawnPoint);


		foreach ( GameObject spawn in spawns)
		{
			if (usedSpawnPoints.Contains(spawn))
				continue;
			if (words.Count == 0)
				break;
			print("Spawn!");
			GameObject zombieObject = (GameObject) Instantiate(ZombiePrefab, spawn.transform.position, spawn.transform.rotation);
			string word = words[0];
			zombies[word] = zombieObject;
			zombieSpawnPointMap[zombieObject] = spawn;
			Zombie z = zombieObject.GetComponent<Zombie>();
			z.word = words[0];
			words.RemoveAt (0);
		}

		if (words.Count == 0 && zombies.Count == 0)
			print ("YOU WIN!!!");
		//zombie.transform.localScale.Scale(spawns[0].transform.localScale);

		if (Input.anyKeyDown)
		{
			if (Input.inputString == " " || Input.inputString == "\n") // TODO - \n doesn't work...
			{
				print(currentWord);
				if (zombies.ContainsKey(currentWord))
				{
					KillZombie(zombies[currentWord]);
					zombies.Remove(currentWord);
				}
				currentWord = "";
			}
			else if (Input.inputString == "\b")
			{
				if (allowDeletes && currentWord.Length > 0)
				    currentWord = currentWord.Substring(0, currentWord.Length - 1);
			}
			else
				currentWord += Input.inputString;
		}
		
	}

	void KillZombie(GameObject zombie)
	{
		if (zombie == null)
			return;
		print ("Zombie Down");
		// TODO death animation here
		zombieSpawnPointMap.Remove (zombie);
		Destroy (zombie);
	}
	
	private GameObject[] spawns;
	private Dictionary<string, GameObject> zombies = new Dictionary<string, GameObject>();
	private Dictionary<GameObject, GameObject> zombieSpawnPointMap = new Dictionary<GameObject, GameObject>();
	private List<string> words = new List<string>();
	public GameObject ZombiePrefab; // assigned from Unity editor

	public bool allowDeletes;
	private string currentWord;
}
