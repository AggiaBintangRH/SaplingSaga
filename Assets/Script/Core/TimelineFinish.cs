using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class TimelineFinish : MonoBehaviour
    {
        [SerializeField] private GameObject m_boundary;
        [SerializeField] private CameraFollow m_cameraFollow;
        private PlayerManager m_playerManager;
        private Animator m_animPlayer;
        private Rigidbody m_rb;
        void Start()
        {
            m_cameraFollow.enabled = false;
            m_animPlayer = GetComponentInChildren<Animator>();
            m_rb = GetComponent<Rigidbody>();
            m_playerManager = GetComponent<PlayerManager>();
            m_animPlayer.SetLayerWeight(1, 1);
        }

        private void Update()
        {
            if (!GameplayManager.Instance.CanMove)
            {
                m_boundary.SetActive(false);
                m_playerManager.enabled = false;
                MoveToTree();
            }
        }

        private void MoveToTree()
        {
            float targetX = 8.5f;
            Vector3 movement = new(1, 0.0f, 0.0f);
            Vector3 currentTransfrom = transform.position;
            if (currentTransfrom.x < targetX)
            {
                Rotate();
                m_rb.velocity = movement * 2;
                AnimWalk(true);
            }
            else
            {
                AnimWalk(false);
                AnimWatering(true);
                m_animPlayer.SetLayerWeight(1, 0);
                StartCoroutine(GrowTree());
            }
        }

        private void AnimWalk(bool status)
        {
            m_animPlayer.SetBool("isWalking", status);
        }
        private void AnimWatering(bool status)
        {
            m_animPlayer.SetBool("isWatering", status);
        }


        private void Rotate()
        {
            Quaternion targetRotation;

            targetRotation = Quaternion.Euler(0, 90, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
            StartCoroutine(EnableCamera());
        }
        IEnumerator EnableCamera()
        {
            yield return new WaitForSeconds(.2f);
            m_cameraFollow.enabled = true;
            yield return null;
        }
        private IEnumerator GrowTree()
        {
            yield return new WaitForSeconds(1.5f);
            if (SaveVarible.Instance.WaterTree > 15)
            {
                SaveVarible.Instance.WaterTree = 15;
            }
            yield return new WaitForSeconds(4f);
            UIGameplay.Instance.GrowTree.SetActive(true);
            Time.timeScale = 0;
            yield return null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Watering"))
            {
                StartCoroutine(Watering(other.gameObject));
            }
        }

        IEnumerator Watering(GameObject gameObject)
        {
            yield return new WaitForSeconds(1f);
            SaveVarible.Instance.WaterTree += GameplayManager.Instance.WaterQty;
            AudioSystem.Instance.Watering();
            gameObject.SetActive(false);
            yield return null;
        }
    }
}