
using UnityEngine;

namespace BTOTT
{
    public class TriggerBoxAnim : MonoBehaviour
    {
        public GameObject KeyE;
        public GameObject animationObject;

        private void Start()
        {
            KeyE.SetActive(false);
        }

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
                
                KeyE.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                
                KeyE.SetActive(false);
            }
        }
    }

}

