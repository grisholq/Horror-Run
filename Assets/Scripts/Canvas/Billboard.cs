using UnityEngine;

public class Billboard : MonoBehaviour
{
    private MainCamera _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<MainCamera>();
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform.position);
    }
}