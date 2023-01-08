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
    private IReapUI ireap;

    // Index into list of the soul you are currently looking at.
    private int curSoulIndex = 0;
    #endregion

    #region Unity Methods

    void Start()
    {
        ireap = FindObjectOfType<IReapUI>();
        soulGenerator = FindObjectOfType<SoulGenerator>();

        // Start with 7 souls to refrence 7 deadly sins, the rest will load in when needed up to the max number of souls
        for (int i = 0; i < maxSouls; i++)
        {
            maxSouls--;
            var soul = soulGenerator.GenerateSoul().Clone();
            souls.Add((SoulClass)soul);
        }

        ireap.LoadIReapDisplay(souls[curSoulIndex]);

        Debug.Log("Finished Generating Souls");
        Debug.Log(souls[0].SinTotal());
        Debug.Log(souls[0].VirtueTotal());
        Debug.Log(souls[0].CalculatePoints());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            curSoulIndex++;
            ireap.LoadIReapDisplay(souls[curSoulIndex]);
        }
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
        ireap.UpdateScore(finalScore);
        Debug.Log(souls[curSoulIndex].SinTotal());
        Debug.Log(souls[curSoulIndex].VirtueTotal());
        Debug.Log(souls[curSoulIndex].CalculatePoints());
    }

    public void Reject()
    {
        finalScore -= souls[curSoulIndex].CalculatePoints();
        curSoulIndex++;
        ireap.UpdateScore(finalScore);
        Debug.Log(souls[curSoulIndex].SinTotal());
        Debug.Log(souls[curSoulIndex].VirtueTotal());
        Debug.Log(souls[curSoulIndex].CalculatePoints());
    }

    #endregion
}
