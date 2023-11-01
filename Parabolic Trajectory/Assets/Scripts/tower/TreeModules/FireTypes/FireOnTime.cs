using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class FireOnTime : MonoBehaviour, IFireRater
    {
        [SerializeField]
        private float time = 0;

        [SerializeField]
        private UnityEvent OnShoot = null;

        [SerializeField]
        private UnityEvent OnRecharge = null;

        public IEnumerator Wait ()
        {
            OnShoot?.Invoke ();//OnShoot

            yield return new WaitForSeconds (time);
            OnRecharge?.Invoke ();//When it recharches
        }
    }
}