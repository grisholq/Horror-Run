using UnityEngine;
using System.Collections;

public class CharacterSkinDemonstrator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _character;
    [SerializeField] private Light _light;

    private Coroutine _rotationProcess;

    private void Awake()
    {
        _light.enabled = false;
    }

    public void StartDemonstration()
    {
        _rotationProcess = StartCoroutine(RotationAround());
        _light.enabled = true;

        _character.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void StopDemonstration()
    {
        StopCoroutine(_rotationProcess);
        _character.transform.eulerAngles = Vector3.zero;
        _light.enabled = false;

        _character.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.Normal;
    }

    private IEnumerator RotationAround()
    {
        while(true)
        {
            _character.transform.eulerAngles += new Vector3(0, _rotationSpeed, 0) * Time.unscaledDeltaTime;
            yield return null;
        }
    }
}