using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
    {
        public GameObject Ball;
        public float Rotation_Val;
        public Slider Slider1;

        void Start()
        {
            ChangeScale();
        }

        private void ChangeScale(float t_heigt = 1f)
        {
            Rotation_Val = t_heigt * 100;
            Ball.transform.localScale = new Vector3(Rotation_Val, Rotation_Val, Rotation_Val);
        }

        void Update()
        {
            ChangeScale(Slider1.value);
        }
    }
