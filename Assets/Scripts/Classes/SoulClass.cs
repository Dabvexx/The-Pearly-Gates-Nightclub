using UnityEngine;
using System.Collections.Generic;

///<summary>
/// 
///</summary>
[System.Serializable]
public class SoulClass
{
	public string firstName;
	public string lastName;

	// The age they were when they died.
	public string age;

	public Sprite sprite;

	// Can be set in multiple different ways;
	// (eg: gangster = 1.2, doctor = 0.8, murderer = 2)
	public float deedModifier = 1;

	public List<DeedStruct> sins;
	public List<DeedStruct> virtues;

	//public SoulClass()
	//{

	//}

	public int SinTotal()
	{
		int sinTotal = 0;

        foreach (var sin in sins)
        {
			sinTotal += sin.score * sin.timesDone;
        }

		return sinTotal;
	}

	public int VirtueTotal()
    {
		int virtueTotal = 0;

        foreach (var virtue in virtues)
        {
			virtueTotal += virtue.score * virtue.timesDone;
        }

		return virtueTotal;
    }
}