
using UnityEngine;

namespace BTOTT
{

    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 500)]
        private float moveSpeed = 3.5f;

        private Rigidbody2D rig;

        private Animator ani;
        private string parRun = "Run";

        //public Transform player;

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        //private void LateUpdate()
        //{
        //    transform.position = player.position;
        //}

        private void Update()
        {
            MoveAndFlip();
        }

        private void MoveAndFlip()
        {
            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);

            if (Input.GetKeyDown(KeyCode.A))
            {
                print("按下 A");
                transform.eulerAngles = Vector3.zero;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                print("按下 D");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            ani.SetBool(parRun, h != 0);
        }
    }
}

