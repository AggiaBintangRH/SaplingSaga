using TMPro;
using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class UIGameplay : MonoBehaviour
    {
        public static UIGameplay Instance { get; set; }
        private void Awake()
        {
            Instance = this;
        }
        [Header("UI")]
        [SerializeField] private GameObject m_HUD;
        [SerializeField] private GameObject m_GrowTree;
        [SerializeField] private GameObject m_Paused;
        public GameObject GrowTree
        {
            get => m_GrowTree;
            set => m_GrowTree = value;
        }


        [Header("Timer")]
        [SerializeField] private float timeStart = 100f;
        [SerializeField] private TMP_Text m_timerText;

        [Header("Water")]
        [SerializeField] private TMP_Text m_waterText;
        private void Start()
        {
            m_HUD.SetActive(true);
            m_Paused.SetActive(true);
            m_GrowTree.SetActive(false);
        }
        void Update()
        {
            if (GameplayManager.Instance.CanMove)
                timeStart -= Time.deltaTime;

            UpdateTimer();
            UpdateWater();
            CheckTimer();
        }

        public void UpdateTimer()
        {
            float seconds = Mathf.FloorToInt(timeStart % 60);
            float minute = Mathf.FloorToInt(timeStart / 60);

            m_timerText.text = minute.ToString("00") + ":" + Mathf.RoundToInt(seconds).ToString("00");
        }

        private void UpdateWater()
        {
            m_waterText.text = GameplayManager.Instance.WaterQty.ToString();
        }

        private void CheckTimer()
        {
            if (timeStart <= 0)
            {
                timeStart = 0;
                GameplayManager.Instance.CanMove = false;
                m_HUD.SetActive(false);
                m_Paused.SetActive(false);
            }
        }
    }
}