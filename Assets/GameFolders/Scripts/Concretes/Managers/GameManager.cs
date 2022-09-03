using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyLittleMario.Inputs;
using MyLittleMario.Controllers;

public class GameManager : MonoBehaviour
{
    public int ActiveSceneIndex => SceneManager.GetActiveScene().buildIndex;

    public event System.Action<int> scorePrinter;

    [SerializeField] int score;


    public static GameManager Instance { get; private set; }

    float _delayLevelTime = 0.5f;


    public GameObject PlayerObject { get; private set; }

    private void Awake()
    {
        SingletonGameObject();
        
    }



    private void SingletonGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsync(levelIndex));
    }

    private IEnumerator LoadSceneAsync(int levelIndex)
    {
        yield return new WaitForSeconds(_delayLevelTime);

        yield return SceneManager.UnloadSceneAsync(ActiveSceneIndex);

        SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(levelIndex));
        };

       
    }

   

    public void ExitGame()
    {
        print("Quit Game");
        Application.Quit();
    }


    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;
        scorePrinter?.Invoke(score);
        
    }

    public void SetPlayer(GameObject value)
    {
        PlayerController player = value.GetComponent<PlayerController>();
        if (player != null)
        {
            PlayerObject = value;
        }
    }
    
}
