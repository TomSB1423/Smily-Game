using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Backgrounds
    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    // MainCamera
    private Transform cam;
    private Vector3 prevCamPos;


    void Awake()
    {
        cam = Camera.main.transform;
    }


    void Start()
    {
        prevCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i< backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (prevCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        prevCamPos = cam.position;        
    }
}
