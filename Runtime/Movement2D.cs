using UnityEngine;

public class Movement2D {

    public static float Distance(Vector2 from, Vector2 to) {
        return Direction(from, to).magnitude;
    }

    public static float Distance(Vector3 from, Vector3 to) {
        return Direction(from, to).magnitude;
    }

    public static Vector2 Direction(Vector2 from, Vector2 to) {
        return to - from;
    }

    public static Vector3 Direction(Vector3 from, Vector3 to) {
        return to - from;
    }

    public static Vector2 DirectionNormalized(Vector2 from, Vector2 to) {
        Vector2 direction = Direction(from, to);
        direction.Normalize();
        return direction;
    }

    public static Vector3 DirectionNormalized(Vector3 from, Vector3 to) {
        Vector3 direction = Direction(from, to);
        direction.Normalize();
        return direction;
    }
}
