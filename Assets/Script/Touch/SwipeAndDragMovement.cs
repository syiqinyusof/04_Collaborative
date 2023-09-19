using UnityEngine;

public class SwipeAndDragMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isDragging = false;
    private float dragSpeed = 5f;
    private float swipeDistanceThreshold = 50f;

    void Update()
    {
        HandleSwipeMovement();
        HandleDragMovement();
    }

    void HandleSwipeMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endPosition = touch.position;
                float swipeDistance = Vector3.Distance(startPosition, endPosition);

                if (swipeDistance > swipeDistanceThreshold)
                {
                    // Determine swipe direction
                    Vector3 swipeDirection = endPosition - startPosition;
                    float horizontalSwipe = Mathf.Sign(swipeDirection.x);

                    // Move the object
                    MoveObject(horizontalSwipe);
                }
            }
        }
    }

    void HandleDragMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        isDragging = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                transform.position = Vector3.Lerp(transform.position, touchPosition, dragSpeed * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }

    void MoveObject(float direction)
    {
        Vector3 movement = new Vector3(direction, 0f, 0f) * dragSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
