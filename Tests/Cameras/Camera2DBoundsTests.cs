using System;
using UnityEngine;
using NUnit.Framework;

using BBUnity;
using BBUnity.Cameras;
using BBUnity.TestSupport;

namespace Cameras {
    public class Camera2DBoundsTests {

        [Test]
        public void WhenPassedACamera_ShouldHaveAWidthAndHeight() {
            TestOrthograhicCamera((Camera camera) => {
                Camera2DBounds bounds = new Camera2DBounds(camera);

                Assert.AreEqual(10, bounds.Height);
                Assert.AreEqual(15.0f, bounds.Width);
            });
        }

        [Test]
        public void WhenPassedACamera_ShouldHaveBounds() {
            TestOrthograhicCamera((Camera camera) => {
                Camera2DBounds bounds = new Camera2DBounds(camera);

                Assert.AreEqual(5.0f, bounds.MaximumX);
                Assert.AreEqual(-5.0f, bounds.MinimumX);
                Assert.AreEqual(5.0f, bounds.MaximumY);
                Assert.AreEqual(-5.0f, bounds.MinimumY);
            });
        }

        [Test]
        public void RandomPosition_ShouldGiveARandomPositionInSideTheBounds() {
            TestOrthograhicCamera((Camera camera) => {
                Camera2DBounds bounds = new Camera2DBounds(camera);

                Vector3 position = bounds.RandomPosition;

                Assert.IsTrue(position.x > bounds.MinimumX);
                Assert.IsTrue(position.x < bounds.MaximumX);

                Assert.IsTrue(position.y > bounds.MinimumY);
                Assert.IsTrue(position.y < bounds.MaximumY);
            });
        }

        private void TestOrthograhicCamera(Action<Camera> action, float size = 5.0f, float aspect = 1.5f) {
            TestUtilities.CreateThenDestroyGameObject<Camera>((Camera camera) => {
                camera.orthographic = true;
                camera.orthographicSize = size;
                camera.aspect = aspect;

                action(camera);
            });
        }
    }
}