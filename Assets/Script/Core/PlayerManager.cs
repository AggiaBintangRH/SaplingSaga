using UnityEngine;
namespace AggiaCreation.SaplingSaga
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private float m_rotationSpeed;
        private float m_inputPlayer;
        private Rigidbody m_rb;
        private Animator m_animPlayer;

        private Vector2 touchStartPos;
        private Vector2 touchEndPos;
        void Start()
        {
            m_rb = GetComponent<Rigidbody>();
            m_animPlayer = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            // Get input from the horizontal axis (A/D keys or Left/Right arrow keys)
            //m_inputPlayer = Input.GetAxis("Horizontal");


            if (GameplayManager.Instance.CanMove)
            {
                GetTouchInput();
                Rotate();
            }
            else
                AnimWalk(false);
        }

        private void FixedUpdate()
        {
            if (!GameplayManager.Instance.CanMove)
                return;

            MovePlayer();
        }
        private void MovePlayer()
        {
            Vector3 movement = new Vector3(m_inputPlayer, 0.0f, 0.0f);
            m_rb.velocity = movement * m_moveSpeed;

            if (m_inputPlayer != 0)
                AnimWalk(true);
            else
                AnimWalk(false);
        }
        private void Rotate()
        {
            Quaternion targetRotation;

            if (m_inputPlayer > 0)
                targetRotation = Quaternion.Euler(0, 90, 0);
            else if (m_inputPlayer < 0)
                targetRotation = Quaternion.Euler(0, 270, 0);
            else
                return;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_rotationSpeed);
        }

        private void AnimWalk(bool status)
        {
            m_animPlayer.SetBool("isWalking", status);
        }

        private void GetTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    touchEndPos = touch.position;
                    Vector2 touchValue = touchEndPos - touchStartPos;
                    if (Mathf.Abs(touchValue.x) > Mathf.Abs(touchValue.y))
                    {
                        if (touchValue.x > 0)
                            m_inputPlayer = 1; // Swipe right
                        else
                            m_inputPlayer = -1; // Swipe left\

                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    m_inputPlayer = 0; // Reset input when touch ends
                }
            }
            else
            {
                m_inputPlayer = 0; // Reset input if no touch
            }
        }
    }
}