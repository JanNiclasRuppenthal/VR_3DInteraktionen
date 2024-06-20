using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public class spawnWaste : MonoBehaviour
{
    public GameObject plane;
    public GameObject[] waste;

    // Plane Properties
    float x_dim;
    float z_dim;

    public float timeLeft = 15.0f;
    int max = 10;
    int cnt = 0;
    void Start()
    {
        // Get the length and width of the plane
        x_dim = plane.GetComponent<MeshRenderer>().bounds.size.x;
        z_dim = plane.GetComponent<MeshRenderer>().bounds.size.z;
        x_dim /= 2;
        z_dim /= 2;  
         
    }

    void Update(){
        timeLeft -= Time.deltaTime;  
        if (timeLeft <= 0 && cnt < max){
            Spawn();
            cnt++;
            timeLeft = 1.0f;
        }
    }

        public void Spawn()
    {
        // Spawn the object as a child of the plane. This will solve any rotation issues
        GameObject obj = Instantiate(waste[Random.Range(0,waste.Length)], plane.transform.position, 
         Quaternion.identity) as GameObject;

        /* Move the object to where you want withing in the dimensions of the plane */
        // random the x and z position between bounds
        var x_rand = Random.Range(-x_dim, x_dim);
        var z_rand = Random.Range(-z_dim, z_dim);

        // Random the y position from the smallest bewteen x and z
        z_rand = x_rand > z_rand ? Random.Range(0, z_rand) : Random.Range(0, x_rand);

        // Now move the object
        // Since the object is a child of the plane it will automatically handle rotational offset
        obj.transform.position = new Vector3(x_rand,plane.transform.position.y, z_rand);

        // Now unassign the parent
        obj.transform.parent = null;
    }
}