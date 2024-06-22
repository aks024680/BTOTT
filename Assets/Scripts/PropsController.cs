
using Fungus;
using UnityEngine;

namespace BTOTT
{

public class PropsController : MonoBehaviour
{
        [SerializeField]
        GameObject SwitchPanel;

        bool a = false;

        private void Update()
        {
            if (a && Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
            {
                SwitchPanel.SetActive(false);
                a = false;
            }
            
            else if (Input.GetKeyDown(KeyCode.I))
            {
                SwitchPanel.SetActive(true);
                a = true;
            }
        }
    }

}

