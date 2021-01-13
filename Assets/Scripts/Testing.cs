using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private 
    PathFinding pathfinding;
    private MyGrid<bool> grid,grid2,grid3;
    // Start is called before the first frame update
    void Start()
    {
        //grid = new MyGrid<bool>(25, 12, 6f, new Vector3(0,0,0));
        pathfinding = new PathFinding(10, 10);
        //grid2 = new MyGrid(2, 5, 5f, new Vector3(0, 0, -20));
        //grid3 = new MyGrid(2, 5, 20f, new Vector3(-100, 0, -20));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 tmp = ray.GetPoint(distance);
                pathfinding.GetGrid().GetXZ(tmp, out int x, out int z);
                List<PathNode> path = pathfinding.FindPath(0, 0, x, z);
                if(path != null)
                {
                    for(int i=0; i<path.Count -1;i++)
                    {
                        Debug.DrawLine(new Vector3(path[i].x,0, path[i].z) * 10f + new Vector3(1,0,1) * 5f, new Vector3(path[i+1].x, 0,path[i+1].z) * 10f + new Vector3(1,0,1) * 5f, Color.green,100f);
                        Debug.Log($"{path[i].x},{path[i].z}");
                    }
                }
               //grid.SetValue(tmp, true);
                //grid2.SetValue(tmp, 49);
                //grid3.SetValue(tmp, 67);

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 tmp = ray.GetPoint(distance);
                pathfinding.GetGrid().GetXZ(tmp, out int x, out int z);
                pathfinding.GetNode(x, z).SetIsWalkable(false);

                //Debug.Log(grid.GetValue(tmp));
                //Debug.Log(grid2.GetValue(tmp));
                //Debug.Log(grid3.GetValue(tmp));

            }
        }
    }
}
