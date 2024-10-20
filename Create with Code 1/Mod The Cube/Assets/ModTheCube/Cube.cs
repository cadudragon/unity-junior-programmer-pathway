using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float scaleMultipler = 1.3f;
    public float rotationSpeed = 1.0f;
    public Vector3 initialPosition = new(3, 4, 1);
    public Vector2 scaleRange = new(0.3f, 3.0f);
    public Color initialColor = new(0.5f, 1.0f, 0.3f, 0.4f);

    private Material cachedMaterial;
    private float timeSinceLastSpeedChange = 0f;
    private readonly float changeInterval = 1f;

    void Start()
    {
        transform.position = initialPosition;
        cachedMaterial = Renderer.material; // Cache the material
        cachedMaterial.color = initialColor;

        InvokeRepeating(nameof(ChangeColorRandomly), 1.0f, 1.5f);
        InvokeRepeating(nameof(ChangeScaleRandomly), 0.7f, 2.0f);
    }

    void Update()
    {
        timeSinceLastSpeedChange += Time.deltaTime;

        if (timeSinceLastSpeedChange >= changeInterval)
        {
            rotationSpeed = Random.Range(1f, 300f);
            timeSinceLastSpeedChange = 0f;
        }

        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void ChangeColorRandomly()
    {
        cachedMaterial.color = new Color(Random.value, Random.value, Random.value);
    }

    private void ChangeScaleRandomly()
    {
        scaleMultipler = Random.Range(scaleRange.x, scaleRange.y);
        transform.localScale = Vector3.one * scaleMultipler;
    }
}
