using UnityEngine;


namespace Sample.SpaceInvaders
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-3 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(3 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
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
