using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform m_targetHolding; // The target object to follow
        [SerializeField] private Transform m_targetWatering; // The target object to follow
        private Transform m_target;

        private void Start()
        {
            m_target = m_targetHolding;
        }
        void Update()
        {
            UpdateMovement();
        }
        public void UpdateMovement()
        {
            transform.position = m_target.position;
            transform.rotation = m_target.rotation;
        }
        public void SetTarget(Transform target)
        {
            m_target = target;
        }
    }
}