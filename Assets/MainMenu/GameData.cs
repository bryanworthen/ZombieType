using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

[System.Serializable]
public class GameData
{
	// entry per player
	public Dictionary<string, PlayerData> playerData;

}

[System.Serializable]
public class PlayerData
{
	// entry per level
	public Dictionary<int, LevelData> levelData;
}

[System.Serializable]
public class LevelData
{
	public int wpmWithErrorCorrection;     // bronze
	public int wpmWithoutErrorCorrection;  // silver
	public int wpmErrorFree;               // gold
}

public class GameIO : MonoBehaviour
{
	public static void Load() 
	{
		if(File.Exists(filename)) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(filename, FileMode.Open);
			data = (GameData)bf.Deserialize(file);
			file.Close();
			if (data == null)
				print ("Could not open " + filename);
		}
		if (data == null)
		{
			data = new GameData();
		}

	}

	public static void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (filename);
		bf.Serialize(file, data);
		file.Close();
	}

	public static GameData data = null;
	public static string filename = Application.persistentDataPath + "/type.dat";
}
