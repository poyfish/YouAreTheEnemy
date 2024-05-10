using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    [SerializeField] LayerMask ground;

    private PlacePoint placePoint;

    public GameObject obstacle;

    public bool canPlaceObstacle = true;

    public GameObject ObstaclePlaceHolder;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        if (!canPlaceObstacle) return;

        if (Input.GetMouseButtonDown(0) && canPlaceObstacle)
        {
            placePoint = Instantiate(ObstaclePlaceHolder).GetComponent<PlacePoint>();
        }

        if(Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, ground);

            if (hit.collider != null && placePoint != null)
            {
                Vector2 hitPoint = hit.point;

                placePoint.transform.position = hitPoint;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (canPlaceObstacle && !placePoint.isInsideGround())
            {
                GameObject spikeObject = Instantiate(obstacle, placePoint.transform.position, Quaternion.identity);
                spikeObject.GetComponent<Obstacle>().OnReady += OnObstacleReady;

                canPlaceObstacle = false;

                Debug.Log(placePoint.name, placePoint);

                Destroy(placePoint.gameObject);
            }
            
        }
    }

    void OnObstacleReady()
    {
        canPlaceObstacle = true;
    }
}
