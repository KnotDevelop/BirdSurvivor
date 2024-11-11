using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flyingMonster
{
    public class TextureOffset : MonoBehaviour
    {
        [SerializeField] Material mat;
        [SerializeField] float offsetX, speed;
        private void Start()
        {
            mat = GetComponent<Renderer>().material;
        }
        // Update is called once per frame 
        void Update()
        {
            mat.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));
            offsetX += Time.deltaTime * speed;
        }
    }
}
