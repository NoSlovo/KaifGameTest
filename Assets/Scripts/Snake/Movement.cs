using Interfaces.Service;
using UnityEngine;

namespace DefaultNamespace.Snake
{
    public class Movement
    {
        private Rigidbody _rb;
        private Transform _transform;
        private float _speed;
        private Vector3 _moveDirection = Vector3.forward;
        private Vector3 _ApAxis;

        public Movement(Rigidbody rb, Transform Transform, float speed)
        {
            _rb = rb;
            _transform = Transform;
            _speed = speed;
        }

        public void Move(Vector2 rotateDirection, Vector3 normal,Transform pointPlanet)
        {
           var direction = new Vector3(rotateDirection.x,0,rotateDirection.y);
            
            float speed = 1.0f;
            float angle = speed * Time.deltaTime;
            
            Vector3 gravityUp = (_transform.position - normal).normalized;
            
            _rb.AddForce(gravityUp * -50);
            _rb.rotation = Quaternion.FromToRotation(_transform.up, gravityUp) * _rb.rotation;
            _rb.AddForce(direction * (_speed * Time.deltaTime));
        }
    }
    
}