using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class AudioSystem : MonoBehaviour
    {
        public static AudioSystem Instance;
        private void Awake()
        {
            Instance = this;
        }

        [SerializeField] private AudioSource m_audioSource;
        [SerializeField] private AudioClip m_waterDrop;
        [SerializeField] private AudioClip m_rockDrop;
        [SerializeField] private AudioClip m_wateringTree;
        [SerializeField] private AudioClip m_selectBtn;
        [SerializeField] private AudioClip m_deSelectBtn;

        private void Start()
        {
            m_audioSource.volume = SaveVarible.Instance.AudioVolume;
        }

        public void ChangeVolume(float volume)
        {
            m_audioSource.volume = volume;
        }
        public void WaterDrop()
        {
            m_audioSource.clip = m_waterDrop;
            m_audioSource.Play();
        }
        public void RockDrop()
        {
            m_audioSource.clip = m_rockDrop;
            m_audioSource.Play();
        }
        public void Watering()
        {
            m_audioSource.clip = m_wateringTree;
            m_audioSource.Play();
        }
        public void SelectBtn()
        {
            m_audioSource.clip = m_selectBtn;
            m_audioSource.Play();
        }
        public void DeselectBtn()
        {
            m_audioSource.clip = m_deSelectBtn;
            m_audioSource.Play();
        }

    }
}