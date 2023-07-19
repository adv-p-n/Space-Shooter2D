using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadDelay=2f;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        scoreKeeper.ResetScore();
    }
    public void LoadGameOver()
    {
        StartCoroutine(DelayAndLoad(2,loadDelay));
        Debug.Log(scoreKeeper.GetScore());
    }
    public void Quit()
    {
        Debug.Log("Quittting ....");
        Application.Quit();
    }

    IEnumerator DelayAndLoad(int scene,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

}
