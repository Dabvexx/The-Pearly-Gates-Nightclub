using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeedManager : MonoBehaviour
{
    #region Variables
    // Variables.

    [Header("Sins")]
    [Space(3), Tooltip("Sins that have low negative total.")] public List<DeedClass> pettySins;
    [Space(3), Tooltip("Sins that have normal negative total.")] public List<DeedClass> sins;
    [Space(3), Tooltip("Sins that have high negative total.")] public List<DeedClass> terribleSins;
    [Space(3), Tooltip("Sins that have extreme negative total.")] public List<DeedClass> horrificSins;

    [Space(10), Header("Virtues")]
    [Space(3), Tooltip("Virtues that have low positive total.")] public List<DeedClass> pettyVirtues;
    [Space(3), Tooltip("Virtues that have normal positive total.")] public List<DeedClass> virtues;
    [Space(3), Tooltip("Virtues that have high positive total.")] public List<DeedClass> heroicVirtues;
    [Space(3), Tooltip("Virtues that have extreme positive total.")] public List<DeedClass> angelicVirtues;
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

    #endregion
}
