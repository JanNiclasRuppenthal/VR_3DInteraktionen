using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CoralManager : MonoBehaviour
{

    [SerializeField] private GameObject coralParent;
    private List<Coral> _coralList;

    // Start is called before the first frame update
    void Start()
    {
        _coralList = new List<Coral>();
        foreach (Transform child in coralParent.transform){

            if (!child.gameObject.activeSelf)
            {
                continue;
            }
            
            child.gameObject.GetComponent<Coral>().startColor();
            _coralList.Add(child.gameObject.GetComponent<Coral>());
        }
    }

    private float timeLeft = 1.0f;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < batchSize; i++)
        {
            if (currentIndex >= _coralList.Count)
            {
                currentIndex = 0;
            }

            Coral currentCoral = _coralList[currentIndex];
            currentCoral.changeColor(72f * Time.deltaTime);

            currentIndex++;
        }
    }

    private int batchSize = 25;
    private int currentIndex = 0;


    IEnumerator method()
    {

        // foreach (Coral c in _coralList)
        // {
        //     c.changeColor(Time.deltaTime);
        //     yield return null;
        // }
        
        for (int i = 0; i < batchSize; i++)
        {
            if (currentIndex >= _coralList.Count)
            {
                currentIndex = 0;
            }
        
            Coral currentCoral = _coralList[currentIndex];
            
            currentCoral.changeColor(Time.deltaTime);
            currentIndex++;
            yield return null;
        }
    }
}
