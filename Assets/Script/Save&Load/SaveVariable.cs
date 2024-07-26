using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class SaveVarible : MonoBehaviour
    {
        #region Singleton
        public static SaveVarible Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<SaveVarible>();
                    if (m_instance == null)
                    {
                        m_instance = new GameObject("AudioSystem").AddComponent<SaveVarible>();
                    }
                }
                return m_instance;
            }
        }

        private static SaveVarible m_instance;
        private bool m_isCreate = false;
        void Awake()
        {
            string path = Application.persistentDataPath + "/Player.Data";
            if (!File.Exists(path))
            {
                SavePlayer();
            }
            if (m_instance != null && m_instance != this)
            {
                Destroy(this);
                return;
            }
            if (!m_isCreate)
            {
                DontDestroyOnLoad(this.gameObject);
                m_isCreate = true;
            }

            m_instance = this;
        }
        #endregion

        //Variabel Global
        public int WaterTree = 0;
        public float AudioVolume = 1;

        private void Start()
        {
            //SavePlayer();
            LoadPlayer();
        }


        public void SavePlayer()
        {
            SaveSystems.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            SaveVaribleData data = SaveSystems.LoadPlayer();
            WaterTree = data.WaterTree;
            AudioVolume = data.AudioVolume;
        }

    }
}