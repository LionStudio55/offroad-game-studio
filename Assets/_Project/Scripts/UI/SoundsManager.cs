using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceOver
{
    public AudioClip Voice;
    public float volume;
    public AudioSource source;
}


public class SoundsManager : GenericSingletonClass<SoundsManager>
{
    //private static T instance;
    //public static T Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<T>();
    //            if (instance == null)
    //            {
    //                GameObject obj = new GameObject();
    //                obj.name = typeof(T).Name;
    //                instance = obj.AddComponent<T>();
    //            }
    //        }
    //        return instance;
    //    }
    //}
    //public static SoundsManager Instance;
    [SerializeField] private float defaultSoundSourceVolume = 1;
    [SerializeField] private float defaultMusicSourceVolume = 1;

    [Header("Audio Sources")]
    public AudioSource soundSource;
    public AudioSource musicSource;

    [Header("BG Clips")]
    public AudioClip menuBG;
    public AudioClip[] gameBG;

    [Header("Sound Clips")]
    //public AudioClip IntroAnimation;
    public AudioClip buttonPress;
    //public AudioClip On_PressMoreGameRateus;
    //public AudioClip PrivacyPolicyPress;
    //public AudioClip weaponPress;
    //public AudioClip Quit;
    //public AudioClip okyesNo;
    //public AudioClip levelpress;
    //public AudioClip OnPressCompaignMode;
    //public AudioClip OnPresslockedbutton;
    //public AudioClip OnAnyPopupAppear;
    //public AudioClip lockedlevelpopupokclick;
    //public AudioClip settingpopup;
    //public AudioClip settingpopupOkclick;
    //public AudioClip PlayButtonMainMenuclick;
    //public AudioClip BackButtonAnySelectionclick;
    //public AudioClip PlayButtonGunselectionclick;
    public AudioClip OnPressNextGun;
    //public AudioClip OnPressPreviousGun;
    //public AudioClip GamePLayPopup;
    public AudioClip GameUIclicks;
    public AudioClip levelComplete;
    public AudioClip levelFail;
    //public AudioClip letsgo;
    public AudioClip GetReady;
    public AudioClip AudienceAppreciation;
    public AudioClip singleCoinsSound;
    public AudioClip CoinscollectSound;

    public AudioClip Savepointclip;
    //public AudioClip Pickupnitro;
    public List<AudioClip> voiceovers;
    //public List<AudioClip> Countingvoiceovers;

    public AudioClip StartEngineVoiceOver;
    public AudioClip StartEngine;
    //public AudioClip GlassBreakable;
    public AudioClip Dooropen, DoorClose;
    //public AudioClip wastedsound;

    public override void Awake()
    {

        //if (instance == null)
        //{
        //    instance = this as T;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    //  Instance = this;
        //    Destroy(gameObject);
        //}
        //  Instance = this;
        base.Awake();
        DontDestroyOnLoad(this);

    }
    private void Start()
    {

        //Set_MusicStatus();
        //Set_SoundStatus();
        if (PlayerPrefs.GetInt("ConsentAd") == 0)
        {
            Set_SoundVolume(defaultSoundSourceVolume);
            Set_MusicVolume(defaultMusicSourceVolume);
        }
        else 
        {
            Set_SoundVolume(PlayerPrefs.GetFloat("SoundVolume"));
            Set_MusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        }
        PlayMusic_Menu();

    }
    //private void Update()
    //{
    //    print("QualitySettings :" + QualitySettings.GetQualityLevel());
    //}
    public void Pause()
    {

        //this.soundSource.Pause ();
        this.musicSource.Pause();
    }

    public void UnPause()
    {

        //this.soundSource.UnPause ();
        //print("unpause");
        this.musicSource.UnPause();

    }

    public void PlaySound(AudioClip _clip)
    {

        soundSource.PlayOneShot(_clip);
    }

    public void PlaySoundAfterStop(AudioClip _clip)
    {
        Stop_PlayingSound();
        soundSource.PlayOneShot(_clip);
    }

    public void Stop_PlayingSound()
    {
        soundSource.Stop();
    }

    public void Stop_PlayingMusic()
    {
        musicSource.Stop();
    }
    public void PlayMusic_Menu()
    {
       // print("pLAYmUSIC ");
        musicSource.clip = menuBG;
        musicSource.Play();
    }

    public void PlayMusic_Game(int index)
    {
        musicSource.clip = gameBG[index];
        musicSource.Play();

    }
    public void PlayMusic_Game(AudioClip sound)
    {
        musicSource.clip = sound;
        musicSource.Play();

    }
    //public void letGo_Sound()
    //{
    //	musicSource.clip = letsgo;
    //	musicSource.Play();
    //}

    //public void getready_Sound()
    //{
    //	musicSource.clip = GetReady;
    //	musicSource.Play();
    //}


    public void Set_MusicStatus()
    {
        musicSource.volume = defaultMusicSourceVolume;
      
        PlayerPrefs.SetFloat("MusicVolume", defaultMusicSourceVolume);
    }

    public void Set_SoundStatus()
    {
        soundSource.volume = defaultSoundSourceVolume;
        PlayerPrefs.SetFloat("SoundVolume", defaultSoundSourceVolume);
    }

    public void Set_SoundVolume(float _val)
    {
        soundSource.volume = _val;
        PlayerPrefs.SetFloat("SoundVolume", _val);
        defaultSoundSourceVolume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public void Set_MusicVolume(float _val)
    {
        musicSource.volume = _val;
        PlayerPrefs.SetFloat("MusicVolume", _val);
        defaultMusicSourceVolume = PlayerPrefs.GetFloat("MusicVolume");
    }

}
