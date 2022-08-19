using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
    }
}
