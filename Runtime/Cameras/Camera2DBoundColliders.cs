using System;
using UnityEngine;

namespace BBUnity.Cameras {

    [Serializable]
    public struct Camera2DBoundColliderSettings {

        [SerializeField]
        private bool _createOnAwake;

        [SerializeField]
        private float _offset;

        [SerializeField]
        private float _size;

        [SerializeField, Layer]
        private int _layer;

        [SerializeField, Tooltip("The transform which will be used as the container for the Camera2DBoundColliders")]
        private GameObject _attachTo;

        public readonly bool CreateOnAwake {
            get { return _createOnAwake; }
        }

        public readonly float Offset {
            get { return _offset; }
        }

        public float Size {
            get { return _size; }
        }

        public int Layer {
            get { return _layer; }
        }

        public GameObject BoundsContainer {
            get { return _attachTo; }
        }

        public bool HasAttachmentObject {
            get { return _attachTo != null; }
        }

        public Transform AttachmentObjectOrDefault(Transform def) {
            return HasAttachmentObject ? BoundsContainer.transform : def;
        }

        public Camera2DBoundColliderSettings(bool createOnAwake, float offset, float size, int layer) {
            _createOnAwake = createOnAwake;
            _offset = offset;
            _size = size;
            _layer = layer;
            _attachTo = null;
        }
    }

    public class Camera2DBoundColliders : BBMonoBehaviour {

        private BoxCollider2D _topCollider;
        private BoxCollider2D _bottomCollidier;
        private BoxCollider2D _leftCollider;
        private BoxCollider2D _rightCollider;

        private void CreateColliders(Camera2DBounds bounds, Camera2DBoundColliderSettings settings) {
            float verticalSize = bounds.Width + (settings.Offset * 2);
            float verticalOffset = (bounds.Height / 2) + (settings.Size / 2) + settings.Offset;

            float horizontalSize = bounds.Height + (settings.Size * 2) + (settings.Offset * 2);
            float horizontalOffset = (bounds.Width / 2) + (settings.Size / 2) + settings.Offset;

            _topCollider = CreateCollider(new Vector2(0.0f, verticalOffset), new Vector2(verticalSize, settings.Size));
            _rightCollider = CreateCollider( new Vector2(horizontalOffset, 0.0f), new Vector2(settings.Size, horizontalSize));
            _bottomCollidier = CreateCollider(new Vector2(0.0f, -verticalOffset), new Vector2(verticalSize, settings.Size));
            _leftCollider = CreateCollider(new Vector2(-horizontalOffset, 0.0f), new Vector2(settings.Size, horizontalSize));
        }

        private BoxCollider2D CreateCollider(Vector2 offset, Vector2 size) {

            // TODO
            // return Utilities.Tap(gameObject.AddComponent<BoxCollider2D>(), (BoxCollider2D col) => {
            //     col.size = size;
            //     col.offset = offset;
            // });

            return null;
        }

        // public static Camera2DBoundColliders Create(Camera2D camera, Camera2DBoundColliderSettings settings) {
        //     Transform parent = settings.AttachmentObjectOrDefault(camera.transform);
        //     return Utilities.Tap(Utilities.AddOrGetComponent<Camera2DBoundColliders>(parent.gameObject), (Camera2DBoundColliders colliders) => {
        //         colliders.SetLayer(settings.Layer);
        //         colliders.ResetTransform();
        //         colliders.CreateColliders(camera.Bounds, settings);
        //     });
        // }
    }
}