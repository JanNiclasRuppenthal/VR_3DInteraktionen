using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BirdPointer : MonoBehaviour
{
    [System.Serializable]
    public class CurrentScript : UnityEvent { }
    [SerializeField]
    private CurrentScript currentScript = new CurrentScript();
    public CurrentScript script
    {
        get { return currentScript; }
        set { currentScript = value; }
    }

    private GameObject conL;
    private GameObject conR;
    private GameObject player;
    private SpawnPartH spawnScript;
    private GameObject spawnManager;

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        script.Invoke();
    }


    public void setTree()
    {
        Debug.Log(this.gameObject.name);
        spawnManager = GameObject.Find("SpawnManager");
        spawnScript = spawnManager.GetComponent<SpawnPartH>();
        spawnScript.trees.Remove(this.gameObject);
        spawnScript.trees.Insert(0, this.gameObject);

        conL = GameObject.Find("Left Controller");
        conR = GameObject.Find("Right Controller");
        conL.transform.GetChild(1).gameObject.SetActive(false);
        conR.transform.GetChild(1).gameObject.SetActive(false);
        player = GameObject.Find("XR Origin");
        player.GetComponent<chargeRaycast>().charge();
    }

}
