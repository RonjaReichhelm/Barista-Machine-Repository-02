using UnityEngine;

namespace haw.unitytutorium.s23
{
    public class Rotator : MonoBehaviour
    {
        // [SerializeField] private float degreePerFrame;
        [SerializeField] private float rpm;

        public float RPM => rpm;
        
        private void Update()
        {
            // Input is managed by the InputHandler
            // if (Input.GetKey(KeyCode.Space))
            // {
            //     Rotate();
            // }
        }
        
        // private void Update() => Rotate();

        public void Rotate()
        {
            // if we just wanted to rotate an object and didn't care about accurate rotation speed
            // we could simply rotate the object by any amount of degree per frame
            //
            // transform.Rotate(Vector3.up, degreePerFrame);
            
            // 360 Degrees / 60s => 6 Degree per Second = 1 rpm
            transform.Rotate(Vector3.up, rpm * 6f * Time.deltaTime); 
        }

        public void SetRpm(float rpm)
        {
            this.rpm = rpm;
        }
    }
}