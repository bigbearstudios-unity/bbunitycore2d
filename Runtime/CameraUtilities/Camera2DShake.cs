using System.Collections;
using UnityEngine;

namespace BBUnity.CameraUtilities {

    public struct Camera2DShakeSettings {
        [SerializeField]
        private bool _createOnAwake;

        public bool CreateOnAwake {
            get { return _createOnAwake; }
        }

        public Camera2DShakeSettings(bool createOnAwake) {
            _createOnAwake = createOnAwake;
        }
    }

    public class Camera2DShake : BaseBehaviour {
        private float _startAmount;
        private float _startDuration;

        private float _currentAmount;
        private float _currentDuration;

        private bool _isRunning;

        public bool IsRunning {
            get { return _isRunning; }
        }

        public void Shake(float amount = 10.0f, float duration = 1.0f) {
            if(IsRunning) {
                AddShake(amount, duration);
            } else {
                StartCoroutine(ShakeCoroutine(transform, amount, duration));
            }
        }

        private void AddShake(float amount, float duration) {
            _startAmount = amount;
            _startDuration = duration;

            _currentAmount = _startAmount;
            _currentDuration = duration;
        }

        private IEnumerator ShakeCoroutine(Transform cameraTransform, float amount, float duration) {
            _isRunning = true;
                _startAmount = amount;
                _startDuration = duration;
                _currentAmount = _startAmount;
                _currentDuration = duration;

                while (_currentDuration > 0.1f) {
                    Vector2 rotationAmount = Random.insideUnitSphere * _currentAmount;
                    float shakePercentage = _currentDuration / _startDuration;

                    _currentAmount = _startAmount * shakePercentage;
                    _currentDuration = Mathf.Lerp(_currentDuration, 0, Time.deltaTime);

                    cameraTransform.localRotation = Quaternion.Euler(rotationAmount);

                    yield return null;
                }
            _isRunning = false;
        }

        public static Camera2DShake Create(Camera2D camera) {
            return Utilities.AddOrGetComponent<Camera2DShake>(camera.gameObject);
        }
    }
}
