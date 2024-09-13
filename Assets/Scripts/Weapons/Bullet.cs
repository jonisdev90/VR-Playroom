using Agent;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public int Damage = 10;
        
        private const float Lifetime = 3f;

        private void Start()
        {
            Destroy(gameObject, Lifetime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var target = collision.gameObject.GetComponent<Enemy>();
            
            if (target != null)
            {
                target.GetDamage(Damage);
            }

            Destroy(gameObject);
        }
    }
}