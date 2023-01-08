using UnityEngine;
using System.Collections.Generic;

///<summary>
/// 
///</summary>
[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{

    public List<string> dialogue;

    public string GetRandomResponse()
    {
        return dialogue[Random.Range(0, dialogue.Count - 1)];
    }

}