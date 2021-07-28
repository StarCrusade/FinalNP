using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IDamagable
{
    public AudioClip SoundToPlay;
    public float Volume;
    public AudioSource Audio;
    public bool alreadyPlayed = false;
    MeshRenderer msh; 

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        msh = GetComponent<MeshRenderer>();
        msh.material.color = Color.black;
    }

    public void Damage (int amount)
    {
        StartCoroutine(ReturnBlack());
        Audio.PlayOneShot(SoundToPlay, Volume);
        alreadyPlayed = true; 
    }

   private void TurnRed()
    {        
        msh.material.color = Color.red;
    }
     IEnumerator ReturnBlack()
    {
        TurnRed();
        yield return new WaitForSeconds(0.1f);
        msh.material.color = Color.black;
    }
}
