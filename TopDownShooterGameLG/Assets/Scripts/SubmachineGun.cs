using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmachineGun : MonoBehaviour
{
    bool firing = false;
    float nextBullet = 0f;
    [SerializeField]
    float fireRate = 100f;
    [SerializeField]
    float range;

    public GameObject projectile;
    GameObject myProjectile;
    Rigidbody rb;
    [SerializeField]
    float forceMagnitude = 300f;

    public KeyCode shoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time * 1000 > nextBullet)
        {
            nextBullet = (Time.time * 1000) + fireRate; // delay the next fire by the fireDelay
            Fire();
        }
    }

    void Fire()
    {
        if (Input.GetKey(shoot))
        {
            myProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject; //transform.position g�r s� att 

            rb = myProjectile.GetComponent<Rigidbody>();

            rb.AddForce(transform.right * forceMagnitude); //ForceMode.Impulse l�gger till en direkt kraft beroende p� massan av objektet








            Destroy(myProjectile, range);
        }
    }

}
