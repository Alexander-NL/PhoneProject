using UnityEngine;

public class SfxUi : MonoBehaviour
{
    public AudioClip UiOnClick;
    public AudioClip Victory;
    public AudioClip Lose;
    public AudioClip CollectCoin;

    public AudioSource UiSource;



    public void Start()
    {
        UiSource.clip = UiOnClick;
        UiSource.Play();
    }

    public void SfxOnClick()
    {
        UiSource.clip = UiOnClick;
        UiSource.Play();
    }

    public void VictoryOnClick()
    {
        UiSource.clip = Victory;
        UiSource.Play();
    }

    public void LoseOnClick()
    {
        UiSource.clip = Lose;
        UiSource.Play();
    }

    public void CollectCoinOnClick()
    {
        if(UiSource.clip = CollectCoin)
        {
            UiSource.Play();
        }
        else
        {
            UiSource.clip = CollectCoin;
            UiSource.Play();
        }
    }
}
