using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public List<SoulClass> souls;
    [SerializeField] private int maxSouls;

    public int finalScore = 0;

    private SoulGenerator soulGenerator;

    // Index into list of the soul you are currently looking at.
    private int curSoulIndex = 0;
    #endregion

    #region Unity Methods

    void Start()
    {
        soulGenerator = FindObjectOfType<SoulGenerator>();

        // Start with 7 souls to refrence 7 deadly sins, the rest will load in when needed up to the max number of souls
        for (int i = 0; i < maxSouls; i++)
        {
            maxSouls--;
            var soul = soulGenerator.GenerateSoul().Clone();
            souls.Add((SoulClass)soul);
        }

        Debug.Log("Finished Generating Souls");
        Debug.Log(souls[0].SinTotal());
        Debug.Log(souls[0].VirtueTotal());
        Debug.Log(souls[0].CalculatePoints());
    }

    void Update()
    {
        
    }

    #endregion

    #region Private Methods
    // Private Methods.
    
    #endregion

    #region Public Methods
    // Public Methods.
    
    public void Accept()
    {
        finalScore += souls[curSoulIndex].CalculatePoints();
        curSoulIndex++;
    }

    public void Reject()
    {
        finalScore -= souls[curSoulIndex].CalculatePoints();
        curSoulIndex++;
    }

    #endregion
}
