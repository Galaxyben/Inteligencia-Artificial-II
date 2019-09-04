using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogo", menuName = "DialogueSystem/DialogueNode", order = 1)]
public class DialogueNode : ScriptableObject
{
    [Tooltip("La oración principal del NPC")]
    public string sentence;
    [Tooltip("Nodos con los que se conectarán las respuestas. (Debe ser la misma cantidad de Player Responses")]
    public DialogueNode[] conections;
    [Tooltip("Las respuestas posibles del jugador")]
    public string[] playerResponses;
}
