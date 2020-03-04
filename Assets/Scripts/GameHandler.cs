using UnityEngine;

public class GameHandler : MonoBehaviour
{
    LevelGrid levelGrid;

    void Start()
    {
        levelGrid = new LevelGrid(50, 50);
    }

}
