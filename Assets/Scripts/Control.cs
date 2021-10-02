using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Stats").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            stats.Mental -= 10;
            stats.Career -= 10;
        }

        if (Input.GetKeyDown("right"))
        {
            stats.Social -= 10;
        }

        if (Input.GetKeyDown("up"))
        {
            stats.Love -= 10;
        }

        if (Input.GetKeyDown("down"))
        {
            stats.Family -= 10;
        }
    }
}
