using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ListOfArticles : MonoBehaviour
{
    [SerializeField]
    private GameObject list;

    [SerializeField] private GameObject[] articlesFirstFloor;
    [SerializeField] private GameObject[] articlesSecondFloor;
    
    [SerializeField]
    private GameObject articles;
    [SerializeField]
    private GameObject ConL;
    [SerializeField]
    private GameObject ConR;
    
    private string text ="";
    private GameObject[] collectingArticles = new GameObject[4];
    
    public void updateTextOfList()
    {
        text = "<b><u>Bring me these ASAP:</u></b>\n";
        foreach (GameObject article in collectingArticles)
        {
            if (article.activeSelf)
            {
                text += article.name + "\n";
            }
            else
            {
                text += "<s>" + article.name + "</s>\n";
            }
        }
        list.GetComponent<TextMeshPro>().SetText(text);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        setStartingArticles();
        updateTextOfList();
    }
    
    private void setStartingArticles()
    {
        int firstItem = Random.Range(0, articlesFirstFloor.Length);
        int secondItem = 0;
        do
        {
            secondItem = Random.Range(0, articlesFirstFloor.Length);
        } while (secondItem == firstItem);

        collectingArticles[0] = articlesFirstFloor[firstItem];
        collectingArticles[1] = articlesFirstFloor[secondItem];
        
        firstItem = Random.Range(0, articlesSecondFloor.Length);
        secondItem = 0;
        do
        {
            secondItem = Random.Range(0, articlesSecondFloor.Length);
        } while (secondItem == firstItem);
        
        collectingArticles[2] = articlesSecondFloor[firstItem];
        collectingArticles[3] = articlesSecondFloor[secondItem];
    }
    

    // Update is called once per frame
    void Update()
    {
        updatePositionOfList();
    }

    private void updatePositionOfList()
    {
        Vector3 mid = (ConR.transform.position + ConL.transform.position) / 2;
        mid.y += 0.15f;
        this.transform.position = mid;
    }
    
}
