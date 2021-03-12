using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sire
{
    public class CameraController : MonoBehaviour
    {
        public float speed = 20.0f;
        public int maxZoom = 30;
        private readonly int minZoom = 3;

        //drag
        public float dragSpeed = 5f;
        public Vector3 prevPos;

        //SIGN writing
        public bool canMove = false;

        public static CameraController Instance {get; private set;}
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(this);
        }

        void Update()
        {
            if(!canMove) return;

            //WASD moving
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0.0f);

            //Drag middle mouse button moving
            if (Input.GetKey(KeyCode.Mouse2)){
                Vector3 dragPanning = Camera.main.ScreenToWorldPoint(prevPos) - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position += dragPanning;
            }
            prevPos = Input.mousePosition;

            //Zooming
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && GetComponent<Camera>().orthographicSize > minZoom) // forward
            {
                GetComponent<Camera>().orthographicSize--;
                speed--;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && GetComponent<Camera>().orthographicSize < maxZoom) // backwards
            {
                GetComponent<Camera>().orthographicSize++;
                speed++;
            }
        }
    }
}