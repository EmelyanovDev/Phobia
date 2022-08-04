﻿using System;
using UI;
using UnityEngine;
using View;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float sensitivity;
        [SerializeField] private float smoothnessValue;
        
        private CameraRotation _cameraRotation;

        private void Awake()
        {
            _cameraRotation = GetComponentInChildren<CameraRotation>();
        }

        private void OnEnable() => RotationPanel.OnPointerDrag += RotatePlayer;

        private void OnDisable() => RotationPanel.OnPointerDrag -= RotatePlayer;

        private void RotatePlayer(Vector2 touchDelta)
        {
            Vector2 rotate = touchDelta * Time.deltaTime * sensitivity;
            Vector3 target = transform.localEulerAngles += new Vector3(0, rotate.x);
            transform.localEulerAngles = target;
            
            _cameraRotation.RotateCamera(-rotate.y);
        }

        public void ChangeSensitivity(float value) => sensitivity = value;
    }
}