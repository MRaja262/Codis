using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform[] layers;
    public float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    private void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    private void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float newX = layers[i].position.x + parallax;
            Vector3 newLayerPos = new Vector3(newX, layers[i].position.y, layers[i].position.z);
            layers[i].position = Vector3.Lerp(layers[i].position, newLayerPos, Time.deltaTime * smoothing);

            if (Mathf.Abs(cam.position.x - layers[i].position.x) >= layers[i].GetComponent<SpriteRenderer>().bounds.size.x)
            {
                float offsetX = Mathf.Sign(cam.position.x - layers[i].position.x) * layers[i].GetComponent<SpriteRenderer>().bounds.size.x;
                layers[i].position = new Vector3(layers[i].position.x + offsetX, layers[i].position.y, layers[i].position.z);
            }
        }

        previousCamPos = cam.position;
    }
}