//using UnityEngine;

///<summary>
/// 
///</summary>
[System.Serializable]
public class DeedClass
{
	public string deedName;
	// Negative scores are sins, positive scores are good deeds.
	public int score;

	//public int rarity;
	// The amount of times a deed has been done.
	// This is set when making the souls deeds.
	public int timesDone = 1;

	public DeedClass(string _deedName, int _score, int _timesDone)
	{
		this.deedName = _deedName;
		this.score = _score;
		this.timesDone = _timesDone;
	}

}