using System.Collections;
using UnityEngine;
using UnityEngine.Events;


    public abstract class ProjectileBase : MonoBehaviour
    {
        [SerializeField]
        protected int damage = 1;

        [SerializeField]
        protected float speed = 0;

        
        [SerializeField]
        private UnityEvent OnDie;

        public virtual void DestroyProjectile()
        {
            OnDie?.Invoke();
            Destroy(gameObject);
            
        }

        public virtual void DestroyProjectile(float time)
        {
            Destroy(gameObject, time);
        }
    }
