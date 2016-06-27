using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("File path: " + GameIO.filename);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(int level)
	{
		// start the game
		print ("Loading level:" + level);
		Application.LoadLevelAsync(level);
	}

	public void SetChosenLevel(int value)
	{
		print ("Selecting sublevel:" + value);
		chosenLevel = value;
	}

	// these need to not change - they map to the buttons
	//    and they map to the file data
	public const int LeftHome = 1;
	public const int RightHome = 2;
	public const int ER = 3;
	public const int IO = 4;
	public const int GH = 5;
	public const int WU = 6;
	public const int TY = 7;
	public const int QP = 8;
	public const int CV = 9;
	public const int BNM = 10;
	public const int ZXC = 11;
	public const int BottomPunc = 12;
	public const int Numbers = 13;
	public const int TopPunc = 14;
	public const int NumPunc = 15;
	public const int Boss1 = 31;
	public const int Boss2 = 32;
	public const int Boss3 = 33;
	public const int Boss4 = 34;
	
	// user parameters
	static public int chosenLevel;
	static public int chosenDifficulty;
	static public bool chosenAllowedBackspace;

	public struct UserData
	{
		string name;
		// data for each level, values for each level
		Dictionary<int, int> silverStars; // deletes used
		Dictionary<int, int> goldStars;   // no deletes used
		Dictionary<int, int> silverWPM;
		Dictionary<int, int> goldWPM;
	}

	static public UserData userData;
}
