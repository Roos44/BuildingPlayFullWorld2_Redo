using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: This isn't an efficient or even remotely optimized way of doing this (meaning creating 'fake'-volumetric lighting)
  // ---> Considering it attempts to generate a mesh, apply the data, and render this mesh EVERY FRAME.

[ExecuteInEditMode] //CommentOutLater
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Light))]
public class VolumetricLightMesh : MonoBehaviour
{
    public float maximumOpacity = 0.25f;

    private MeshFilter filter;
    private new Light light;

    private Mesh mesh;

    private MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        light = GetComponent<Light>();

        meshCollider = GetComponent<MeshCollider>();

        if(light.type != LightType.Spot)
        {
            Debug.Log("NotASpotLIght");
        }
       
    }



    // Update is called once per frame
    void Update()
    {

        mesh = BuildMesh(); //Runs the BuildMesh(); which generates a new mesh and returns this into the variable named: 'mesh' 

        filter.mesh = mesh; //Fills the <MeshFilter> component ((= sends data of what to render to MeshRenderer)) with the most recently generated mesh

    }


    //Build a new mesh from light.spotAngle to light.range ((Diameter of spotlight and maximum distance/range of light)) 
      //-then returns a mesh to be used in Update();
    private Mesh BuildMesh()
    {
        mesh = new Mesh();

        float farPosition = Mathf.Tan(light.spotAngle * 0.5f * Mathf.Deg2Rad) * light.range;
        mesh.vertices = new Vector3[] {
            new Vector3(0,0,0),
            new Vector3(farPosition, farPosition, light.range),
            new Vector3(-farPosition, farPosition, light.range),
             new Vector3(-farPosition, -farPosition, light.range),
             new Vector3(farPosition, -farPosition, light.range)
        };
        mesh.colors = new Color[]{
            new Color(light.color.r, light.color.g, light.color.b, light.color.a * maximumOpacity),
            new Color(light.color.r, light.color.g, light.color.b, light.color.a * 0),
            new Color(light.color.r, light.color.g, light.color.b, light.color.a * 0),
            new Color(light.color.r, light.color.g, light.color.b, light.color.a * 0),
            new Color(light.color.r, light.color.g, light.color.b, light.color.a * 0)
        };
        mesh.triangles = new int[]{
            0,1,2,
            0,2,3,
            0,3,4,
            0,4,1
        };

        return mesh;
    }
}
