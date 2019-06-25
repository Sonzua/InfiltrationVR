using UnityEngine;

public class SteamVRFadeTest : MonoBehaviour
{
    private float _fadeDuration = 2f;

    private void Start()
    {
        //FadeToWhite();
        Invoke("FadeFromWhite", _fadeDuration);
    }
    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, _fadeDuration);
    }
    private void FadeFromWhite()
    {
        //set start color
        //SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.View(Color.black, _fadeDuration);
    }
}