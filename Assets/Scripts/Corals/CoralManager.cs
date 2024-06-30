using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralManager : MonoBehaviour
{

    [SerializeField] private GameObject coralList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in coralList.transform){
            if (child.gameObject.name.StartsWith("coralShell")){
                child.gameObject.GetComponent<CoralShellBreakDown>().startColor();
            }else{
                child.gameObject.GetComponent<CoralBreakDown>().startColor();
            }
        }
    }

    private float timeLeft = 1.0f;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0){
            foreach (Transform child in coralList.transform){
                if (child.gameObject.name.StartsWith("coralShell")){
                    child.gameObject.GetComponent<CoralShellBreakDown>().changeColor(Time.deltaTime);
                }else{
                    child.gameObject.GetComponent<CoralBreakDown>().changeColor(Time.deltaTime);
                }
            }
            timeLeft = 1.0f;
        }
            
    }
}
