using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;


    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        Time.timeScale = 1f;
    }


    public void Tutorial()
    {
        levelToLoad = "TutorialLevel";
        sceneFader.FadeTo(levelToLoad);
    }


    public void Back()
    {
        levelToLoad = "MainMenu";
        sceneFader.FadeTo(levelToLoad);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
