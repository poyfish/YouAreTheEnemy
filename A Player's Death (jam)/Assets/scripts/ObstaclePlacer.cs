using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    [SerializeField] LayerMask ground;

    private PlacePoint placePoint;
    private SpriteRenderer placePointSprite;

    public GameObject spike;

    public bool canPlaceObstacle = true;

    public GameObject ObstaclePlaceHolder;

    
    void Start()
    {
        placePoint = Instantiate(ObstaclePlaceHolder).GetComponent<PlacePoint>();
        placePoint.transform.position = new Vector3(200, 200);

        placePointSprite = placePoint.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, ground);

        if (Input.GetMouseButtonDown(0) && canPlaceObstacle && !placePoint.isInsideGround())
        {
            GameObject spikeObject = Instantiate(spike, placePoint.transform.position, Quaternion.identity);
            spikeObject.GetComponent<Obstacle>().OnReady += OnObstacleReady;

            canPlaceObstacle = false;
        }
        
        
        if (hit.collider != null)
        {
            Vector2 hitPoint = hit.point;
                    
            placePoint.transform.position = hitPoint;
            placePointSprite.enabled = true;
        }

        else
        {
            placePointSprite.enabled = false;
        }
    }

    void OnObstacleReady()
    {
        canPlaceObstacle = true;
    }
}
