using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{

    public Sprite treeSprite;
    public Sprite stump;
    
    [SerializeField]
    private int treeHealth = 2;

    private float respawnTime = 60;
    private float timer = 0;

    public bool isTree = true;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private GameObject player;
    private GameObject camera;

    public AudioSource woodChop;
    
    public AudioSource treeFall;

    private GameObject scoreHolder;

    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
        scoreHolder = GameObject.Find("ScoreCounter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
        }

        if(!isTree){
            timer += Time.deltaTime;
            if(timer > respawnTime){
                becomeTree();
            }
        }
    }

    private void OnMouseDown()
    {
        if((player.transform.position-this.transform.position).sqrMagnitude<2*2 && isTree) {
            Debug.Log("Player cut " + gameObject.name + " ! Where health is:" + treeHealth);
            if(treeHealth != 0){
                treeHealth--;
                camera.GetComponent<ShakeBehaviour>().TriggerShake(0.05f);
                woodChop.Play();
            } else {
                woodChop.Play();
                treeFall.Play();
                camera.GetComponent<ShakeBehaviour>().TriggerShake(0.2f);
                becomeStump();
                isTree = false;
                scoreHolder.GetComponent<ScoreCounter>().AddScore(2);
            }
            
        }
        
    }

    private void becomeTree()
    {
        isTree = true;
        timer = 0;
        spriteRenderer.sprite = treeSprite;
        boxCollider2D.offset = new Vector2(0, 0);
        boxCollider2D.size = new Vector2(2, 2);
    }


    private void becomeStump()
    {
        spriteRenderer.sprite = stump;
        player.GetComponent<PlayerController>().AddToInventory();
        boxCollider2D.offset = new Vector2(0, -0.7f);
        boxCollider2D.size = new Vector2(2, 0.6f);

    }
}
