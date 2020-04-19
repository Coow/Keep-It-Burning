using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Sprite idle, walking;
    private SpriteRenderer spriteRenderer;
    private bool idling = true;
    float moveSpeed = 5f;
    private float baseSpeed = 5f;
    private Rigidbody2D rb;
    Vector2 movement;
    public int treesInventory = 0;
    public TMP_Text logsCounter;
    public bool isAlive = true;

    public GameObject scoreHolder;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isAlive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        /*
            if(movement.x == 0 && movement.y == 0){
                spriteRenderer.sprite = idle;
                Debug.Log("Idle");
                idling = true;
            } else {
                idling = false;
                if(idle) {
                    spriteRenderer.sprite = walking;

                    Debug.Log("Changing sprite ");
                }

                Debug.Log("Walking");
            }
            
            */
        //Debug.Log("X: " + movement.x + " | Y: " + movement.y);
        if (movement.x == 1)
        {
            spriteRenderer.flipX = true;
        }
        if (movement.x == -1)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Calc movespeed based on Trees in inventory
        moveSpeed = baseSpeed - (treesInventory * 0.25f);
        if (moveSpeed < 2)
        {
            moveSpeed = 2;
        }
        Debug.Log(moveSpeed);
    }

    public void AddToInventory()
    {
        treesInventory++;
        Debug.Log("Added to inventory | Size: " + treesInventory);
        UpdateLogCounter();
    }

    public void AddLogToFire(GameObject fire)
    {
        if (treesInventory != 0)
        {

            treesInventory--;
            UpdateLogCounter();
            fire.GetComponent<FireController>().LogAdd();
            scoreHolder.GetComponent<ScoreCounter>().AddScore(5);
        }
        else
        {
            Debug.Log("Not enough wood");
        }
    }

    void UpdateLogCounter()
    {
        logsCounter.text = "Logs: " + treesInventory;
    }
}
