using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float bulletCooldown = 0.25f;
    public Transform BulletSpawnPosition;
    public GameObject Bullet;

    Rigidbody rb;
    Animator animController;
    float fireCounter = 0f;

    public bool isMoveL = false;
    public bool isMoveR = false;
    public bool isMoveF = false;
    public bool isMoveB = false;
    public bool isShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animController = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fireCounter += Time.deltaTime;

        ProcessInput();

        if (isShoot)
            Shoot();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void ProcessInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            isMoveF = true;
        }
        else
        {
            isMoveF = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            isMoveB = true;
        }
        else
        {
            isMoveB = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isMoveL = true;
            animController.SetBool("isTiltLeft", true);
        }
        else
        {
            isMoveL = false;
            animController.SetBool("isTiltLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            isMoveR = true;
            animController.SetBool("isTiltRight", true);
        }
        else
        {
            isMoveR = false;
            animController.SetBool("isTiltRight", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isShoot = true;
        }
    }


    void Movement()
    {
        if(isMoveF)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force);
        }
        if (isMoveB)
        {
            rb.AddForce(transform.forward * -1 * speed, ForceMode.Force);
        }
        if (isMoveL)
        {
            // rb.AddForce(transform.right * -1 * speed, ForceMode.Force);
            rb.AddTorque(transform.up * -1 * speed, ForceMode.Force);
        }
        if (isMoveR)
        {
            //rb.AddForce(transform.right * speed, ForceMode.Force);
            rb.AddTorque(transform.up  * speed, ForceMode.Force);
        }
    }

    void Shoot()
    {
        isShoot = false;
        if (fireCounter >= bulletCooldown)
        {
            fireCounter = 0f;
            Instantiate(Bullet, BulletSpawnPosition.position, BulletSpawnPosition.transform.rotation);
        }
    }
}
