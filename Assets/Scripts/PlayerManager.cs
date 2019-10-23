using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Ship;
    void Start()
    {
        Ship = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        Vector3 position = Vector3.zero;

        position = new Vector3(Random.Range(-15.0f, 34.0f), 0, Random.Range(-15.0f, 34.0f));

        GameObject playerObj = GameObject.Instantiate(Ship, position + Ship.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
