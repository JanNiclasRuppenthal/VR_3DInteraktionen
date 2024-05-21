using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Grow : MonoBehaviour
{
    private readonly float _max = 4f;
    private readonly float _growingSpeed = 0.05f;
    private GameObject _spawnManager;
    private Spawn _spawnScript;
    private MeshRenderer _meshRenderer;
    private ParticleSystem _fallingLeavesParticleSystem;
    private ParticleSystem _explosionParticleSystem;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager");
        _spawnScript = _spawnManager.GetComponent<Spawn>();

        _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        
        _fallingLeavesParticleSystem = this.transform.GetChild(0).GetComponent<ParticleSystem>();
        _fallingLeavesParticleSystem.gameObject.SetActive(true);
        
        _explosionParticleSystem = this.transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.localScale.x + _growingSpeed * Time.deltaTime;
        float y = this.transform.localScale.y + _growingSpeed  * Time.deltaTime;
        float z = this.transform.localScale.z + _growingSpeed  * Time.deltaTime;

        Vector3 newScale = new Vector3(x, y, z);

        this.transform.localScale = newScale;
        _fallingLeavesParticleSystem.transform.localScale = newScale;
        _explosionParticleSystem.gameObject.transform.localScale = newScale;


        if (x >= _max)
        {
            explode();

            StartCoroutine(destroyTree());
            return;
        }
    }

    IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(0.4f);
        removeTreeFromList();
        Destroy(this.gameObject);
    }


    public void removeTreeFromList()
    {
        _spawnScript.trees.Remove(this.gameObject);
    }


    public void explode()
    {
        _fallingLeavesParticleSystem.gameObject.SetActive(false);
        _meshRenderer.enabled = false;
        _explosionParticleSystem.gameObject.SetActive(true);
        _explosionParticleSystem.Play();
    }
    
}
