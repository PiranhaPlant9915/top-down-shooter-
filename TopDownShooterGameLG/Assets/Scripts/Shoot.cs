using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    GameObject myProjectile;
    Rigidbody rb;
    [SerializeField]
    float forceMagnitude = 300f;

    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode leftKey;

    public KeyCode shoot;

    [SerializeField]
    private float fireRate = 3.0f;
    private float timer;
    [SerializeField]
    float range;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (Input.GetKey(shoot))
            {



                myProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject; //transform.position g�r s� att 

                rb = myProjectile.GetComponent<Rigidbody>();

                rb.AddForce(transform.right * forceMagnitude); //ForceMode.Impulse l�gger till en direkt kraft beroende p� massan av objektet








                Destroy(myProjectile, range);

                timer = fireRate;

            }
        }






    }




}
