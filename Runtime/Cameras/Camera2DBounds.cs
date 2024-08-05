using UnityEngine;

namespace BBUnity.Cameras {
    public class Camera2DBounds {

        private Camera _camera;

        private float _width = 0;
        private float _halfWidth = 0;

        private float _height = 0;
        private float _halfHeight = 0;

        private float _minimumX = 0;
        private float _minimumY = 0;
        private float _maximumX = 0;
        private float _maximumY = 0;

        public float Height {
            get { return _height; }
        }

        public float Width {
            get { return _width; }
        }

        public float HalfHeight {
            get { return _halfHeight; }
        }

        public float HalfWidth {
            get { return _halfWidth; }
        }

        public float MaximumY {
            get { return _maximumY; }
        }

        public float MinimumY {
            get { return _minimumY; }
        }

        public float MaximumX {
            get { return _maximumX; }
        }

        public float MinimumX {
            get { return _minimumX; }
        }

        public Camera2DBounds(Camera camera) {
            _camera = camera;
            _halfHeight = camera.orthographicSize;
            _halfWidth = _halfHeight * camera.aspect;

            _width = _halfWidth * 2;
            _height = _halfHeight * 2;

            _minimumX = -_halfHeight;
            _minimumY = -_halfHeight;
            _maximumX = _halfHeight;
            _maximumY = _halfHeight;
        }

        public Vector3 RandomPosition {
            get {
                return new Vector3(Random.Range(_minimumX, _maximumX) + _camera.transform.position.x,
                    Random.Range(_minimumY, _maximumY) + _camera.transform.position.y, _camera.transform.position.z);
            }
        }
    }
}