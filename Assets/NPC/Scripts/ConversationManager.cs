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
    public int contador = 0;
    public GameObject talkingTo;

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
        if (!character.talking)
            PlayAnim("cov");

        if (startingNode.links.Length == 0)
        {
            talkingTo.GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
            PlayAnim("covoff");
            character.talking = false;
            currentConversation = null;
        }

        contador = 0;
        currentConversation = startingNode;
        var remainingNode = startingNode.links.Length;
        var newNode = startingNode;
        var NodeList = new List<Node>();


        Debug.Log(startingNode.sentence);
        conversationText.text = startingNode.sentence;

        foreach (Transform child in conversationBox.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (var response in startingNode.actions)
        {
            var temp = contador;
            choices++;
            var resp = Instantiate(Response, conversationBox.transform, false);
            resp.GetComponent<Button>().transform.GetChild(0).GetComponent<Text>().text = response.ToString();
            resp.GetComponent<Button>().onClick.AddListener(delegate { ShowDialogue(startingNode.links[temp]); });
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
