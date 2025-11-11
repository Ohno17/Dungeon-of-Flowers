using UnityEngine;

public class GridMover : MonoBehaviour
{
    public float lerpSpeed = 15f;
    public Grid grid;
    [HideInInspector] public Vector3Int gridPosition;
    
    [SerializeField] private Vector3 offset;
    private Vector3 targetWorldPosition;

    void Start()
    {
        gridPosition = grid.WorldToCell(transform.position);
        targetWorldPosition = grid.GetCellCenterWorld(gridPosition);
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
        targetWorldPosition = grid.GetCellCenterWorld(position) + offset;
    }

    public void SetPositionAtomic(Vector3Int position)
    {
        targetWorldPosition = grid.GetCellCenterWorld(position) + offset;
        transform.position = targetWorldPosition;
    }
}
