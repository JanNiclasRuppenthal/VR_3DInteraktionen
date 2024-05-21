using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdActivity : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke;


    [SerializeField] [Range(-180, 180)] private static float angle = 90f;
    public bool enabled = false;
    public  int _countLives;
    
    private static float _speed = 20f;
    private static float _cameraspeed = 40f;
    
    private bool dead = false;
    private int distance = -10;
    private bool _moveToBiggestTree;
    private SpawnPartH _spawnScript;
    private Vector2 _targetPosition;
    private Vector2 _lastPosition;
    private Animator _animator;
    private Rigidbody rb;
    private AudioSource _audioSourceDie;
    private GameObject camera;
    private GameObject spawnManager;
    private GameObject gameStats;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        _countLives = 3;
        gameStats = GameObject.Find("GameStats");
        spawnManager = GameObject.Find("SpawnManager");
        camera = GameObject.Find("Bird Camera");
        _spawnScript = spawnManager.GetComponent<SpawnPartH>();
        _animator = this.GetComponent<Animator>();
        _moveToBiggestTree = true;
        _audioSourceDie = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (_countLives == 0){
            if (dead) return;
            angryBirdDies();
            dead = true;

            _speed += 5;
            _cameraspeed += 10;
            angle += 10;

        }

        Vector3 back = -this.transform.forward;
        back.y = 0.5f; // this determines how high. Increase for higher view angle.
        Vector3 nextPositionCam = this.transform.position - back * distance;
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, nextPositionCam,
            _cameraspeed * Time.deltaTime);
        camera.transform.forward = this.transform.position - camera.transform.position;
        

        // Testing death of bird with keyboard
        if (Input.GetKeyDown(KeyCode.D))
        {
            _countLives = 0;
        }

        if (!enabled) return;

        Vector3 targetPosition3 = new Vector3(_targetPosition.x, 4, _targetPosition.y);
        Vector3 nextPosition2 = new Vector3(this.transform.position.x, this.transform.position.y - 0.125f, this.transform.position.z);

        if (_spawnScript.trees.Count > 0)
        {
            Vector3 nextPosition = _spawnScript.trees[0].transform.position;
            _targetPosition = new Vector2(nextPosition.x, nextPosition.z);
        }

        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), _targetPosition) <= 5f)
        {
            _moveToBiggestTree = false;
            _lastPosition = _targetPosition;
            this.transform.LookAt(targetPosition3);
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
            this.transform.RotateAround(targetPosition3, Vector3.up, angle * Time.deltaTime);
        }
    }

    IEnumerator moveNext()
    {
        yield return new WaitForSeconds(0.3f);
        _moveToBiggestTree = true;
    }

    void angryBirdDies()
    {
        this.GetComponent<checkHeight>().enabled = false;
        _audioSourceDie.Play(0);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        rb.useGravity = true;
        _moveToBiggestTree = false;
        spawnManager.GetComponent<SpawnPartH>().shootBird();
    }

    private void OnTriggerEnter(Collider collider)
    {
        _moveToBiggestTree = false;
        if (collider.transform.gameObject.CompareTag("ground"))
        {
            gameStats.GetComponent<Stats>().currentBird = gameStats;
            Destroy(gameObject);
            ParticleSystem go = Instantiate(smoke, transform.position, transform.rotation);
            Destroy(go.gameObject, 1f);
        }
        else if (collider.transform.gameObject.CompareTag("Arrow"))
        {
            gameStats.GetComponent<Stats>().currentBird = gameStats;
            gameStats.GetComponent<Stats>().score += (int) Vector3.Distance(this.gameObject.transform.position, player.transform.position);
            _countLives = 0;
        }
    }

}
