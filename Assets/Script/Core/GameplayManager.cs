using UnityEngine;

namespace AggiaCreation.SaplingSaga
{
    public class GameplayManager : MonoBehaviour
    {
        #region Singleton
        public static GameplayManager Instance { get; set; }
        private void Awake()
        {
            Instance = this;
        }
        #endregion

        public int WaterQty { get; set; }
        public bool CanMove { get; set; }

        private void Start()
        {
            Time.timeScale = 1;
            CanMove = true;
        }
        private void Update()
        {
            if (WaterQty <= 0)
            {
                WaterQty = 0;
            }
        }
    }
}