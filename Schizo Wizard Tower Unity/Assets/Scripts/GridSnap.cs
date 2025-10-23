using UnityEngine;

public class GridSnap : MonoBehaviour
{
    // Assign in Inspector or let Start find the first Grid in loaded scenes.
    public Grid grid;

    // If true the object will be snapped every frame. If false you can call ForceSnap() manually.
    public bool snapEveryFrame = true;

    // Snap once on Start if true.
    public bool snapOnStart = true;

    void Start(){
        if (grid == null){
            grid = Grid.FindFirstObjectByType<Grid>();
            Debug.LogWarning("Grid not found for GridSnap on " + name);
            return;
        }

        if (snapOnStart){
            ForceSnap();
        }
    }

    void Update(){
        if (snapEveryFrame){
            ForceSnap();
        }
    }

    // Forces the object's center to the center of the nearest grid cell (world-space).
    public void ForceSnap()
    {
        if (grid == null) { 
            return;
        }
        
        Vector3Int cell = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cell);
    }
}
