
using UnityEngine;

namespace BTOTT
{

    public class ControlSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("移動速度"), Range(0, 500)]
        private float moveSpeed = 3.5f;

        private Rigidbody2D rig;

        private Animator ani;
        private string parRun = "Run";

        //public Transform player;

        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        [SerializeField, Header("要偵測地板的圖層")]
        private LayerMask layerCheckGround;

        [SerializeField, Header("跳躍力道"), Range(0, 3000)]
        private float jumpPower = 200;

       

        #endregion

        #region 事件
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
        }

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
            //CheckGround();
            Jump();
        }
        #endregion

        #region 方法
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

        
       

        private void Jump()
        {
            if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector2(0, jumpPower));
            }
        }

        private bool CheckGround()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0,layerCheckGround);
            print($"<color=#69f>碰到的物件&#xff1a;{hit.name}</color>");
            return hit;
        }


        #endregion
    }
}

