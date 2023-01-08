using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IReapUI : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private Sprite maleSymbol;
    [SerializeField] private Sprite femaleSymbol;

    [SerializeField] private Image genderSymbol;
    [SerializeField] private TextMeshProUGUI soulName;
    [SerializeField] private TextMeshProUGUI pointText;
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
        // TODO: make the scrollable UI
    }

    public void ClearIReapDisplay()
    {

    }

    public void UpdateScore(int score)
    {
        pointText.text = $"Score: {score}";
    }
    #endregion
}
