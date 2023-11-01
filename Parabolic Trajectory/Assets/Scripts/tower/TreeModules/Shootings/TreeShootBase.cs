using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class TreeShootBase : MonoBehaviour, ITreeShoot
    {
        protected IFireRater fireRater = null;

        protected GameObject instance = null;

        [SerializeField]
        protected GameObject projectileObject = null;

        protected bool CanShoot { get; set; } = true;

        public virtual T CacheProjectile<T>(GameObject projectileObject)
        {
            return projectileObject.GetComponent<T>();
        }

        public bool NullProjectile()
        {
            return instance == null ? true : false;
        }

        public void Shoot(Transform target)
        {
            if (CanShoot && target != null)
                StartCoroutine(Shooting(target));
        }

        public abstract IEnumerator Shooting(Transform target);

        private void Awake()
        {
            fireRater = GetComponent<IFireRater>();
        }
    }
