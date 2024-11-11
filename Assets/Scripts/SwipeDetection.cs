using flyingMonster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flyingMonster
{
    public class SwipeDetection : MonoBehaviour
    {
        private Vector2 fingerDownPosition;
        private Vector2 fingerUpPosition;

        [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
        [SerializeField] private float minDistanceForSwipe = 20f;

        private void Update()
        {
            if (TimeManager.instance.GetGameTimeScale() == 0) return;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            //foreach (Touch touch in Input.touches)
            //{
            //    if (touch.phase == TouchPhase.Began)
            //    {
            //        fingerDownPosition = touch.position;
            //        fingerUpPosition = touch.position;
            //    }

            //    if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            //    {
            //        fingerUpPosition = touch.position;
            //        //CheckSwipe();
            //    }

            //    if (touch.phase == TouchPhase.Ended)
            //    {
            //        fingerUpPosition = touch.position;
            //        CheckSwipe();
            //    }
            //}
            if (Input.GetMouseButtonDown(0))
            {
                fingerDownPosition = Input.mousePosition;
                fingerUpPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0)) 
            {
                fingerUpPosition = Input.mousePosition;
                CheckSwipe();
            }
        }

        private void CheckSwipe()
        {
            FieldManager _fm = FieldManager.instance;
            if (SwipeDistanceCheckMet())
            {
                // Swipe in X direction
                if (Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x) > Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y))
                {
                    if (fingerDownPosition.x - fingerUpPosition.x > 0)
                    {
                        StartCoroutine(_fm.SetPlayerPosition(_fm.currentField.left));
                        Player.instance.ChangePlayerFaceDirection("left");
                        AudioManager.instance.Play_Swipe();
                        //Debug.Log("Left Swipe");
                    }
                    else
                    {
                        StartCoroutine(_fm.SetPlayerPosition(_fm.currentField.right));
                        Player.instance.ChangePlayerFaceDirection("right");
                        AudioManager.instance.Play_Swipe();
                        //Debug.Log("Right Swipe");
                    }
                }
                // Swipe in Y direction
                else
                {
                    if (fingerDownPosition.y - fingerUpPosition.y > 0)
                    {
                        StartCoroutine(_fm.SetPlayerPosition(_fm.currentField.down));
                        Player.instance.ChangePlayerFaceDirection("down");
                        AudioManager.instance.Play_Swipe();
                        //Debug.Log("Down Swipe");
                    }
                    else
                    {
                        StartCoroutine(_fm.SetPlayerPosition(_fm.currentField.top));
                        Player.instance.ChangePlayerFaceDirection("up");
                        AudioManager.instance.Play_Swipe();
                        Debug.Log("Up Swipe");
                    }
                }

                fingerDownPosition = fingerUpPosition;
            }
        }

        private bool SwipeDistanceCheckMet()
        {
            return Vector2.Distance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe;
        }
    }
}
