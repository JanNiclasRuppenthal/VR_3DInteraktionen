using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CoralManager : MonoBehaviour
{

    [SerializeField] private GameObject coralParent;
    private List<Coral>[] _coralGroups;
	private int[] callCounts;
	[SerializeField] private PostProcessGray grayscale;
    private float timePerChange;
	private float delay;

    void Start()
    {
        _coralGroups = new List<Coral>[6];
        callCounts = new int[6];
        for (int i = 0; i < 6; i++)
        {
            _coralGroups[i] = new List<Coral>();
        }
        foreach (Transform child in coralParent.transform){

            if (!child.gameObject.activeSelf)
            {
                continue;
            }
            
            Coral coral = child.gameObject.GetComponent<Coral>();
            coral.startColor();

            for (int i = 0; i < 6; i++)
            {
                if (child.gameObject.CompareTag("Coral" + (i + 1)))
                {
                    _coralGroups[i].Add(coral);
                    break;
                }
            }
        }
		timePerChange = grayscale.gameover / 21;
		delay = 3*timePerChange;
    }

    void Update()
    {
        float timePassed = Time.timeSinceLevelLoad - delay;
		if (timePassed > 0)
        {
            for (int i = 0; i < 6; i++)
            {
                if (callCounts[i] < 3 && timePassed >= (callCounts[i] * 6 + i + 1) * timePerChange)
                {
                    foreach (Coral coral in _coralGroups[i])
                    {
                        coral.changeColor();
                    }
                    callCounts[i]++;
                }
            }
        }
    }


    
}
