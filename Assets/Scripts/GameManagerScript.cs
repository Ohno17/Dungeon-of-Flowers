using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonOfFlowers
{
    public class GameManagerScript : MonoBehaviour
    {
        [HideInInspector] public int flowers = 0;
        [HideInInspector] public Vector2Int roomPosition;

        [SerializeField] private GameObject player;
        [SerializeField] private GridMoverScript cameraMover;
        [SerializeField] private Grid roomGrid;

        // Start is called before the first frame update
        void Start()
        {
            roomPosition = new(0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            Vector2Int newRoomPosition = (Vector2Int) roomGrid.WorldToCell(player.transform.position);
            if (newRoomPosition != roomPosition)
            {
                cameraMover.Move((Vector3Int) (newRoomPosition - roomPosition));
                roomPosition = newRoomPosition;
            }
        }
    }
}