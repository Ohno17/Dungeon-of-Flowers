using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMover : MonoBehaviour
{
    public Grid grid;
    [HideInInspector] public Vector3Int gridPosition;
    [HideInInspector] public Vector3Int initalPosition;
    
    [SerializeField] private float lerpSpeed = 15f;
    [SerializeField] private Vector3 offset;
    private Vector3 targetWorldPosition;

    void Awake()
    {
        if (grid == null) grid = GameObject.FindGameObjectWithTag(GameManager.TILEMAP_TAG).GetComponent<Tilemap>().layoutGrid;

        gridPosition = grid.WorldToCell(transform.position);
        targetWorldPosition = grid.GetCellCenterWorld(gridPosition);
        initalPosition = gridPosition;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetWorldPosition, lerpSpeed * Time.deltaTime);
    }

    public void Move(Vector3Int direction)
    {
        gridPosition += direction;
        targetWorldPosition = grid.GetCellCenterWorld(gridPosition) + offset;
    }

    public void SetPosition(Vector3Int position)
    {
        gridPosition = position;
        targetWorldPosition = grid.GetCellCenterWorld(position) + offset;
    }

    public void SetPositionAtomic(Vector3Int position)
    {
        gridPosition = position;
        targetWorldPosition = grid.GetCellCenterWorld(position) + offset;
        transform.position = targetWorldPosition;
    }

    public void ResetPosition()
    {
        SetPositionAtomic(initalPosition);
    }
}
