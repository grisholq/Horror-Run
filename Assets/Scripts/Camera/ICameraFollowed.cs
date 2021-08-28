using UnityEngine;

public interface ICameraFollowed
{
    Vector3 Position { get; }
    Vector3 LookOffset { get; }
    Transform Transform { get; }

    void SetAsCameraFollowed();
}