using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.Playables;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Boundary
    {
        public float xMin, zMin, xMax, zMax;
    }

    public class PlayerController : MonoBehaviour
    {   
        public float speed;
        public Rigidbody rb;
        public Boundary Boundary;
        public float tilt;

        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;

        public float nextFire;
        public AudioSource audio;

        void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = fireRate + Time.time;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                audio.Play();
            }
        }
        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.velocity = movement * speed;
            rb.position = new Vector3
                (
                    Mathf.Clamp(rb.position.x, Boundary.xMin, Boundary.xMax), 
                    0.0f, 
                    Mathf.Clamp(rb.position.z, Boundary.zMin, Boundary.zMax)
                );

            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }

        
    }
}
