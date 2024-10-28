using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueSO : ScriptableObject {
    [TextArea (6, 20)]
    public List<string> _dialogues;
    public List<string> _choices;
}