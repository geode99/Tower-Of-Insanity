using UnityEngine;

public class GridSnap : MonoBehaviour
{
    // Assign in Inspector or let Start find the Grid named "LevelGrid".
    public Grid grid;

    // If true the object will be snapped every frame. If false you can call ForceSnap() manually.
    public bool snapEveryFrame = true;

    // Snap once on Start if true.
    public bool snapOnStart = true;

    void Start()
    {
        if (grid == null)
        {
            var go = GameObject.Find("LevelGrid");
            grid = go.GetComponent<Grid>();
        }

        if (snapOnStart)
        {
            ForceSnap();
        }
    }

    void Update()
    {
        if (snapEveryFrame)
        {
            ForceSnap();
        }
    }

    // Forces the obje  ct's center to the center of the nearest grid cell (world-space).
    public void ForceSnap()
    {
        Vector3Int cell = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cell);
    }
}
