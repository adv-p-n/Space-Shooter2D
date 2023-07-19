using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime= 5f;
    [SerializeField] float baseFireRate=0.25f;
    [SerializeField] GameObject projectile;

    [Header("AI")]
    [SerializeField]bool useAI;
    [SerializeField] float FiringVariation= 0.5f;
    [SerializeField] float minFireRate= 0.5f;    
    [HideInInspector]public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    void Awake()
    {
        audioPlayer=FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI){isFiring=true;}
    }

    void Update()
    {
       Fire();
        
    }
    void Fire()
    {
         if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(IsFiringCountinously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine=null;
        }
    }
    IEnumerator IsFiringCountinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectile,transform.position,Quaternion.identity);
            audioPlayer.PlayShootingClip();
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * projectileSpeed ;
            Destroy(instance,projectileLifetime);
            yield return new WaitForSeconds(GetRandomFireRate());
        }
    }
    float GetRandomFireRate()
    {
        float randomFireRate = Random.Range( baseFireRate-FiringVariation,baseFireRate+FiringVariation);
        return Mathf.Clamp(randomFireRate,minFireRate,float.MaxValue);
        
    }

}
