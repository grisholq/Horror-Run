using UnityEngine;

public class Billboard : MonoBehaviour
{
    private CameraFollower _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<CameraFollower>();
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform.position);
    }
}