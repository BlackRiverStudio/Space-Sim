using UnityEngine;
using UnityEngine.UI;

public enum RenderRate { r16, r32 };

public class ChangeRenderTexture : MonoBehaviour
{
    [SerializeField] private RawImage raw;
    [SerializeField] private Camera cam;
    [SerializeField] private RenderRate rate;

    public RenderRate Rate
    {
        get => rate;
        set
        {
            rate = value;
            ChangeBitRate(value);
        }
    }

    private void Start() => ChangeBitRate(rate);

    private void ChangeBitRate(RenderRate _rate)
    {
        if (cam.targetTexture != null) cam.targetTexture.Release();
       
        RenderTexture texture;

        switch (_rate)
        {
            case RenderRate.r16:
                texture = new RenderTexture(Screen.width, Screen.height, 16);
                break;
            
            case RenderRate.r32:
                texture = new RenderTexture(Screen.width, Screen.height, 32);
                break;
            
            default: return;
        }

        cam.targetTexture = texture;
        raw.texture = texture;
    }
}