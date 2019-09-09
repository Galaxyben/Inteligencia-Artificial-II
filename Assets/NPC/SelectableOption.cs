using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableOption : MonoBehaviour
{
    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            gameObject.GetComponent<Text>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Text>().color = Color.white;
        }
    }
}
