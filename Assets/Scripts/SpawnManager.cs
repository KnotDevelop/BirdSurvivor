using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace flyingMonster
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] Bullet bullet;
        //[SerializeField] float shootDeley = 2f;
        [SerializeField] float mainDeley = 0;
        [SerializeField] float mainSpeed = 0;
        [SerializeField] int speedCap = 0;
        private void Start()
        {
            UIManager.Instance.UpdateTimeText();
            UIManager.Instance.StartPanel_Switch(true);
            AudioManager.instance.Play_Background();
        }
        public void StartGame()
        {
            StartCoroutine(TimeManager.instance.TimeCount());
            StartCoroutine(ShootState());
            UIManager.Instance.StartPanel_Switch(false);
        }
        public void ReLoadScene() 
        {
            SceneManager.LoadScene("FlyingMonster");
        }
        void SpawnBullet()
        {
            int _rn = Random.Range(0, transform.childCount);
            Bullet _bl = Instantiate(bullet, transform.GetChild(_rn));
            _bl.name = "Bullet";
            _bl.transform.localPosition = Vector3.zero;
            _bl.speed = mainSpeed;
            StartCoroutine(_bl.Shoot());
        }

        public IEnumerator ShootState()
        {
            LearningCurveCalculate();
            yield return new WaitUntil(()=>TimeManager.instance.isPuase == false);
            SpawnBullet();
            AudioManager.instance.Play_Fire();
            yield return new WaitForSeconds(mainDeley);
            StartCoroutine(ShootState());
        }

        void LearningCurveCalculate() 
        {
            float _t = TimeManager.instance.time;
            mainDeley = 2f - (_t * 0.01f);
            mainSpeed = 2f + (_t * 0.01f);
            //if (_t < 15)
            //{
            //    mainDeley = 2f;
            //    mainSpeed = 2f;
            //}
            //else if (_t < 30)
            //{
            //    mainDeley = 1.5f;
            //}
            //else if (_t < 60)
            //{
            //    mainDeley = 1f;
            //    mainSpeed = 3f;
            //}
            //else if (_t < 90)
            //{
            //    mainDeley = 0.5f;
            //}
            //else if (_t < 120)
            //{
            //    mainDeley = 0.35f;
            //    mainSpeed = 4f;
            //}
            //else 
            //{
            //    mainDeley = 0.2f;
            //    speedCap++;
            //    mainSpeed += speedCap * 0.5f;
            //}
        }
    }
}
