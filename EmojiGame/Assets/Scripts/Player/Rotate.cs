using UnityEngine;

public class Rotate : MonoBehaviour
{
    // PlayerMovement script
    public PlayerMovement player;
    
    // Wall
    private float distanceToWall;
    public LayerMask wallLayerMask;

    public Vector3 skinWidth = new Vector3 (0.5f, 0, 0);

    // Roatation
    private float rotateSpeed = 4;
    public SpriteMask skin;


    void FixedUpdate()
    {
        DistanceToWall();
        SkinRotate();
    }

    void SkinRotate()
    {
        if (distanceToWall > 0.15f)
        {
            player.playerRb.freezeRotation = false;
            skin.transform.Rotate(0,0,rotateSpeed * player.gravityDirection);
        }
        else
        {
            player.playerRb.freezeRotation = true;
        }                    
    }

    void DistanceToWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + (skinWidth * player.gravityDirection), Vector3.right * player.gravityDirection, out hit, Mathf.Infinity, wallLayerMask))
        {
            Debug.Log(hit.collider);
            if (hit.distance != distanceToWall)
            {
                distanceToWall = hit.distance;
            }
        }
    }
}
