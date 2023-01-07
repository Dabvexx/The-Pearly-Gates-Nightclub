using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeedGenerator : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private DeedList deeds;

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

        Debug.Log("Trying petty sins chance: " + pettySinChance * evilModifier);
        // Chance of getting petty sins.
        if (Random.Range(0.001f, 1f) <= pettySinChance * evilModifier)
        {
            Debug.Log("Generating petty sins.");
            sins = GeneratePettySins(sins);
        }

        Debug.Log("Trying sins chance: " + sinChance * evilModifier);
        // Chance of getting sins.
        if (Random.Range(0.001f, 1f) <= sinChance * evilModifier)
        {
            Debug.Log("Generating sins.");
            sins = GenerateSins(sins);
        }

        Debug.Log("Trying terrible sins chance: " + terribleSinChance * evilModifier);
        // Chance of getting terrible sins.
        if (Random.Range(0.001f, 1f) <= terribleSinChance * evilModifier)
        {
            Debug.Log("Generating terrible sins.");
            sins = GenerateTerribleSins(sins);
        }

        Debug.Log("Trying horrific sins chance: " + horrificSinChance * evilModifier);
        // Chance of getting horrific sins.
        if (Random.Range(0.001f, 1f) <= horrificSinChance * evilModifier)
        {
            Debug.Log("Generating horrific sins.");
            sins = GenerateHorrificSins(sins);
        }

        return sins;
    }

    public List<DeedClass> GeneratePettySins(List<DeedClass> sins)
    {
        var pettySins = new List<DeedClass>(deeds.GetPettySins());
        int sinAmount = Random.Range(1, pettySins.Count - 1);
        Debug.Log($"Amount of petty sins: {sinAmount}");


        for (int i = 0; i < sinAmount; i++)
        {
            int sinIndex = Random.Range(0, pettySins.Count - 1);
            sins.Add(pettySins[sinIndex]);
            pettySins.RemoveAt(sinIndex);
            sins.LastOrDefault().timesDone = Random.Range(1, pettySinsMax);
        }

        return sins;
    }

    public List<DeedClass> GenerateSins(List<DeedClass> sins)
    {
        var normalSins = new List<DeedClass>(deeds.GetSins());
        int sinAmount = Random.Range(1, normalSins.Count - 1);
        Debug.Log($"Amount of sins: {sinAmount}");


        for (int i = 0; i < sinAmount; i++)
        {
            int sinIndex = Random.Range(0, normalSins.Count - 1);
            sins.Add(normalSins[sinIndex]);
            normalSins.RemoveAt(sinIndex);
            sins.LastOrDefault().timesDone = Random.Range(1, sinsMax);
        }

        return sins;
    }
    public List<DeedClass> GenerateTerribleSins(List<DeedClass> sins)
    {
        var terribleSins = new List<DeedClass>(deeds.GetTerribleSins());
        int sinAmount = Random.Range(1, terribleSins.Count - 1);
        Debug.Log($"Amount of terrible sins: {sinAmount}");


        for (int i = 0; i < sinAmount; i++)
        {
            int sinIndex = Random.Range(1, terribleSins.Count - 1);
            sins.Add(terribleSins[sinIndex]);
            terribleSins.RemoveAt(sinIndex);
            sins.LastOrDefault().timesDone = Random.Range(1, terribleSinsMax);
        }

        return sins;
    }
    public List<DeedClass> GenerateHorrificSins(List<DeedClass> sins)
    {
        var horrificSins = new List<DeedClass>(deeds.GetHorrificSins());
        int sinAmount = Random.Range(1, horrificSins.Count -1);
        Debug.Log($"Amount of horrific sins: {sinAmount}");


        for (int i = 0; i < sinAmount; i++)
        {
            int sinIndex = Random.Range(1, horrificSins.Count - 1);
            sins.Add(horrificSins[sinIndex]);
            horrificSins.RemoveAt(sinIndex);
            sins.LastOrDefault().timesDone = Random.Range(1, horrificSinsMax);
        }

        return sins;
    }

    // Virtue generator.
    public List<DeedClass> GenerateAllVirtues(float goodModifier)
    {
        Debug.Log("Generating Virtues");
        List<DeedClass> virtues = new List<DeedClass>();

        Debug.Log("Trying petty virtues chance:" + pettyVirtueChance * goodModifier);
        // Chance of getting petty virtues.
        if (Random.Range(0.001f, 1f) <= pettyVirtueChance * goodModifier)
        {
            Debug.Log("Generating petty virtues.");
            virtues = GeneratePettyVirtues(virtues);
        }

        Debug.Log("Trying virtues chance: " + virtueChance * goodModifier);
        // Chance of getting virtues.
        if (Random.Range(0.001f, 1f) <= virtueChance * goodModifier)
        {
            Debug.Log("Generating virtues.");
            virtues = GenerateVirtues(virtues);
        }

        Debug.Log("Trying heroic virtues chance: " + heroicVirtueChance * goodModifier);
        // Chance of getting heroic virtues.
        if (Random.Range(0.001f, 1f) <= heroicVirtueChance * goodModifier)
        {
            Debug.Log("Generating heroic virtues.");
            virtues = GenerateHeroicVirtues(virtues);
        }

        Debug.Log("Trying angelic virtues chance: " + angelicVirtueChance * goodModifier);
        // Chance of getting angelic virtues.
        if (Random.Range(0.001f, 1f) <= angelicVirtueChance * goodModifier)
        {
            Debug.Log("Generating angelic virtues.");
            virtues = GenerateAngelicVirtues(virtues);
        }

        return virtues;
    }

    public List<DeedClass> GeneratePettyVirtues(List<DeedClass> virtues)
    {
        var pettyVirtues = new List<DeedClass>(deeds.GetPettyVirtues());
        int virtueAmount = Random.Range(1, pettyVirtues.Count - 1);
        Debug.Log($"Amount of petty virtues: {virtueAmount}");

        for (int i = 0; i < virtueAmount; i++)
        {
            int sinIndex = Random.Range(0, pettyVirtues.Count - 1);
            virtues.Add(pettyVirtues[sinIndex]);
            pettyVirtues.RemoveAt(sinIndex);
            virtues.LastOrDefault().timesDone = Random.Range(1, pettyVirtuesMax);
        }

        return virtues;
    }

    public List<DeedClass> GenerateVirtues(List<DeedClass> virtues)
    {
        var normalVirtues = new List<DeedClass>(deeds.GetVirtues());
        int virtueAmount = Random.Range(1, normalVirtues.Count - 1);
        Debug.Log($"Amount of virtues: {virtueAmount}");

        for (int i = 0; i < virtueAmount; i++)
        {
            int sinIndex = Random.Range(0, normalVirtues.Count);
            virtues.Add(normalVirtues[sinIndex]);
            normalVirtues.RemoveAt(sinIndex);
            virtues.LastOrDefault().timesDone = Random.Range(1, virtuesMax);
        }

        return virtues;
    }

    public List<DeedClass> GenerateHeroicVirtues(List<DeedClass> virtues)
    {
        var heroicVirtues = new List<DeedClass>(deeds.GetHeroicVirtues());
        int virtueAmount = Random.Range(1, heroicVirtues.Count - 1);
        Debug.Log($"Amount of heroic virtues: {virtueAmount}");

        for (int i = 0; i < virtueAmount; i++)
        {
            int sinIndex = Random.Range(0, heroicVirtues.Count);
            virtues.Add(heroicVirtues[sinIndex]);
            heroicVirtues.RemoveAt(sinIndex);
            virtues.LastOrDefault().timesDone = Random.Range(1, heroicVirtuesMax);
        }

        return virtues;
    }

    public List<DeedClass> GenerateAngelicVirtues(List<DeedClass> virtues)
    {
        var angelicVirtues = new List<DeedClass>(deeds.GetAngelicVirtues());
        int virtueAmount = Random.Range(1, angelicVirtues.Count - 1);
        Debug.Log($"Amount of angelic virtues: {virtueAmount}");

        for (int i = 0; i < virtueAmount; i++)
        {
            int sinIndex = Random.Range(0, angelicVirtues.Count);
            virtues.Add(angelicVirtues[sinIndex]);
            angelicVirtues.RemoveAt(sinIndex);
            virtues.LastOrDefault().timesDone = Random.Range(1, angelicVirtuesMax);
        }

        return virtues;
    }
    #endregion
}
