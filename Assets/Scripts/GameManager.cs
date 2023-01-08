using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public List<SoulClass> souls;
    [SerializeField] private float timeLimit;
    private float timer;

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

        NewGame();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        ireap.UpdateTimer(timer);

        if(timer <= 0)
        {
            EndGame();
        }
    }

    #endregion

    #region Private Methods
    // Private Methods.
    private void LoadNextSoul()
    {
        if (curSoulIndex >= souls.Count - 1)
        {
            EndGame();
            return;
        }

        ireap.UpdateScore(finalScore);
        Debug.Log(souls[curSoulIndex].SinTotal());
        Debug.Log(souls[curSoulIndex].VirtueTotal());
        Debug.Log(souls[curSoulIndex].CalculatePoints());
        ireap.LoadIReapDisplay(souls[curSoulIndex]);
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    public void Accept()
    {
        if (curSoulIndex >= souls.Count - 1)
        {
            EndGame();
            return;
        }

        finalScore += souls[curSoulIndex].CalculatePoints();
        curSoulIndex++;
        LoadNextSoul();
    }

    public void Reject()
    {
        if (curSoulIndex >= souls.Count - 1)
        {
            // Reload scene
            EndGame();
            return;
        }

        finalScore -= souls[curSoulIndex].CalculatePoints();
        curSoulIndex++;
        LoadNextSoul();
    }

    public void NewGame()
    {
        curSoulIndex = 0;
        timer = timeLimit;
        finalScore = 0;

        souls.Clear();
        // Start with 7 souls to refrence 7 deadly sins, the rest will load in when needed up to the max number of souls
        for (int i = 0; i < 500; i++)
        {
            var soul = soulGenerator.GenerateSoul().Clone();
            souls.Add((SoulClass)soul);
        }

        ireap.LoadIReapDisplay(souls[curSoulIndex]);

        Debug.Log("Finished Generating Souls");
        Debug.Log(souls[0].SinTotal());
        Debug.Log(souls[0].VirtueTotal());
        Debug.Log(souls[0].CalculatePoints());
    }

    private void EndGame()
    {
        // Run end game stuff;
        Debug.Log("Ending Game");
        var text = $"Your Final Score is:\n {finalScore} \n\n Would you like to play again?";

        ireap.UpdateDeedList(text);
        ireap.ShowReplayButton();
    }

    #endregion
}
