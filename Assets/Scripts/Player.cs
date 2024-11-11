using UnityEngine;

namespace flyingMonster
{
    public class Player : MonoBehaviour
    {
        public static Player instance;
        public Transform playerBody;
        private void Awake()
        {
            instance = this;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null) 
            {
                if (collision.gameObject.name == "Bullet")
                {
                    Dead();
                }
            }
        }
        public void PlayAnimation_Idle()
        {
            GetComponent<Animator>().CrossFade("Idle", 0.2f);
        }
        public void PlayAnimation_Jump()
        {
            GetComponent<Animator>().CrossFade("jump", 0.2f);
        }
        void Dead()
        {
            TimeManager.instance.Puase();
            UIManager.Instance.ShowScore(Mathf.CeilToInt(TimeManager.instance.time));
            AudioManager.instance.Play_Dead();
            AudioManager.instance.Stop_Background();
            AudioManager.instance.Play_GameOver();
            Debug.Log("Dead");
        }
        public void ChangePlayerFaceDirection(string _result)
        {
            switch (_result) 
            {
                case "up":
                    playerBody.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case "down":
                    playerBody.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case "left":
                    playerBody.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                case "right":
                    playerBody.rotation = Quaternion.Euler(0, 0, 90);
                    break;
            }
        }
    }
}
