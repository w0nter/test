using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Transform HandTransform;
    public float PickupRange = 3f;
    public float PickupSpeed = 5f;
    private GameObject pickedObject;
    public LayerMask wallLayer;
    public Button dropButton;

    void Start()
    {
        dropButton.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector2 touchPosition;

        #if UNITY_EDITOR
        touchPosition = (Vector2)Input.mousePosition;
        #else
        touchPosition = Input.GetTouch(0).position;
        #endif

        InteractWithObject(touchPosition);
        
        if (pickedObject != null)
        {
            pickedObject.transform.position = Vector3.Lerp(pickedObject.transform.position, HandTransform.position, PickupSpeed * Time.deltaTime);
            pickedObject.transform.rotation = Quaternion.Lerp(pickedObject.transform.rotation, HandTransform.rotation, PickupSpeed * Time.deltaTime);
        }
    }

    void InteractWithObject(Vector2 touchPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
    

        if (Physics.Raycast(ray, out hit, PickupRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                if (pickedObject == null)
                {
                    dropButton.gameObject.SetActive(true);

                    pickedObject = hit.collider.gameObject;
                    pickedObject.GetComponent<Collider>().enabled = false;
                    pickedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    public void DropObject()
    {
        if (pickedObject != null)
        {
            RaycastHit hitForward, hitLeft, hitRight;
            bool isWallInFront = Physics.Raycast(transform.position, transform.forward, out hitForward, 4f, wallLayer);
            bool isWallOnLeft = Physics.Raycast(transform.position, -transform.right, out hitLeft, 4f, wallLayer);
            bool isWallOnRight = Physics.Raycast(transform.position, transform.right, out hitRight, 4f, wallLayer);

            if (isWallInFront || isWallOnLeft || isWallOnRight)
            {
                pickedObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                Debug.Log("Стена");
            }

            pickedObject.GetComponent<Collider>().enabled = true;
            pickedObject.GetComponent<Rigidbody>().isKinematic = false;
            pickedObject = null;
            
            dropButton.gameObject.SetActive(false);
        }
    }
}
