using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public Node startingConversationRoot;


    public void StartConversation()
    {
        Camera.main.GetComponent<ConversationManager>().ShowDialogue(startingConversationRoot);
    }

}
