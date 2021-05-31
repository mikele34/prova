using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int m_round = 0;

        yield return new WaitForSeconds(.7f);

        while (m_round < PlayerStats.Rounds)
        {
            m_round++;
            roundsText.text = m_round.ToString();

            yield return new WaitForSeconds(.5f);
        }
    }
}
