using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class GrowPartH : MonoBehaviour
{
    private readonly float _max = 4f;
    private readonly float _growingSpeed = 0.05f;
    private GameObject _spawnManager;
    private SpawnPartH _spawnScript;
    private MeshRenderer _meshRenderer;
    private ParticleSystem _fallingLeavesParticleSystem;
    private ParticleSystem _explosionParticleSystem;



    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager");
        _spawnScript = _spawnManager.GetComponent<SpawnPartH>();

        _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        _fallingLeavesParticleSystem = this.transform.GetChild(0).GetComponent<ParticleSystem>();
        _fallingLeavesParticleSystem.gameObject.SetActive(true);

        _explosionParticleSystem = this.transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.localScale.x + _growingSpeed * Time.deltaTime;
        float y = this.transform.localScale.y + _growingSpeed * Time.deltaTime;
        float z = this.transform.localScale.z + _growingSpeed * Time.deltaTime;

        Vector3 newScale = new Vector3(x, y, z);

        this.transform.localScale = newScale;
        _fallingLeavesParticleSystem.transform.localScale = newScale;
        _explosionParticleSystem.gameObject.transform.localScale = newScale;

        if ((x >= _max) && (_spawnScript.trees.Count > 1))
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
    }


    public void removeTreeFromList()
    {
        Collider[] colliders;
        if ((colliders = Physics.OverlapSphere(this.gameObject.transform.position, 1f)).Length > 1)
        {
            foreach(var col in colliders)
            {
                GameObject root = col.gameObject;
                if (col.name.StartsWith("Treeroot"))
                {
                    _spawnScript.treeroots.Remove(root);
                    Destroy(root);
                }
            }
        }
        _spawnScript.trees.Remove(this.gameObject);
        Destroy(this.gameObject);
    }


    public void explode()
    {

        Collider[] colliders;
        if ((colliders = Physics.OverlapSphere(this.gameObject.transform.position, 1f)).Length > 1)
        {
            foreach (var col in colliders)
            {
                GameObject root = col.gameObject;
                if (col.name.StartsWith("Treeroot"))
                {
                    col.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        _fallingLeavesParticleSystem.gameObject.SetActive(false);
        _meshRenderer.enabled = false;
        _explosionParticleSystem.gameObject.SetActive(true);
        _explosionParticleSystem.Play();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.transform.gameObject.tag) == "AngryBird" &&  (_spawnScript.trees.Count > 1))
        {
            explode();
            collider.GetComponent<AngryBirdActivity>()._countLives -= 1;
            StartCoroutine(destroyTree());
        }
    }

}