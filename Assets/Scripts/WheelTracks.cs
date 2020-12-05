using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTracks : MonoBehaviour
{
    public Shader _drawShader;

    private RenderTexture _splatmap;
    private Material _snowMaterial, _drawmaterial;
    public GameObject _terrain;
    public Transform[] _wheel;
    RaycastHit _groundHit;
    int _layermask;
    [Range(0, 4)]
    public float _brushSize;
    [Range(0, 1)]
    public float _brushStrength;

   // Start is called before the first frame update
    void Start()
    {
        _layermask = LayerMask.GetMask("Ground");
        _drawmaterial = new Material(_drawShader);
        _snowMaterial = _terrain.GetComponent<MeshRenderer>().material;
        _splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        _snowMaterial.SetTexture("_Splat", _splatmap);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("i am here 1");
        for (int i=0;i<_wheel.Length;i++)
        {
            Debug.Log("i am here 2");
            if (Physics.Raycast(_wheel[i].position,Vector3.down,out _groundHit,4f,_layermask))
            {
                Debug.Log("i am here 3");
                _drawmaterial.SetVector("_Coordinate", new Vector4(_groundHit.textureCoord.x, _groundHit.textureCoord.y, 0, 0));
                _drawmaterial.SetFloat("_Strength", _brushStrength);
                _drawmaterial.SetFloat("_Size", _brushSize);
                RenderTexture temp = RenderTexture.GetTemporary(_splatmap.width, _splatmap.height, 0, RenderTextureFormat.ARGBFloat);
                Graphics.Blit(_splatmap, temp);
                Graphics.Blit(temp, _splatmap, _drawmaterial);
                RenderTexture.ReleaseTemporary(temp);
            }
        }
    }
}
