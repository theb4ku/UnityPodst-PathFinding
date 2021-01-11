using UnityEngine;

public class Testing : MonoBehaviour
{
    private MyGrid grid,grid2,grid3;
    // Start is called before the first frame update
    void Start()
    {
        grid = new MyGrid(4, 2, 10f, new Vector3(20,0,0));
        grid2 = new MyGrid(2, 5, 5f, new Vector3(0, 0, -20));
        grid3 = new MyGrid(2, 5, 20f, new Vector3(-100, 0, -20));
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
                grid.SetValue(tmp, 69);
                grid2.SetValue(tmp, 49);
                grid3.SetValue(tmp, 67);

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 tmp = ray.GetPoint(distance);
                Debug.Log(grid.GetValue(tmp));
                Debug.Log(grid2.GetValue(tmp));
                Debug.Log(grid3.GetValue(tmp));

            }
        }
    }
}
