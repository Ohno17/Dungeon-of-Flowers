using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxController : MonoBehaviour
{
    public GridMover mover;
    [HideInInspector] public Vector3Int initalPosition;

    private Tilemap tilemap;

    void Start()
    {
        initalPosition = mover.gridPosition;
        tilemap = GameObject.FindGameObjectWithTag(GameManager.TILEMAP_TAG).GetComponent<Tilemap>();
    }

    void Update()
    {

    }

    public void ResetPosition()
    {
        mover.SetPositionAtomic(initalPosition);
    }
    
    public bool TryMove(Vector3Int direction)
    {
        Vector3Int newPosition = mover.gridPosition + direction;
        if (tilemap.GetColliderType(newPosition) != Tile.ColliderType.None) return false;

        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameManager.BOX_TAG))
        {
            BoxController box = gameObject.GetComponent<BoxController>();
            if (box.mover.gridPosition == newPosition) return false;
        }

        mover.Move(direction);
        return true;
    }
}
