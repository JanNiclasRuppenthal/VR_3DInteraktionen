using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdActivity : MonoBehaviour
{
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private GameObject camera;
    [SerializeField] private ParticleSystem smoke;


    [SerializeField] [Range(-180, 180)] private float angle = 90f;
    
    private float _speed = 20f;
    private float _cameraspeed = 40f;
    private bool _moveToBiggestTree;
    private bool _hit = false;
    private int mode = 1;
    private SpawnPartH _spawnScript;
    private Vector2 _targetPosition;
    private Vector2 _lastPosition;
    private Animator _animator;
    private Rigidbody rb;
    private int _countLives = 3;
    private int distance = -10;
    private AudioSource _audioSourceDie;
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnScript = spawnManager.GetComponent<SpawnPartH>();
        _animator = this.GetComponent<Animator>();
        _moveToBiggestTree = true;
        _audioSourceDie = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_countLives == 0)
        {
            return;
        }
        Vector3 targetPosition3 = new Vector3(_targetPosition.x, 2, _targetPosition.y);
        Vector3 nextPosition2 = new Vector3(this.transform.position.x, this.transform.position.y - 0.125f, this.transform.position.z);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (mode == 3){
                mode = 1;
            }else{
                mode++;
            }
        }

        // Testing death og bird
        if (Input.GetKeyDown(KeyCode.D))
        {
            angryBirdDies();
        }


        
        if (_spawnScript.trees.Count > 0)
        {
            Vector3 nextPosition = _spawnScript.trees[0].transform.position;
            _targetPosition = new Vector2(nextPosition.x, nextPosition.z);
        }

        
        
        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), _targetPosition) <= 5f)
        {
            _moveToBiggestTree = false;
            _lastPosition = _targetPosition;
        }
        
        
        if (_moveToBiggestTree)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition3, 
                _speed * Time.deltaTime);
            Vector3 lookDirection = targetPosition3 - this.transform.position;
            lookDirection.Normalize();
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(lookDirection), 6 * Time.deltaTime);
        
        }
        else if (!_targetPosition.Equals(_lastPosition) )
        {
            StartCoroutine(moveNext());
        }
        else
        {
            this.transform.RotateAround(targetPosition3, Vector3.up, this.angle * Time.deltaTime);
            //Vector3 vectorTree = (targetPosition3 - this.transform.position).normalized;
            //Vector3 tangent = Vector3.Cross(vectorTree, Vector3.up).normalized;
            //this.transform.LookAt(this.transform.position + tangent);
        }

        
        if (mode == 1)
        {
            Vector3 nextPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, this.transform.position.z);
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, nextPosition,
                100f * Time.deltaTime);
            
            Vector3 lookDirection = targetPosition3 - camera.transform.position;
            lookDirection.Normalize();
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.LookRotation(lookDirection), 6 * Time.deltaTime);
        }else if(mode == 2){
            Vector3 back = -this.transform.forward;
            back.y = 0.5f; // this determines how high. Increase for higher view angle.
            Vector3 nextPosition = this.transform.position - back * distance;
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, nextPosition,
                _cameraspeed * Time.deltaTime);

            camera.transform.forward = this.transform.position - camera.transform.position;
        }else{
            Vector3 nextPosition =  new Vector3(0,100,0);
             camera.transform.position = Vector3.MoveTowards(camera.transform.position, nextPosition,
                100f * Time.deltaTime);
            Vector3 lookDirection = new Vector3(0,0,0) - camera.transform.position;
            lookDirection.Normalize();
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.LookRotation(lookDirection), 6 * Time.deltaTime);
        }

    }

    IEnumerator moveNext()
    {
        yield return new WaitForSeconds(0.3f);
        _moveToBiggestTree = true;
    }

    IEnumerator hitByTree()
    {
        yield return new WaitForSeconds(0.3f);
        _moveToBiggestTree = true;
    }

    void angryBirdDies()
    {
        _audioSourceDie.Play(0);
        rb.useGravity = true;
        _moveToBiggestTree = false;
        _countLives = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        _moveToBiggestTree = false;
        if (collider.transform.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            ParticleSystem go = Instantiate(smoke, transform.position, transform.rotation);
            Destroy(go.gameObject, 1f);
        }
        else if (collider.transform.gameObject.CompareTag("tree"))
        {
            Grow growScriptOfTree = collider.gameObject.GetComponent<Grow>();
            growScriptOfTree.explode();

            growScriptOfTree.removeTreeFromList();
            Destroy(collider.gameObject);
        }
        else if (collider.transform.gameObject.CompareTag("Arrow"))
        {
            angryBirdDies();
        }
    }

}
