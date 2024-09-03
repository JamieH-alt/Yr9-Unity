using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class TutorialChanger : MonoBehaviour
    {
        [SerializeField] private GameObject keyboard;
        [SerializeField] private GameObject gamepad;
        [SerializeField] private GameObject ps4;

        void Update()
        {
            if (InputManager.Device == 0)
            {
                gamepad.SetActive(false);
                ps4.SetActive(false);
                keyboard.SetActive(true);
            } else if (InputManager.Device == 1)
            {
                keyboard.SetActive(false);
                ps4.SetActive(true);
                gamepad.SetActive(false);
            }
            else
            {
                keyboard.SetActive(false);
                gamepad.SetActive(true);
                ps4.SetActive(false);
            }
        }
    }
}