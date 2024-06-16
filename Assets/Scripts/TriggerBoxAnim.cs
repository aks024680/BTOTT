
using UnityEngine;

namespace BTOTT
{
    public class TriggerBoxAnim : MonoBehaviour
    {
        public GameObject animationObject;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Animator ani = animationObject.GetComponent<Animator>();
                if (ani != null)
                {
                    ani.SetTrigger("Idle");
                    print(ani);
                }
            }
        }
    }

}

