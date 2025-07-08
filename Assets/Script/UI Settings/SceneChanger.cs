using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject TransitionImage;
    //public FadeTrigger fadeTrigger;
    public Image fadeImage;
    public float fadeDuration = 1f;

    public bool FadeIn = true;

    public void Start()
    {
        if (FadeIn)
        {
            StartCoroutine(FadeInTransition());
        }
        else
        {
            TransitionImage.SetActive(false);
        }
    }

    public void ExitGame()
    {
        TransitionImage.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(FadeAndExit());
    }

    public void ChangeSceneWithFade(string sceneName)
    {
        Debug.Log("IT WORKS?");
        TransitionImage.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    public void EndSceneWithFade(string sceneName)
    {
        TransitionImage.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(FadeToWhiteLoadScene(sceneName));
    }


    /// <summary>
    /// A custom one so that the fade screen is white
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    IEnumerator FadeToWhiteLoadScene(string sceneName)
    {
        // Fade to black
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }


    /// <summary>
    /// This one fades out the scene
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeInTransition()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = 1 - Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        TransitionImage.SetActive(false);
    }


    /// <summary>
    /// This one is for changing scene with a delay so it fades in and loads scene
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Fade to black
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// This is for when fading out exit with a custom fade BG
    /// </summary>
    /// <returns>
    /// Exit game
    /// </returns>
    IEnumerator FadeAndExit()
    {
        // Fade to black
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        Application.Quit();
    }
}