using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    [SerializeField] LayerMask ground;

    private PlacePoint placePoint;
    private SpriteRenderer placePointSprite;

    public GameObject obstacle;

    public bool canPlaceObstacle = true;

    public GameObject ObstaclePlaceHolder;

    [SerializeField] bool didSpwanPacePoint;
    
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, ground);

        if (Input.GetMouseButtonDown(0) && didSpwanPacePoint == false)
        {
            didSpwanPacePoint = true;

            placePoint = Instantiate(ObstaclePlaceHolder).GetComponent<PlacePoint>();
            placePointSprite = placePoint.GetComponent<SpriteRenderer>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            if (canPlaceObstacle && !placePoint.isInsideGround())
            {
                GameObject spikeObject = Instantiate(obstacle, placePoint.transform.position, Quaternion.identity);
                spikeObject.GetComponent<Obstacle>().OnReady += OnObstacleReady;

                canPlaceObstacle = false;

                
            }
            
        }

        if (hit.collider != null && placePoint != null)
        {
            Vector2 hitPoint = hit.point;
                    
            placePoint.transform.position = hitPoint;
            placePointSprite.enabled = true;
        }
        else
        {
            Destroy(placePoint);
        }
    }

    void OnObstacleReady()
    {
        canPlaceObstacle = true;
    }
}
