using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        scoreText.text = "Score :"+scoreKeeper.GetScore().ToString("000000000");
    }

}
