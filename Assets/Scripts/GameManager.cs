using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonOfFlowers
{
    public class GameManager : MonoBehaviour
    {
        public const int ROOM_WIDTH = 18;
        public const int ROOM_HEIGHT = 10;
        [HideInInspector] public int flowers = 0;
        [HideInInspector] public Vector3Int roomPosition;

        [SerializeField] private GridMover playerMover;
        [SerializeField] private GridMover cameraMover;

        // Start is called before the first frame update
        void Start()
        {
            roomPosition = new(0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            int roomX = Mathf.FloorToInt((float) (playerMover.gridPosition.x + (ROOM_WIDTH / 2)) / ROOM_WIDTH);
            int roomY = Mathf.FloorToInt((float) (playerMover.gridPosition.y + (ROOM_HEIGHT / 2)) / ROOM_HEIGHT);
            roomPosition = new(roomX, roomY);

            cameraMover.SetPosition(roomPosition * new Vector3Int(ROOM_WIDTH, ROOM_HEIGHT));
        }
    }
}