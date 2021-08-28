using UnityEngine;

public class CharacterSkinDemonstrator : MonoBehaviour
{
    [SerializeField] private Transform _character;

    public void StartDemonstration()
    {
        _character.eulerAngles += new Vector3(0, 180, 0);
    }

    public void StopDemonstration()
    {
        _character.eulerAngles -= new Vector3(0, 180, 0);
    }
}