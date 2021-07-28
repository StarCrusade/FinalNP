using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int Health = 10;
    public bool Alive { private set; get; } = true;
    private Animator anim = null;

    public AudioClip ArrowImpact;
    public float Volume;
    public AudioSource Audio;
    public bool alreadyPlayed = false; 

    SkinnedMeshRenderer msh;

    GameObject spawner; 
    GroundSpawner Gspawner;

    GameObject player;
    ArenaPlayerHealth playerHealthScript;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();       
        SetupBodyParts();

        msh = GetComponentInChildren<SkinnedMeshRenderer>();
        msh.material.color = Color.blue;

        spawner = GameObject.FindGameObjectWithTag("Spawner");
        Gspawner = spawner.GetComponent<GroundSpawner>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<ArenaPlayerHealth>();

    }

    private void Update()
    {
       
    }

    private void SetupBodyParts()
    {
        BodyPart[] bodyparts = GetComponentsInChildren<BodyPart>();

        foreach (BodyPart bodypart in bodyparts)
        {
            bodypart.Setup(this);   
        }
    }

    public void TakeDamage(int damage)
    {
        if (!Alive)
        {
            return; 
        }
        Health -= damage;
        StartCoroutine(ReturnBlack());
        Audio.PlayOneShot(ArrowImpact, Volume);
        alreadyPlayed = true;

        if (Health<= 0)
        {
            Gspawner.killCount++;
            Kill();
            playerHealthScript.currentHealth ++;
        }

    }

    public void Kill()
    {
        Alive = false;        
        anim.SetBool("IsDead", true);
        Gspawner.enemiesKilled++;
        StartCoroutine(DestroyWhenDead());             
       
    }

    IEnumerator DestroyWhenDead()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);        
    }

    private void TurnRed()
    {
        msh.material.color = Color.yellow;
    }
    IEnumerator ReturnBlack()
    {
        TurnRed();
        yield return new WaitForSeconds(0.1f);
        msh.material.color = Color.blue;
    }
}
