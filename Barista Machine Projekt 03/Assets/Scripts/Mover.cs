using UnityEngine;

namespace haw.unitytutorium.s23
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        private Vector3 startPos;
        
        private void Start()
        {
            startPos = transform.position;
        }

        private void Update()
        {
            // Move();
            // MoveWithInput();
        }

        /// <summary>
        /// Moves an object along the global x-axis between 6 and -6.
        /// Caches the starting position in a variable and calculates the min and max extends (-6 and 6) relative to this starting position.
        /// </summary>
        private void Move()
        {
            transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
            if (transform.position.x >= startPos.x + 6 || transform.position.x <= startPos.x -6)
                moveSpeed *= -1;
        }
        
        // INPUT
        private void MoveWithInput()
        {
            var axisVal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * (axisVal * moveSpeed * Time.deltaTime), Space.World); 
            // Time.deltaTime makes the object move independent from the framerate since it scales our true moveSpeed with the time interval from the last frame to the current frame.
        }
        
        // REFERENCE
        // Can be called by any script that references the Mover component.
        public void MoveWithExternalInput(float axisVal)
        {
            transform.Translate(Vector3.right * (axisVal * moveSpeed * Time.deltaTime), Space.World);
        }
    }
}