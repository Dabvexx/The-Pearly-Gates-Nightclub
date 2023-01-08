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

	// Used to generate name and sprite (maybe), as well as showing as a small icon on the Ipad.
	public bool isMale;

	// The age they were when they died.
	public int age;

	public Sprite sprite;

	// Can be set in multiple different ways;
	// (eg: gangster = 1.2, doctor = 0.8, murderer = 2)
	// The higher this number the more likely to have worse sins.
	//public float sinModifier = 1;

	// The higher this number the more likely to have better virtues.
	//public float deedModifier = 1;

	public List<DeedClass> sins;
	public List<DeedClass> virtues;

	public SoulClass(string _firstName, string _lastName, int _age, bool _isMale, List<DeedClass> _sins, List<DeedClass> _virtues)
	{
		this.firstName = _firstName;
		this.lastName = _lastName;
		this.age = _age;
		this.isMale = _isMale;
		this.sins = _sins;
		this.virtues = _virtues;
	}

	// For some reason searializing then unserializing from json makes the refrence types stop
	public object Clone()
    {
		var clonedJson = JsonUtility.ToJson(this);

		return JsonUtility.FromJson<SoulClass>(clonedJson);
	}

	// Check if null first, return 0
	public int SinTotal()
	{
		int sinTotal = 0;

		if (sins == null)
		{
			return 0;
		}

		foreach (var sin in sins)
        {
			sinTotal += Mathf.RoundToInt(sin.score * sin.timesDone * Random.Range(.75f, 2.2f));
        }

		return sinTotal;
	}

	public int VirtueTotal()
    {
		int virtueTotal = 0;

		if(virtues == null)
        {
			return 0;
        }

        foreach (var virtue in virtues)
        {
			// Add a little noise to the calculation
			virtueTotal += Mathf.RoundToInt(virtue.score * virtue.timesDone * Random.Range(.75f, 2.2f));
        }

		return virtueTotal;
    }

	public int DeedTotal()
    {
		return SinTotal() + VirtueTotal();
    }

	public int CalculatePoints()
    {
		return Mathf.Sign(DeedTotal()) == -1 ? SinTotal() : VirtueTotal();
    }
}