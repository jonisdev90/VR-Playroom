using UnityEngine;

namespace System
{
    public class SoundServices: MonoBehaviour
    {
        [SerializeField] private AudioClip _click;
        [SerializeField] private AudioClip _error;
        [SerializeField] private AudioClip _fire;
        [SerializeField] private AudioClip _reload;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            EventsServices.Instance.OnPlaySound += PlaySound;
        }

        private void OnDisable()
        {
            EventsServices.Instance.OnPlaySound -= PlaySound;
        }

        private void PlaySound(SoundType soundType)
        {
            var audioClip = soundType switch
            {
                SoundType.Click => _click,
                SoundType.Error => _error,
                SoundType.Fire => _fire,
                SoundType.Reload => _reload,
                _ => throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null)
            };

            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }

    public enum SoundType
    {
        Click,
        Error,
        Fire,
        Reload
    }
}