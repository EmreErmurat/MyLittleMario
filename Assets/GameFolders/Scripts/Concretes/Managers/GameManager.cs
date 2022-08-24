using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyLittleMario.Inputs;

public class GameManager : MonoBehaviour
{
    public int ActiveSceneIndex => SceneManager.GetActiveScene().buildIndex;
    


    public static GameManager Instance { get; private set; }

    float _delayLevelTime = 0.5f;

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

    
}
