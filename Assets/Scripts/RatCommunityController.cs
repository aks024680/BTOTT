
using Unity.VisualScripting;
using UnityEngine;

namespace BTOTT
{
    public class RatCommunityController : MonoBehaviour
    {
        public GameObject MapIcon;
        public GameObject animationObject; // 需要播放动画的对象
        private void Update()
        {
            if (MapIcon.IsDestroyed())
            {
                // 触发动画
                Animator animator = animationObject.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("GetMap");
                }
            }
        }
    }

}

