using UnityEngine;

namespace BBUnity.Physics2D {

    /// <summary>
    /// 
    /// </summary>
    public class BoundedRays {

        BoundedRay _left;
        BoundedRay _up;
        BoundedRay _right;
        BoundedRay _down;

        BoundedRay[] _rays;
        Bounds _collisionBounds;
        Bounds _positionedBounds;

        public BoundedRays(Bounds collisionBounds) {
            _collisionBounds = collisionBounds;
            _positionedBounds = new Bounds(_collisionBounds.center, collisionBounds.size);

            _left = BoundedRay.CreateLeftBoundedRay();
            _up = BoundedRay.CreateUpBoundedRay();
            _right = BoundedRay.CreateRightBoundedRay();
            _down = BoundedRay.CreateDownBoundedRay();

            _rays = new BoundedRay[4] { _left, _up, _right, _down };
        }

        public void Update(Vector3 position, float buffer) {
            _positionedBounds.center = position + _collisionBounds.center;

            _left.UpdateLeft(_positionedBounds, buffer);
            _up.UpdateUp(_positionedBounds, buffer);
            _right.UpdateRight(_positionedBounds, buffer);
            _down.UpdateDown(_positionedBounds, buffer);
        }

        public BoundedRay Left { get { return _left; } }
        public BoundedRay Up { get { return _up; } }
        public BoundedRay Right { get { return _right; } }
        public BoundedRay Down { get { return _down; } }

        public BoundedRay[] All {
            get {
                return _rays;
            }
        }
    }
}