using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour

{

    public int ObsToPlace = 1;
    // public GameObject[] Obstacles = new GameObject[0];
    GameObject Obstacle;
    public float obstacleCheckRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;
        bool validPosition = false;
        int spawnAttempts = 0;


        position = new Vector3(Random.Range(-15.0f, 34.0f), 0, Random.Range(-15.0f, 34.0f));
        Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Asteroid")
            {
                GameObject.Destroy(col.gameObject);
                Debug.Log("Asteroid Detectad ");
                //validPosition = true;
            }
        }
        GameObject playerObj = GameObject.Instantiate(Obstacle, position + Obstacle.transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    
}
