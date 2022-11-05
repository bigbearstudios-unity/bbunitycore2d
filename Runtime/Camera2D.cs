using UnityEngine;

using BBUnity.CameraUtilities;

namespace BBUnity {

    [AddComponentMenu("BBUnity/2D/Camera2D")]
    public class Camera2D : BaseBehaviour {

        [SerializeField]
        private Camera2DBoundColliderSettings _boundColliderSettings;

        [SerializeField]
        private Camera2DShakeSettings _shakeSettings;

        private Camera _camera;

        /*
         * Boundaries
         */
        private Camera2DBounds _bounds;
        private Camera2DBoundColliders _boundaryColliders;

        private Camera2DShake _cameraShake;

        public Camera Camera {
            get { return _camera; }
        }

        public Camera2DBounds Bounds {
            get { return _bounds; }
        }

        public Camera2DBoundColliders BoundColliders {
            get { return _boundaryColliders; }
        }

        public Vector3 RandomCameraPosition {
            get {
                return _bounds.RandomPosition;
            }
        }

        public void Shake(float amount = 5.0f, float duration = 1.0f) {
            if(_cameraShake == null) {
                _cameraShake = Camera2DShake.Create(this);
            }

            _cameraShake.Shake(amount, duration);
        }

        private void Awake() {
            _camera = GetComponent<Camera>();
            if(_camera == null) {
                Debug.LogError("BBUnity.Camera2D - The Camera2D component must be attached to a gameobject with a UnityEngine.Camera");
            }

            _bounds = new Camera2DBounds(_camera);
            if(_boundColliderSettings.CreateOnAwake) {
                _boundaryColliders = Camera2DBoundColliders.Create(this, _boundColliderSettings);
            }

            if(_shakeSettings.CreateOnAwake) {
                _cameraShake = Camera2DShake.Create(this);
            }
        }

        public bool IsOutOfBounds(Vector3 objectPosition) {
            return IsOutOfBoundsTop(objectPosition) || IsOutOfBoundsLeft(objectPosition) || IsOutOfBoundsRight(objectPosition) || IsOutOfBoundsBottom(objectPosition);
        }

        public bool IsOutOfBoundsTop(Vector3 objectPosition) {
            return objectPosition.y > _bounds.HalfHeight + transform.position.y;
        }

        public bool IsOutOfBoundsRight(Vector3 objectPosition) {
            return objectPosition.x > _bounds.HalfWidth + transform.position.y;
        }

        public bool IsOutOfBoundsBottom(Vector3 objectPosition) {
            return objectPosition.y < -_bounds.HalfHeight + transform.position.y;
        }

        public bool IsOutOfBoundsLeft(Vector3 objectPosition) {
            return objectPosition.y < -_bounds.HalfWidth + transform.position.y;
        }
    }
}
