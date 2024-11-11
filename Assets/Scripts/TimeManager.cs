using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flyingMonster
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance;
        public float gameTimeScale = 0;
        public float time = 0;
        public bool isTime = false;
        public bool isPuase = true;

        private void Awake()
        {
            instance = this;
        }
        public float GetGameTimeScale()
        {
            return gameTimeScale;
        }
        public void SetTimeScale(bool _result) 
        {
            if (_result)
            {
                gameTimeScale = 1;
            }
            else 
            {
                gameTimeScale = 0;
            }
        }
        public IEnumerator TimeCount()
        {
            yield return Unpuase();
            isTime = true;
            while (isTime)
            {
                time += Time.deltaTime * GetGameTimeScale();
                UIManager.Instance.UpdateTimeText();
                yield return null;
            }
        }
        public void Puase()
        {
            isPuase = true;
            SetTimeScale(false);
        }
        public IEnumerator Unpuase()
        {
            yield return new WaitForSeconds(0.2f);
            isPuase = false;
            SetTimeScale(true);
        }
    }
}
