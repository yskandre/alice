using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class TileLabeler : MonoBehaviour
{
    Vector2Int coords = new Vector2Int();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            UpdateCoordinates();
        }
    }

    void UpdateCoordinates()
    {
        coords.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        coords.y = Mathf.RoundToInt(transform.parent.position.z / 10);

        transform.parent.name = coords.ToString();
    }
}
