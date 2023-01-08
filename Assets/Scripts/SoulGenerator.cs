using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoulGenerator : MonoBehaviour
{
    #region Variables
    // Variables.
    // Have a variable with the data of should let through, or calculate if they should be let through through doing math on their totals
    [Space(7), Tooltip("Male first names.")] public List<string> firstNamesMale;
    [Space(7), Tooltip("Female first names.")] public List<string> firstNamesFemale;
    [Space(7), Tooltip("Last names.")] public List<string> lastNames;

    DeedGenerator deedGenerator;
    #endregion

    #region Unity Methods

    void Start()
    {
        deedGenerator = GetComponent<DeedGenerator>();
    }

    #endregion

    #region Private Methods
    // Private Methods.
    private int GenerateRandomAge()
    {
        return Random.Range(16, 116);
    }

    private string GenerateFirstName(bool isMale)
    {
        if (isMale)
        {
            return firstNamesMale[Random.Range(0, firstNamesMale.Count)];
        }

        return firstNamesFemale[Random.Range(0, firstNamesFemale.Count)];
    }

    private string GenerateLastName()
    {
        return lastNames[Random.Range(0, lastNames.Count)];
    }

    private void GetSprite(bool isMale, int age)
    {
        // Get sprite based on their age and gender.
    }

    public SoulClass GenerateSoul()
    {
        float evilModifier = Random.Range(0.3f, 1.5f);
        //float goodModifier = (1 - evilModifier) * Mathf.Sign(1 - evilModifier);//= Random.Range(0.01f, 1.5f);
        float goodModifier = Random.Range(0.3f, 1.5f);

        //Debug.Log(evilModifier);
        //Debug.Log(goodModifier);

        //var sins = deedGenerator.GenerateAllSins(evilModifier);
        var sins = deedGenerator.GenerateAllSins(evilModifier);
        //var virtues = deedGenerator.GenerateAllVirtues(goodModifier);
        var virtues = deedGenerator.GenerateAllVirtues(goodModifier);

        bool isMale = Random.Range(0, 2) != 0;
        return new SoulClass(GenerateFirstName(isMale), GenerateLastName(), GenerateRandomAge(), isMale, sins, virtues);
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}
