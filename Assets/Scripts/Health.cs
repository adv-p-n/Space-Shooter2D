using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyScreenShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager= FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer!=null)
        {
            TakeDamage(damageDealer.GetDamageValue());
            PlayHitEffect();
            CamShake();
            audioPlayer.PlayDamageClip();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0) { Die(); }


    }

    void Die()
    {
        if (!isPlayer){scoreKeeper.ModifyScore(score);}
        Destroy(gameObject);
        if(isPlayer){levelManager.LoadGameOver();}
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void CamShake()
    {
        if(applyScreenShake && cameraShake!=null)
        {
            cameraShake.Play();
        }
    }
     public int GetHealth()
     {
        return (health);
     }
}
