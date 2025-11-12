using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxController : MonoBehaviour
{
    public GridMover mover;

    private Tilemap tilemap;

    void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag(GameManager.TILEMAP_TAG).GetComponent<Tilemap>();
    }

    void Update()
    {

    }
    
    public bool TryMove(Vector3Int direction)
    {
        Vector3Int newPosition = mover.gridPosition + direction;

        // If a wall is in the way
        if (tilemap.GetColliderType(newPosition) != Tile.ColliderType.None) return false;

        // If another box is in the way
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameManager.BOX_TAG))
        {
            BoxController box = gameObject.GetComponent<BoxController>();
            if (box.mover.gridPosition == newPosition) return false;
        }

        // If box will leave room as a result of this
        if (GameManager.TileRoomPosition(mover.gridPosition) != GameManager.TileRoomPosition(newPosition)) return false;

        mover.Move(direction);
        return true;
    }
}
