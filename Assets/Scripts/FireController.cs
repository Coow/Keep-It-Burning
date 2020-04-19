using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class FireController : MonoBehaviour
{

    public UnityEngine.Experimental.Rendering.Universal.Light2D light;

    public float health = 100f;
    private float maxHealth;

    public int logAddValue = 10;
    public float healthDecreaseTime = 0.2f;
    private float healthDecreaseTimeSet;

    private float fireStrength;

    public bool isAlive = true;

    public GameObject player;
    public GameObject scoreHolder;

    public AudioSource fire;
    public AudioSource logThrown;
    public AudioClip logFire;
    public AudioSource fireDie;

    public GameObject gameOver;
    public GameObject playBtn;
    public GameObject quitBtn;

    // Start is called before the first frame update
    void Start()
    {   
        scoreHolder = GameObject.Find("ScoreCounter");
        fire.loop = true;
        fire.Play();
        maxHealth = health;
        healthDecreaseTimeSet = healthDecreaseTime;
        //Debug.Log(light.intensity);
    }

    // Update is called once per frame
    void Update()
    {
        if ((health < 0) && isAlive)
        {
            isAlive = false;
            GameOver();
        }
        else
        {
            healthDecreaseTime -= Time.deltaTime;
            if ((healthDecreaseTime < 0) && isAlive)
            {
                TakeDamage();
            }
        }

    }

    private void OnMouseDown()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 2 * 2 && isAlive)
        {
            Debug.Log("Player tried adding log to " + gameObject.name + " ! Where health is:" + health);
            player.GetComponent<PlayerController>().AddLogToFire(gameObject);
        }

    }

    public void TakeDamage()
    {
        health--;
        healthDecreaseTime = healthDecreaseTimeSet;
        //Debug.Log("Fire health: " + health);
        UpdateLight();
    }

    public void LogAdd()
    {
        health += logAddValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        logThrown.PlayOneShot(logFire);
    }

    public void UpdateLight()
    {
        fireStrength = health / 100 + 0.5f;
        //Debug.Log(fireStrength);
        light.intensity = fireStrength;
        //Debug.Log("Decreased light");   
    }

    public void GameOver()
    {   
        gameOver.SetActive(true);
        playBtn.SetActive(true);
        quitBtn.SetActive(true);
        fireDie.Play();
        fire.Stop();
        light.intensity = 0;
        Debug.Log("GAME OVER");
        scoreHolder.GetComponent<ScoreCounter>().isAlive = false;
        player.GetComponent<PlayerController>().isAlive = false;
    }
}
