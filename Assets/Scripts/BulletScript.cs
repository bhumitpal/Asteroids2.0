using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 100f;
    public float rayDistance;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position,transform.forward,out hit, rayDistance))
        {
            if(hit.transform.CompareTag("Asteroid"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
