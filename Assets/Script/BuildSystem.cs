using UnityEditor;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public GameObject bridge;
    public GameObject cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            build(bridge);
        }
    }
    public void build(GameObject block)
    {
        int layermask = LayerMask.GetMask("land");
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, layermask))
        {
            Vector3 contactPoint = hit.point;
            int roundedX = Mathf.RoundToInt(contactPoint.x);
            int roundedZ = Mathf.RoundToInt(contactPoint.z);
            Instantiate(block, new Vector3(roundedX, 1.28f, roundedZ), Quaternion.identity);
        }
    }
}
