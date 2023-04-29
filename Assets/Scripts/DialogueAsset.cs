using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue Asset")]
public class DialogueAsset : ScriptableObject
{
    [field: SerializeField, TextArea] public string[] Dialogues { get; private set; }
}
