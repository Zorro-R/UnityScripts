using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;  
    private float[] parallaxScales;  // Proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f; // How smooth the parallax is (must be > 0)

    private Transform cam;
    private Vector3 previousCamPos;

    // Called before Start() --> Good for references
    void Awake()
    {
        // set up camera reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos =
                new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position =
                Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
