using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
   
    public class TreeShootTarget :  TreeShootBase
    {
        private IProjectileTarget Currentprojectile = null;
       
        public override IEnumerator Shooting(Transform target)
        {
            CanShoot = false;
           
            instance = Instantiate(projectileObject, transform.position, Quaternion.identity, transform.parent);
            Currentprojectile = CacheProjectile<IProjectileTarget>(instance);
            Currentprojectile.Init(target);
            yield return StartCoroutine(fireRater.Wait());

            CanShoot = true;

            Destroy(instance, 10.0f);
        }
    }
}