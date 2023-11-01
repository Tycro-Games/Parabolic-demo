using Assets.Scripts.Tree.Projectiles.Modules;
using System.Collections;
using UnityEngine;

    [RequireComponent(typeof(ArcMovement))]
    public class ProjectileArcTarget : ProjectileBase, IProjectileTarget
    {
        private Transform target = null;

        private Vector3 start;
        private ArcMovement arcMovement = null;

        private IEnumerator Move()
        {
            yield return StartCoroutine(arcMovement.Curve(transform.position, target.position));
            DestroyProjectile();
            // impact
        }

        public void Init(Transform Target)
        {
            arcMovement = GetComponent<ArcMovement>();
            target = Target;
            start = transform.position;

            StartCoroutine(Move());
        }
    }
