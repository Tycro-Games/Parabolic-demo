using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.EnemyAI
{
    public class SpawnGameOBJ : MonoBehaviour
    {
        [SerializeField]
        private float lifeTime = 2.0f;

        public GameObject ToSpawn = null;
       
        public void ChangeGameobject(GameObject obj)
        {
            ToSpawn = obj;
        }

        public void Spawn()
        {
           
             GameObject ga = Instantiate(ToSpawn, transform.position, Quaternion.identity);
            Destroy(ga, lifeTime);
        }

        
           
        
    }
}