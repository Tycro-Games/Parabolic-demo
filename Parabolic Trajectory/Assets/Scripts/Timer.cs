using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Utility
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private bool loop = false;

        [SerializeField]
        private UnityEvent OnTimerFinished = null;

        [SerializeField]
        private float TimeToWait = 0;

        private void OnDisable()
        {
            StopCoroutine(TimerLoop());
        }

        private void OnEnable()
        {
            StartCoroutine(TimerLoop());
        }

        private IEnumerator TimerLoop()
        {
            
            yield return new WaitForSeconds(TimeToWait);
            OnTimerFinished?.Invoke();

            if (loop)
                StartCoroutine(TimerLoop());
        }
    }
}