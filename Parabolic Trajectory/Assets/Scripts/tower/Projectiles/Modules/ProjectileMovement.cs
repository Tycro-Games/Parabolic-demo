using UnityEngine;

namespace Assets.Scripts.Tree.Projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve speedCurve = null;

        private float currentTime = 0;

        [SerializeField]
        private float duration = 1.0f;

        private void Start()
        {
            currentTime = 0;
        }

        public void MoveToTarget(Transform target, float speed)//called until it reaches the target in Update
        {
            //this function just moves a thing from point A to B
            Vector2 pos = Vector2.MoveTowards(transform.position, target.position,
                Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));//magic animation curve

            //rotate after target
            Quaternion rot = Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);
            //set
            transform.SetPositionAndRotation(pos, rot);
        }

        private float TimeManagement()
        {
            currentTime += Time.deltaTime;//currentTime=currentTime+Time.deltaTime
            return currentTime / duration;//return values from 0 to 1
        }

        public void MoveToTarget(Vector3 dir, float speed)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));
            if (speedCurve.Evaluate(TimeManagement()) <= 0)
                Destroy(gameObject);
        }
    }
}