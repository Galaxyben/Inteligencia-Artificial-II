using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public SimpleCharacterControl controlito;

    private void OnTriggerEnter(Collider other)
    {
        var Interactable = other.gameObject.GetComponent<InteractableNPC>();
        if(Interactable != null)
        {
            Interactable.StartConversation();
            controlito.talking = true;
        }
    }
}
