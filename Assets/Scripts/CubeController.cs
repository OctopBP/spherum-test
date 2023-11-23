using UnityEngine;

namespace Spherum.Test
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] private KeyCode upKey, downKey, rightKey, leftKey;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Color color;

        private void Start()
        {
            GetComponent<MeshRenderer>().material.color = color;
        }

        void Update()
        {
            var moveVector = Vector3.zero;
            
            AddVectorIfKeyIsPressed(upKey, Vector3.forward);
            AddVectorIfKeyIsPressed(downKey, Vector3.back);
            AddVectorIfKeyIsPressed(rightKey, Vector3.right);
            AddVectorIfKeyIsPressed(leftKey, Vector3.left);

            transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;

            void AddVectorIfKeyIsPressed(KeyCode key, Vector3 direction)
            {
                if (Input.GetKey(key))
                {
                    moveVector += direction;
                }
            }
        }
    }
}