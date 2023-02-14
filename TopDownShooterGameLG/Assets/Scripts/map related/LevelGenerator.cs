using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
   
    // https://www.youtube.com/watch?v=XNQQLr0E9TY

    public Transform[] startingPositions;
    public GameObject[] roomVariants;
    /*
     * index 0 = LR
     * index 1 = LRB
     * index 2 LRBT
     * index 3 LRT
     */

    float moveAmountHorizontal = 17.0f;
    float moveAmountVertical = 15.0f;
    public int direction;

    float timeBetweenRooms = 0.25f; 
    public float startTimeBetweenRooms;

    public float minimumX;
    public float maximumX;
    public float minimumY;
    bool Generating = true;
    void Start()
    {
        int randomStartingPosition = Random.Range(0, startingPositions.Length); // chooses a random number from 0 to the lenght of an array
        transform.position = startingPositions[randomStartingPosition].position; //takes the chosen array unit and takes the transform position of it and sets the curent game objects position to that array units position.
        Instantiate(roomVariants[0], transform.position, Quaternion.identity); //spawns in prefab from a prefab array at current gameobjects position and gives no rotation

        direction = Random.Range(1, 6); //gives direction a random number from 1 to 5
    }
    private void Update() // time between creating rooms
    {
        if (timeBetweenRooms <= 0 && Generating)
        {
            Move();
            timeBetweenRooms = startTimeBetweenRooms;
        }
        else
        {
            timeBetweenRooms -= Time.deltaTime;
        }
    }
    void Move()
    {
        if (direction == 1 || direction == 2) //move right, an if that runs if direction equals 1 and/or 2
        {
            if (transform.position.x < maximumX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmountHorizontal, transform.position.y);
                transform.position = newPos;

                // to make the room levels actually playable with connecting rooms
                int random = Random.Range(0, roomVariants.Length);
                Instantiate(roomVariants[random], transform.position, Quaternion.identity);

                direction = Random.Range(1, 5);
                if (direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5; //sets direction to 5 so that next room creation will go down
            }
            
        }
        else if (direction == 3 || direction == 4) // moves left
        {
            if (transform.position.x > minimumX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmountHorizontal, transform.position.y);
                transform.position = newPos;
                direction = Random.Range(3, 6);

                int random = Random.Range(0, roomVariants.Length);
                Instantiate(roomVariants[random], transform.position, Quaternion.identity);
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 5)
        {
            if (transform.position.y > minimumY)
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountVertical);
                transform.position = newPos;
                direction = Random.Range(1, 6);

                //
                int random = Random.Range(2,4);
                Instantiate(roomVariants[random], transform.position, Quaternion.identity);

            }
            else //stop level generation
            {
                Generating = false;
            }
        }

        Instantiate(roomVariants[0], transform.position, Quaternion.identity);
    }
}
