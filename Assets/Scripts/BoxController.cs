using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GridMover mover;
    [SerializeField] private Tilemap tilemap;
    private Vector3Int resetPosition;

    void Start()
    {
        resetPosition = mover.gridPosition;
    }

    void Update()
    {
        
    }

    public void TryMove(Vector3Int direction)
    {
        if (tilemap.GetColliderType(mover.gridPosition + direction) != Tile.ColliderType.None) return;
        mover.Move(direction);
    }
}
