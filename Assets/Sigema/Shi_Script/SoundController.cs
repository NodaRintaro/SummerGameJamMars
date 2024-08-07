using System;
using UnityEngine;

/// <summary>
/// SE・BGMを再生
/// </summary>
public class SoundController : MonoBehaviour
{
    public static SoundController Instance = default;
    [SerializeField] private AudioSource _seAudio = default;
    [SerializeField] private AudioSource _bgmAudio = default;
    [SerializeField] private SeClass[] _seClass = default;
    [SerializeField] private BgmClass[] _bgmClass = default;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SePlay(SeClass.SE se)
    {
        SeClass data = null;
        foreach (var playSe in _seClass)
        {
            if (playSe.SeState != se) continue;
            data = playSe;
            break;
        }

        _seAudio?.PlayOneShot(data?.SeClip, data.Volume);
    }

    public void BgmPlay(BgmClass.BGM bgm)
    {
        BgmClass data = null;
        foreach (var playSe in _bgmClass)
        {
            if (playSe.BgmState != bgm) continue;
            data = playSe;
            break;
        }

        _bgmAudio.clip = data?.BgmClip;
        _bgmAudio.volume = data.Volume;
        _bgmAudio.Play();
    }

    [Serializable]
    public class SeClass
    {
        [SerializeField] private AudioClip _seClip = default;
        [SerializeField] private SE _seState = default;
        [SerializeField] private float _volume = default;

        #region プロパティ

        public AudioClip SeClip => _seClip;
        public SE SeState => _seState;
        public float Volume => _volume;

        #endregion

        public enum SE
        {
            None,
            Test,

            /// <summary> スタミナ0になった </summary>
            Stamina0,

            /// <summary> スタミナ切れそう </summary>
            LackOfStamina,
            ClearSE,

            /// <summary> 敵との接触 </summary>
            Hit,

            /// <summary> スタートボタンの音 </summary>
            StartGame,

            /// <summary> スタートボタンの音 </summary>
            ButtonPush,
            Fireworks,
            LevelUp,

            /// <summary> 着水 </summary>
            LandingOnTheWater,
            GameOverSe,

            /// <summary> 飛行音 </summary>
            FlightSe
        }
    }

    [Serializable]
    public class BgmClass
    {
        [SerializeField] private AudioClip _bgmClip = default;
        [SerializeField] private BGM _bgmState = default;
        [SerializeField] private float _volume = default;

        #region プロパティ

        public AudioClip BgmClip => _bgmClip;
        public BGM BgmState => _bgmState;
        public float Volume => _volume;

        #endregion

        public enum BGM
        {
            None,
            Test,
            Title,
            InGame,
            Clear
        }
    }
}