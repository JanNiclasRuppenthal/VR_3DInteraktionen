using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
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
    private GameObject player;
    private SpawnPartH spawnScript;
    private GameObject spawnManager;
    private GameObject gameStats;
    private InputActionProperty button;

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.transform.CompareTag("AngryBird"))
        {
            script.Invoke();
        }
    }


    public void setTree()
    {
        gameStats = GameObject.Find("GameStats");
        button = gameStats.GetComponent<Stats>().raycastButton;
        if (button.action.WasPressedThisFrame())
        {
            spawnManager = GameObject.Find("SpawnManager");
            conL = GameObject.Find("Left Controller");
            player = GameObject.Find("XR Origin");

            spawnScript = spawnManager.GetComponent<SpawnPartH>();
            spawnScript.trees.Remove(this.gameObject);
            spawnScript.trees.Insert(0, this.gameObject);
            conL.transform.GetChild(1).gameObject.SetActive(false);
            player.GetComponent<chargeRaycast>().charge();
            gameStats.GetComponent<Stats>().timer();
        }
    }

}
