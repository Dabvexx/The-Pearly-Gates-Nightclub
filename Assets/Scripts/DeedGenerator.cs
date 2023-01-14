using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Nightmare Nightmare Nightmare Nightmare Nightmare Nightmare Nightmare Nightmare Nightmare Nightmare
/// </summary>
public class DeedGenerator : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private DeedList deeds;

    [SerializeField] private int rollMin;
    [SerializeField] private int rollMax;

    [Space(10), Header("Sin Variables")]
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float pettySinChance;
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float sinChance;
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float terribleSinChance;
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float horrificSinChance;

    [Space(10)]
    [SerializeField, Tooltip("The amount of times a petty sin can be done"), Range(1, 150)] private int pettySinsMax;
    [SerializeField, Tooltip("The amount of times a sin can be done"), Range(1, 150)] private int sinsMax;
    [SerializeField, Tooltip("The amount of times a terrible sin can be done"), Range(1, 150)] private int terribleSinsMax;
    [SerializeField, Tooltip("The amount of times a horrific sin can be done"), Range(1, 150)] private int horrificSinsMax;

    [Space(10), Header("Virtue Variables")]
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float pettyVirtueChance;
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float virtueChance;
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float heroicVirtueChance;
    [SerializeField, Tooltip("0 = no chance, 1 = guarenteed chance"), Range(0f, 1f)] private float angelicVirtueChance;

    [Space(10)]
    [SerializeField, Tooltip("The amount of times a petty virtue can be done"), Range(1, 150)] private int pettyVirtuesMax;
    [SerializeField, Tooltip("The amount of times a virtue can be done"), Range(1, 150)] private int virtuesMax;
    [SerializeField, Tooltip("The amount of times a heroic virtue can be done"), Range(1, 150)] private int heroicVirtuesMax;
    [SerializeField, Tooltip("The amount of times a angelic virtue can be done"), Range(1, 150)] private int angelicVirtuesMax;
    #endregion

    #region Public Methods
    // Public Methods.
    // Sin generator.
    public List<DeedClass> GenerateAllSins(float evilModifier)
    {
        Debug.Log("Generating Sins");
        List<DeedClass> sins = new List<DeedClass>();

        var num = Random.Range(rollMin, rollMax);

        for (int i = 0; i < num; i++)
        {
            if (Random.Range(0.001f, 1f) <= horrificSinChance * evilModifier)
            {
                Debug.Log("Generating horrific sins.");
                sins.Add(GenerateHorrificSins());
            }

            if (Random.Range(0.001f, 1f) <= terribleSinChance * evilModifier)
            {
                Debug.Log("Generating terrible sins.");
                sins.Add(GenerateTerribleSins());
            }

            if (Random.Range(0.001f, 1f) <= sinChance * evilModifier)
            {
                Debug.Log("Generating sins.");
                sins.Add(GenerateSins());
            }

            else
            {
                Debug.Log("Generating petty sins.");
                sins.Add(GeneratePettySins());
            }
        }

        return sins;
    }

    // Virtue generator.
    public List<DeedClass> GenerateAllVirtues(float goodModifier)
    {
        Debug.Log("Generating Virtues");
        List<DeedClass> virtues = new List<DeedClass>();

        // Roll amount
        var num = Random.Range(rollMin, rollMax);

        for (int i = 0; i < num; i++)
        {
            if (Random.Range(0.001f, 1f) <= angelicVirtueChance * goodModifier)
            {
                Debug.Log("Generating angelic virtues.");
                virtues.Add(GenerateAngelicVirtues());
            }

            if (Random.Range(0.001f, 1f) <= heroicVirtueChance * goodModifier)
            {
                Debug.Log("Generating heroic virtues.");
                virtues.Add(GenerateHeroicVirtues());
            }

            if (Random.Range(0.001f, 1f) <= virtueChance * goodModifier)
            {
                Debug.Log("Generating virtues.");
                virtues.Add(GenerateVirtues());
            }

            else
            {
                Debug.Log("Generating petty virtues.");
                virtues.Add(GeneratePettyVirtues());
            }
        }

        return virtues;
    }

    public DeedClass GeneratePettySins()
    {
        return deeds.pettySins[Random.Range(0, deeds.pettySins.Count - 1)];
    }

    public DeedClass GenerateSins()
    {
        return deeds.sins[Random.Range(0, deeds.sins.Count - 1)];
    }
    public DeedClass GenerateTerribleSins()
    {
        return deeds.terribleSins[Random.Range(0, deeds.terribleSins.Count - 1)];
    }
    public DeedClass GenerateHorrificSins()
    {
        return deeds.horrificSins[Random.Range(0, deeds.horrificSins.Count - 1)];
    }

    public DeedClass GeneratePettyVirtues()
    {
        return deeds.pettyVirtues[Random.Range(0, deeds.pettyVirtues.Count - 1)];
    }

    public DeedClass GenerateVirtues()
    {
        return deeds.virtues[Random.Range(0, deeds.virtues.Count - 1)];
    }

    public DeedClass GenerateHeroicVirtues()
    {
        return deeds.heroicVirtues[Random.Range(0, deeds.heroicVirtues.Count - 1)];
    }

    public DeedClass GenerateAngelicVirtues()
    {
        return deeds.angelicVirtues[Random.Range(0, deeds.angelicVirtues.Count - 1)];
    }
    #endregion
}
