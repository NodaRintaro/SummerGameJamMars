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
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
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
            // todo: 要る分だけ追加
            None,
            Test
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
            // todo: 要る分だけ追加
            None,
            Test,
            Title,
            InGame,
            GameOver,
            Clear
        }
    }
}