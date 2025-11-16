using UnityEngine;
using UnityEngine.InputSystem;


namespace Sample.SpaceInvaders
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                transform.Translate(-3 * Time.deltaTime, 0, 0);
            }
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                transform.Translate(3 * Time.deltaTime, 0, 0);
            }
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                var missile = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                missile.transform.position = transform.position + new Vector3(0, 1, 0);
                missile.transform.localScale *= 0.1F;
                missile.name = "PlayerMissile";

                var r = missile.AddComponent<Rigidbody>();
                r.useGravity = false;
                r.linearVelocity = new(0, 10, 0);
                Destroy(missile, 3);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Debug.Break();
        }
    }
}
