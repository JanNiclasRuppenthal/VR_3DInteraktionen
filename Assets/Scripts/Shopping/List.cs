using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class List : MonoBehaviour
{
    [SerializeField]
    private GameObject list;
    [SerializeField]
    private GameObject articles;
    [SerializeField]
    private GameObject ConL;
    [SerializeField]
    private GameObject ConR;
    private string text ="";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mid = (ConR.transform.position + ConL.transform.position) / 2;
        this.transform.position = mid;
        text = "<b><u>Shopping list:</u></b> \n";
        foreach (Transform child in articles.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                text += child.name + "\n";
            }
            else
            {
                text += "<color=#808080><s>" + child.name + "</s></color> \n";
            }
        }
        list.GetComponent<TextMeshPro>().SetText(text);
    }
}
