using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class TreeSystem : MonoBehaviour
    {
        public static TreeSystem Instance { get; set; }
        private void Awake()
        {
            Instance = this;
        }
        [SerializeField] private GameObject m_deadTree;
        [SerializeField] private GameObject m_greenTree;
        [SerializeField] private GameObject m_fruitTree;

        public int WaterQty { get; set; }

        private void Start()
        {
            WaterQty = SaveVarible.Instance.WaterTree;
            m_deadTree.SetActive(true);
            m_greenTree.SetActive(false);
            m_fruitTree.SetActive(false);
        }
        private void Update()
        {
            WaterQty = SaveVarible.Instance.WaterTree;

            if (WaterQty >= 8 && WaterQty <= 14)
            {
                m_deadTree.SetActive(false);
                m_greenTree.SetActive(true);
                m_fruitTree.SetActive(false);
            }
            else if (WaterQty >= 15)
            {
                m_deadTree.SetActive(false);
                m_greenTree.SetActive(false);
                m_fruitTree.SetActive(true);
            }
        }
    }
}