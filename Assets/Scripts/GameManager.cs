using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public SoulClass soul;
    [SerializeField] private float timeLimit;
    private float timer;

    public int finalScore = 0;

    private SoulGenerator soulGenerator;
    private IReapUI ireap;

    [Space(10), Header("Audio Vars")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip replayClip;
    #endregion

    #region Unity Methods

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        soul = (SoulClass)soulGenerator.GenerateSoul().Clone();
        ireap.UpdateScore(finalScore);
        Debug.Log(soul.SinTotal());
        Debug.Log(soul.VirtueTotal());
        Debug.Log(soul.CalculatePoints());
        ireap.LoadIReapDisplay(soul);
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    public void Accept()
    {
        audioSource.PlayOneShot(buttonClip);
        finalScore += soul.CalculatePoints();
        LoadNextSoul();
    }

    public void Reject()
    {
        audioSource.PlayOneShot(buttonClip);
        finalScore -= soul.CalculatePoints();
        LoadNextSoul();
    }

    public void NewGame()
    {
        timer = timeLimit;
        finalScore = 0;
        LoadNextSoul();
    }

    private void EndGame()
    {
        // Run end game stuff;
        Debug.Log("Ending Game");
        var text = $"Your Final Score is:\n {finalScore} \n\n Would you like to play again?";

        audioSource.PlayOneShot(replayClip);
        ireap.UpdateDeedList(text);
        ireap.ShowReplayButton();
    }

    #endregion
}
