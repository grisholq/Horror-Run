using UnityEngine;

public class SanitySkinsDemonstrator : MonoBehaviour, ICameraFollowed
{
    [SerializeField] private SanityIncreaser _increaserDemonstrator;
    [SerializeField] private SanityDecreaser _decreaserDemonstrator;

    public Vector3 Position => transform.position + new Vector3(0, 1, -5);
    public Vector3 LookOffset => Vector3.zero;
    public Transform Transform => transform;

    public void SetAsCameraFollowed()
    {
        CameraFollower.Instance.Followed = this;
    }

    public void StartDemonstration()
    {
        SetAsCameraFollowed();
    }

    public void StopDemonstration()
    {

    }

    private void Update()
    {
        _increaserDemonstrator.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        _decreaserDemonstrator.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}