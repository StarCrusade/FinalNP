using UnityEngine;

public class Head : BodyPart, IDamagable
{
    public AudioClip SoundToPlay;    
    public float Volume;
    public AudioSource Audio;
    public bool alreadyPlayed = false;

    void Start()
    {
        Audio = GetComponent<AudioSource>();

    }

    public new void Damage(int amount)
    {        
        //Damage owner * 2
        owner.TakeDamage(amount * 2);

        //Increase score when hit 
        ArenaScoreSystem.theScore += 1500;

        if(amount >=5)
        {
            // Play HeadShot audio
            Audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }        
    }
}
