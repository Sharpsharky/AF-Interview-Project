using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace AFSInterview.Battle
{
    public class BattlePanelController : SerializedMonoBehaviour
    {
        [SerializeField] private TMP_Text timeCounterText;
        [SerializeField] private TMP_Text teamNameText;

        public void StartCountingTime(int timeToCount, Action OnFinishCurrentState)
        {
            StartCoroutine(CountTime(timeToCount, OnFinishCurrentState));
            timeCounterText.gameObject.SetActive(true);
        }        
        public void DisplayWinningTeam(string teamName)
        {
            Debug.Log("team won:" + teamName);
            teamNameText.text = $"Team {teamName} won!";
            teamNameText.gameObject.SetActive(true);
        }

        private IEnumerator CountTime(int timeToCount, Action OnFinishCurrentState)
        {
            for (int i = timeToCount; i >= 1; i--)
            {
                timeCounterText.text = i.ToString();
                yield return new WaitForSeconds(1);
            }
            timeCounterText.gameObject.SetActive(false);
            OnFinishCurrentState();
            yield return null;
        }
    }
}