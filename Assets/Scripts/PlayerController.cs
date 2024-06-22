using UnityEngine;

namespace BTOTT
{
    public class PlayerController : MonoBehaviour
    {

        private Animator ani;
        private string parRun = "Run";

        public float speed = 5.6f;
        public Rigidbody2D rb;
        public float xVelocity;//这个变量主要来存储GetAxis或GetAxisRaw获取的值
        public float jumpForce;
        public float fallMultiplier;//空中降落的速度
        public float lowJumpMultiplier;//跳跃高度的限制级别（数值越大跳的越矮）
        public bool pressJump;
        public int jumpNum;//一共能跳几次
        public int jumpRemainNum;//还能跳几次
        public bool isOnGround;//是否在地面上
        public float groundDistance = 0.2f;//射线的长度
        public float footOffset = 0.4f;//两条射线的距离
        public float rayPositionY = -0.5f;//射线的Y轴
        public LayerMask groundLayer;
        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

            pressJump = Input.GetButton("Jump");
            Jump();
        }
        void FixedUpdate()
        {
            PhysicsCheck();
            GroundMovement();
        }
        public void GroundMovement()
        {
            xVelocity = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);


            if (Input.GetButtonDown("Horizontal"))
            {


                if (Input.GetKeyDown(KeyCode.D) || xVelocity > 0)
                    transform.eulerAngles = Vector3.zero;
                if (Input.GetKeyDown(KeyCode.A) || xVelocity < 0)
                    transform.eulerAngles = new Vector3(0, 180, 0);

            }
            ani.SetBool(parRun, xVelocity != 0);
            print(parRun);
        }
        void PhysicsCheck()
        {
            RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, rayPositionY), Vector2.down, groundDistance, groundLayer);
            RaycastHit2D RightCheck = Raycast(new Vector2(footOffset, rayPositionY), Vector2.down, groundDistance, groundLayer);
            if (leftCheck || RightCheck)
            {
                isOnGround = true;
                
            }
            else
            {
                isOnGround = false;
                
            }
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (isOnGround)
                {

                    jumpRemainNum = jumpNum;
                }
                if (pressJump && jumpRemainNum-- > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;

            }
            else if (rb.velocity.y > 0 && !pressJump)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;

            }
        }
        RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
        {

            Vector2 pos = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);

            Color color = hit ? Color.red : Color.green;

            Debug.DrawRay(pos + offset, rayDirection * length, color);
            return hit;
        }
    }


}