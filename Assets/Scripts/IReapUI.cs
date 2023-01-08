using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class IReapUI : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private Sprite maleSymbol;
    [SerializeField] private Sprite femaleSymbol;

    [SerializeField] private Button acceptButton;
    [SerializeField] private Button rejectButton;
    [SerializeField] private Button retryButton;

    [SerializeField] private Image genderSymbol;
    [SerializeField] private TextMeshProUGUI soulName;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI DeedText;
    #endregion

    #region Unity Methods

    void Start()
    {
        
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
    public void LoadIReapDisplay(SoulClass soul)
    {
        genderSymbol.sprite = soul.isMale ? maleSymbol : femaleSymbol;
        soulName.text = $"{soul.firstName} {soul.lastName}";

        var combinedDeeds = soul.sins.Concat(soul.virtues).ToList();

        // Semi random sort
        var sorted = combinedDeeds.OrderBy(a => Guid.NewGuid()).ToList();

        string deeds = "";

        foreach (var deed in sorted)
        {
            deeds += $"{deed.deedName}: x{deed.timesDone}\n";
        }

        UpdateDeedList(deeds);

        // TODO: make the scrollable UI
    }

    public void ClearIReapDisplay()
    {

    }

    public void UpdateScore(int score)
    {
        pointText.text = $"Score: {score}";
    }

    public void UpdateDeedList(string deeds)
    {
        DeedText.text = deeds;
    }

    public void ShowReplayButton()
    {
        acceptButton.gameObject.SetActive(false);
        rejectButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(true);
    }

    public void UpdateTimer(float time)
    {
        timeText.text = $"Time Left: {Math.Round(time, 1)}";
    }
    #endregion
}
