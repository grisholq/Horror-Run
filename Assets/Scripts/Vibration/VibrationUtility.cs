public class VibrationUtility : Singleton<VibrationUtility>
{
    private void Awake()
    {
        Vibration.Init();
    }

    public void VibrateSmall()
    {
        Vibration.Vibrate(20);
    }

    public void VibrateMedium()
    {
        Vibration.Vibrate(60);
    }
}