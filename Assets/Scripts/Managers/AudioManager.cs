using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {

        public enum Effect
        {
            Splash,
            NewSand,
            NewMoney,
            Boop
        }

        public enum Song
        {
            Title,
            Main,
            Intense,
            Credits
        }

        private bool _isMusicOn = true;
        private bool _isSfxOn = true;
    
        [SerializeField]
        private MusicManager musicManager;
    
        [SerializeField]
        private SfxManager sfxManager;

        private static AudioManager _instance;
        public static AudioManager Instance => _instance;

        [SerializeField]
        private List<AudioClip> soundEffects;
        [SerializeField]
        private List<AudioClip> music;
    
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }
        
            DontDestroyOnLoad(this);
            _instance = this;
        }

        public void PlaySong(Song song)
        {
            var songIndex = (int)song;
            if (songIndex < music.Count)
            {
                var file = music[songIndex];
                PlaySong(file);
            }
        }

        public void PlaySong(AudioClip clip)
        {
            musicManager.PlaySong(clip);
        }

        public void PlayEffect(Effect effect)
        {
            var effectIndex = (int)effect;
            if (effectIndex < soundEffects.Count)
            {
                var file = soundEffects[effectIndex];
                PlayEffect(file);
            }
        }
    
        public void PlayEffect(AudioClip clip)
        {
            sfxManager.PlaySound(clip);
        }

        public bool IsMusicOn()
        {
            return _isMusicOn;
        }

        public bool IsSfxOn()
        {
            return _isSfxOn;
        }

        public void SetMusicOn(bool on)
        {
            _isMusicOn = on;
            musicManager.MuteAll(!on);
        }

        public void SetSfxOn(bool on)
        {
            _isSfxOn = on;
            sfxManager.MuteAll(!on);
        }
    }
}
