using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private EnemyDrop getItem;

    public GameObject playerObject;
    public float movementSpeed;
    public int enemyType;
    public float rangedEnemyDistance;
    internal Animator animator;
    internal float enemyHealth;
    public float maxHealth;
    public Color deathColor;
    public Color hurtColor;
    public float hurtTime;
    SpriteRenderer spriteRenderer;

    Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        HealthManager.playerDeath += PlayerDied;
        animator = GetComponent<Animator>();
        enemyHealth = maxHealth;

        getItem = GetComponent<EnemyDrop>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            if (getItem != null)
            {
               
                getItem.MobDrops();
                
            }

            if (gameObject.GetComponent<EnemyShootScript>() != null)
            {
                Destroy(gameObject.GetComponent<EnemyShootScript>());
                
            }
            gameObject.GetComponent<SpriteRenderer>().color = deathColor;
            Destroy(gameObject.GetComponent<BoxCollider>());
            animator.SetInteger("animationID", -1);
            animator.Play("EnemyDeath");
            Destroy(this);
        }

        playerDirection = playerObject.transform.position - gameObject.transform.position;

        if (playerDirection.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (playerDirection.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        


        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("stopMoving") == false)
        {
            if (enemyType == 0)
            {
                BasicMeleeEnemy();
            }
            if (enemyType == 1)
            {
                BasicRangedEnemy();
            }
        }

        

    }
    void PlayerDied()
    {
        this.enabled = false;
    }

    void BasicMeleeEnemy()
    {
        gameObject.transform.Translate(playerDirection.normalized * movementSpeed * Time.deltaTime, Space.World);
    }

    void BasicRangedEnemy()
    {
        if (playerDirection.magnitude > rangedEnemyDistance + 1)
        {
            gameObject.transform.Translate(playerDirection.normalized * movementSpeed * Time.deltaTime, Space.World);
        }
        if (playerDirection.magnitude < rangedEnemyDistance - 1)
        {
            gameObject.transform.Translate(playerDirection.normalized * -1 * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 vectorToCollision = other.gameObject.transform.position - transform.position;
            transform.Translate(new Vector3(-vectorToCollision.x * Time.deltaTime, -vectorToCollision.y * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && other.gameObject.layer == 3)
        {
            enemyHealth -= other.gameObject.GetComponent<BulletScript>().bulletDamage;
            StartCoroutine(FlashRed());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = hurtColor;
        yield return new WaitForSeconds(hurtTime);
        spriteRenderer.color = Color.white;
    }

}
