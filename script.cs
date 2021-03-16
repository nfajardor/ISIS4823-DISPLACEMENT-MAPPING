using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    GameObject terr;
    Vector3[] vert;
    int[] tri;
    Mesh msh;
    int w;
    int h;
    // Start is called before the first frame update
    void Start()
    {   
        w = 100;
        h = 100;
        GameObject go = new GameObject("go", typeof(MeshFilter),typeof(MeshRenderer));
        msh = new Mesh();
        go.GetComponent<MeshFilter>().mesh = msh;
        go.GetComponent<Renderer>().material.SetTexture("_MainTex",(Texture2D)Resources.Load("Texture"));
        vertices();
        triangles();
        drawMesh();
    }

    void vertices(){
        vert = new Vector3[(w+1)*(h+1)];
        int c = 0;
        for(int i = 0;i<=h;i++){
            for(int j = 0;j<=w;j++){
                float y = Mathf.PerlinNoise(i*0.2f,j*0.25f) * 3f;
                vert[c] = new Vector3(j,y,i);
                c++;
            }
        }
    }
    void triangles(){
        tri = new int[6*w*h];
        int v = 0;
        int t = 0;
        for(int i = 0;i<h;i++){
            for(int j = 0;j<w;j++){
                tri[t] = v;
                tri[t+1] = v + w + 1;
                tri[t+2] = v + 1;
                tri[t+3] = v + 1;
                tri[t+4] = v + w + 1;
                tri[t+5] = v + w + 2;
                v++;
                t+=6;
            }
            v++;
        }
    }
    void drawMesh(){
        msh.Clear();
        msh.vertices = vert;
        msh.triangles = tri;
        msh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
