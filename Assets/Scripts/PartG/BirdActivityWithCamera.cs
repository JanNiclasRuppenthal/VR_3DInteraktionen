using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdActivityWithCamera : MonoBehaviour
{
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private Camera mainCamera;
    [SerializeField] [Range(-180, 180)] private float angle = 90f;
    private float speed = 20f;

    private bool moveToBiggestTree;
    private Spawn spawnScript;
    private Vector2 targetPosition;
    private Vector2 lastPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnScript = spawnManager.GetComponent<Spawn>();
        moveToBiggestTree = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = spawnScript.trees[0];
        Vector3 targetPosition3 = new Vector3(targetPosition.x, 2, targetPosition.y);
        
        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), targetPosition) <= 5f)
        {
            moveToBiggestTree = false;
            lastPosition = targetPosition;
        }
        
        
        if (moveToBiggestTree)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition3, 
                speed * Time.deltaTime);
            //this.transform.LookAt(targetPosition3);
            
            Vector3 lookDirection = targetPosition3 - this.transform.position;
            lookDirection.Normalize();
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(lookDirection), 6 * Time.deltaTime);
        }
        else if (!targetPosition.Equals(lastPosition))
        {
            moveToBiggestTree = true;
        }
        else
        {
            this.transform.RotateAround(targetPosition3, Vector3.up, this.angle * Time.deltaTime);
            mainCamera.gameObject.transform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0);

            //Vector3 vectorTree = (targetPosition3 - this.transform.position).normalized;
            //Vector3 tangent = Vector3.Cross(vectorTree, Vector3.up).normalized;
            //this.transform.LookAt(this.transform.position + tangent);
        }
    }
    
    
    
}
