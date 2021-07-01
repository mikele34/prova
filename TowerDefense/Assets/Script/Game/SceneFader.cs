using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;


    void Start()
    {
        StartCoroutine(FadeIn());
    }


    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeIn()
    {
        float m_time = 1f;

        while (m_time > 0f)
        {
            m_time -= Time.deltaTime;
            float a = curve.Evaluate(m_time);
            img.color = new Color (0f, 0f, 0f, a);
            yield return 0;
        }
    }


    IEnumerator FadeOut(string scene)
    {
        float m_time = 0f;

        while (m_time < 1f)
        {
            m_time += Time.deltaTime;
            float a = curve.Evaluate(m_time);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
