using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSenceIndex;

    // Use this for initialization
    void Start()
    {

        currentSenceIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSenceIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSenceIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
