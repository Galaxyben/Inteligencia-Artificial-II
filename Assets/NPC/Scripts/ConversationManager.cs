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
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            conversationText.text = "";
            FollowConversation(currentConversation, currentchoice);
        }
    }

    void PlayAnim(string animation)
    {
        conversation.gameObject.GetComponent<Animation>().Play(animation);
    }

    public void ShowDialogue(Node startingNode)
    {
        currentConversation = startingNode;
        var remainingNode = startingNode.links.Length;
        var newNode = startingNode;
        var NodeList = new List<Node>();

        if(!character.talking)
            PlayAnim("cov");
        Debug.Log(startingNode.sentence);
        conversationText.text = startingNode.sentence;
        int contador = 0;

        foreach (var response in startingNode.actions)
        {
            choices++;
            var resp = Instantiate(Response, conversationBox.transform, false);
            resp.GetComponent<Button>().transform.GetChild(0).GetComponent<Text>().text = response.ToString();
            resp.GetComponent<Button>().onClick.AddListener(delegate { ShowDialogue(startingNode.links[contador]); });
            contador++;
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
