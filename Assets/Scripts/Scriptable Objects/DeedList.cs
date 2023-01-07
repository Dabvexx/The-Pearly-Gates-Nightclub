using UnityEngine;
using System.Collections.Generic;

///<summary>
/// 
///</summary>
[CreateAssetMenu(fileName = "NewDeedList", menuName = "DeedList")]
public class DeedList : ScriptableObject
{

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

    public List<DeedClass> GetPettySins()
    {
        return pettySins;
    }
    public List<DeedClass> GetSins()
    {
        return sins;
    }
    public List<DeedClass> GetTerribleSins()
    {
        return terribleSins;
    }
    public List<DeedClass> GetHorrificSins()
    {
        return horrificSins;
    }

    public List<DeedClass> GetPettyVirtues()
    {
        return pettyVirtues;
    }

    public List<DeedClass> GetVirtues()
    {
        return virtues;
    }
    public List<DeedClass> GetHeroicVirtues()
    {
        return heroicVirtues;
    }
    public List<DeedClass> GetAngelicVirtues()
    {
        return angelicVirtues;
    }
}