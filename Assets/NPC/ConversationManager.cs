using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    public Image conversation;
    public Text conversationText;
    public Image conversationBox;
    public SimpleCharacterControl character;
    public GameObject Response;

    public int choices = 0;
    private int currentchoice = 1;
    private Node currentConversation;

    void Start()
    {
        //conversationText.text = conversation.transform.GetChild(0).GetComponent<Text>().text;
    }
    
    void Update()
    {

        if (character.talking)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && (currentchoice < choices))
            {
                currentchoice++;
                Debug.Log("Current choice: " + currentchoice + " MaxChoices: " + choices);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && (currentchoice > 1))
            {
                currentchoice--;
                Debug.Log("Current choice: " + currentchoice + " MaxChoices: " + choices);
            }

            if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                conversationText.text = "";
                FollowConversation(currentConversation, currentchoice);
            }
        }

    }

    void PlayAnim(string animation)
    {
        conversation.gameObject.GetComponent<Animation>().Play(animation);
    }

    public void StartConversation(Node startingNode)
    {
        currentConversation = startingNode;
        var remainingNode = startingNode.links.Length;
        var newNode = startingNode;
        var NodeList = new List<Node>();

        PlayAnim("cov");
        Debug.Log(startingNode.sentence);
        conversationText.text = startingNode.sentence;
        
        foreach(var response in startingNode.actions)
        {
            choices++;
            var resp = Instantiate(Response, conversationBox.transform, false);
            resp.GetComponent<Text>().text = response.ToString();
        }

        int nodeCount = 0;

        while(newNode.links.Length != 1)
        {
            newNode = newNode.links[0];
            nodeCount++;
            NodeList.Add(newNode);
        }
    }

    public void FollowConversation(Node parentNode, int response)
    {
        currentConversation = parentNode;
    }
}
