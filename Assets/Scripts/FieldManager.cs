using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace flyingMonster
{
    public class FieldManager : MonoBehaviour
    {
        public static FieldManager instance;

        [SerializeField] Player player;
        public Field currentField;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            StartCoroutine(SetPlayerPosition(currentField));
        }
        
        public IEnumerator SetPlayerPosition(Field _field = null)
        {
            if (_field == null) yield break;
            player.PlayAnimation_Jump();
            float elapsedTime = 0f;
            float lerpDuration = 0.15f;
            Vector3 startPosition = player.transform.position;
            Transform targetPosition = _field.transform;
           
            while (elapsedTime < lerpDuration)
            {
                player.transform.position = Vector3.Lerp(startPosition, targetPosition.position, elapsedTime / lerpDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            player.transform.position = targetPosition.position;
            currentField = _field;
            player.PlayAnimation_Idle();
        }
    }
}
