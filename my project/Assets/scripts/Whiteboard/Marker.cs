using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Marker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int penSize = 5;
    private Renderer _renderer;
    private Color[] colors;
    private Color[] whiteCols;
    private float tipHeight;
    private RaycastHit hit;
    private Whiteboard whiteboard;
    public Whiteboard initialRedBoard;
    private Vector2 hitPos, lastHitPos;
    private bool hitLastFrame;
    private Quaternion lastHitRot;

    void Start()
    {
        _renderer = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(_renderer.material.color, penSize*penSize).ToArray();
        tipHeight = tip.localScale.y;

        whiteCols = Enumerable.Repeat(Color.white, 2048*4096).ToArray();
        initialRedBoard.tex.SetPixels(0,0,2048,4096,whiteCols);
        initialRedBoard.tex.Apply();
    }

    void Update()
    {
        
        Draw();
    }

    private void Draw(){
        if(Physics.Raycast(tip.position, transform.up, out hit, tipHeight)){
            if(hit.transform.CompareTag("Whiteboard")){
                if(whiteboard == null){
                    whiteboard = hit.transform.GetComponent<Whiteboard>();
                }

                hitPos = new Vector2(hit.textureCoord.x, hit.textureCoord.y);

                var x = (int)(hitPos.x * whiteboard.texSize.x - (penSize/2));
                var y = (int)(hitPos.y * whiteboard.texSize.y - (penSize/2));

                if(y<0 || y > whiteboard.texSize.y||x<0 || x > whiteboard.texSize.x){
                    return;
                }

                if(hitLastFrame){

                    float distanceRate =  1 - hit.distance / tipHeight;
                    whiteboard.tex.SetPixels(x,y,(int)((float)penSize*distanceRate),(int)((float)penSize*distanceRate),colors);

                    for(float f = 0.01f; f < 1.00f; f+= 0.005f){
                        var lerpX = (int)Mathf.Lerp(lastHitPos.x,x,f);
                        var lerpY = (int)Mathf.Lerp(lastHitPos.y,y,f);
                        whiteboard.tex.SetPixels(lerpX,lerpY,penSize,penSize,colors);
                    }

                    transform.rotation = lastHitRot;

                    whiteboard.tex.Apply();
                }

                lastHitPos = new Vector2(x,y);
                lastHitRot = transform.rotation;
                hitLastFrame = true;
                return;
            }
        }

        whiteboard = null;
        hitLastFrame = false;
    }
}
