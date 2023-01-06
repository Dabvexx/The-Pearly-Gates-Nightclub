//using UnityEngine;

///<summary>
/// Contasins data of sins and good deeds with a score attributed, negative scores are sins while positive is good deeds.
///</summary>
[System.Serializable]
public struct DeedStruct
{
	public string deedName;
	// Negative scores are sins, positive scores are good deeds.
	public int score;
	// The amount of times a deed has been done.
	// This is set when making the souls deeds.
	public int timesDone;

	public DeedStruct(string _deedName, int _score, int _timesDone)
	{
		this.deedName = _deedName;
		this.score = _score;
		this.timesDone = _timesDone;
	}

}