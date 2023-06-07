using UnityEngine;

namespace haw.unitytutorium.s23
{
    public class Resizer : MonoBehaviour
    {
        [SerializeField] private KeyCode resizeKey;
        [SerializeField] private Vector3 targetScale;
        private Vector3 startScale;
        
        private bool toogled;
        
        private void Start()
        {
            startScale = transform.localScale;
        }

        private void Update()
        {
            // Input is managed by the InputHandler
            // if (Input.GetKeyDown(resizeKey))
            // {
            //     ToggleResize();
            // }
        }

        public void ToggleResize()
        {
            transform.localScale = toogled ? startScale : targetScale;
            toogled = !toogled;
        }
    }
}