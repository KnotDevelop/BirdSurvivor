using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flyingMonster
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 3f;
        [SerializeField] float lifeTime = 10f;

        public IEnumerator Shoot()
        {
            TimeManager _tm = TimeManager.instance;
            while (lifeTime >= 0)
            {
                lifeTime -= _tm.GetGameTimeScale() * Time.deltaTime;
                transform.Translate(speed * _tm.GetGameTimeScale() * Time.deltaTime, 0, 0);
                yield return null;
            }
            Destroy(this.gameObject);
            yield break;
        }
    }
}
