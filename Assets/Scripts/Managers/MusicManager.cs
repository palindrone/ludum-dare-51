using System.Collections;
using UnityEngine;

namespace Managers
{
    public class MusicManager : MonoBehaviour
    {
        private AudioSource[] _sources;
        private int _currentPlaying;
        private AudioClip _currentClip;

        private float _fadeTime = 3.0f;

        private IEnumerator _playSongCoroutine;
    
        void Awake()
        {
            _sources = GetComponents<AudioSource>();
            _currentPlaying = 1; // This is so we'll flip to 0 on first play
        }

        public void PlaySong(AudioClip clip)
        {
            if (clip == _currentClip)
            {
                return;
            }

            var newPlaying = _currentPlaying == 0 ? 1 : 0;

            if (_playSongCoroutine != null)
            {
                StopCoroutine(_playSongCoroutine);
            }


            _playSongCoroutine = FadeMusic(clip, _sources[_currentPlaying], _sources[newPlaying]);
            StartCoroutine(_playSongCoroutine);
        
            _currentClip = clip;
            _currentPlaying = newPlaying;
        }

        IEnumerator FadeMusic(AudioClip clip, AudioSource oldSource, AudioSource newSource)
        {
            var elapsedTime = 0f;
        
            newSource.clip = clip;
            newSource.Play();
        
            while (elapsedTime < _fadeTime)
            {
                var volDif = elapsedTime / _fadeTime;
                newSource.volume = volDif;
                oldSource.volume = 1 - volDif;
                elapsedTime += Time.deltaTime;

                yield return null;
            }
        
            oldSource.Stop();
            newSource.volume = 1;
        }

        public void MuteAll(bool mute = true)
        {
            foreach (var source in _sources)
            {
                source.mute = mute;
            }
        }
    }
}
