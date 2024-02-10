using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] private float _sceneChangeDelay = 1f;
    private void Awake()
    {
        EventManager.onEndedHealth.AddListener(StartChangeSceneCoroutine);
    }
    public void OnClickLoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickLoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    private void StartChangeSceneCoroutine()
    {
        StartCoroutine(LoadDeathScene());
    }

    private IEnumerator LoadDeathScene()
    {
        yield return new WaitForSeconds(_sceneChangeDelay);
        SceneManager.LoadScene(2);
    }
}
