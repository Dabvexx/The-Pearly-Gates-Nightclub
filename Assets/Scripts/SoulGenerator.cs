using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulGenerator : MonoBehaviour
{
    #region Variables
    // Variables.
    // Have a variable with the data of should let through, or calculate if they should be let through through doing math on their totals
    public List<string> firstNames;
    public List<string> lastNames;

    public List<SoulClass> souls;
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
    private int GenerateRandomAge()
    {
        return 25;
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}
