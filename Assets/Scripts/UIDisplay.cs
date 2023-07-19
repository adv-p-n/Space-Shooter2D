using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField]Health health;
    ScoreKeeper scoreKeeper;
    [SerializeField]TextMeshProUGUI scoreDisplay;
    Slider healthBar;
    void Awake()
    {
        health=FindObjectOfType<Health>();
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
        scoreDisplay= GetComponentInChildren<TextMeshProUGUI>();
        healthBar = GetComponentInChildren<Slider>();
    }

    void Start()
    {
        healthBar.maxValue=health.GetHealth();
    }
    void Update()
    {
        HealthUpdate();
        ScoreUpdate();
        
    }

    void ScoreUpdate()
    {
        scoreDisplay.text = scoreKeeper.GetScore().ToString("000000000");
    }

    void HealthUpdate()
    {
        healthBar.value = health.GetHealth();
    }
}
