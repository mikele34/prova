using UnityEngine;
using UnityEngine.UI;

public class GamemodeSelector : MonoBehaviour
{
    public SceneFader fader;

    public void levelSelect(string levelName)
    {
        fader.FadeTo(levelName);
    }
    
    public void endlessSelect(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
