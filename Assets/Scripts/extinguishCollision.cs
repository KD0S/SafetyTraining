using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extinguishCollision : MonoBehaviour
{
    public string colliderName = "Fire";
    public float hitDistance = 3f;
    public float acceleration = -1f;
    private float speed;

    public float TimeToDestroy = 1f;
    private float MaxParticle;
    private float OriginalTimeToDestroy;
    private float OriginalMaxParticle;


    private Vector3 fireSize=new Vector3(0.1f,0.1f,0.1f);
    private Vector3 small=new Vector3(0f,0f,0f);


    void Start()
    {
        speed=2f;

    OriginalTimeToDestroy = TimeToDestroy;
    
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButton(0)){
                if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, hitDistance)){

                    if(hit.collider.name.Contains(colliderName))
                    {
                        ParticleSystem fireParticles= hit.collider.GetComponentInChildren<ParticleSystem>();
                        var main = fireParticles.main;
                        
                        // // speed= Mathf.Clamp(speed - acceleration * Time.deltaTime, 2, 0);
                        // speed= Mathf.Lerp(speed ,0, acceleration * Time.deltaTime);
                        // main.startSpeed = speed;
                        // Debug.Log(speed);
                        // //Destroy(hit.transform.gameObject);
                        MaxParticle = fireParticles.maxParticles;
                        OriginalMaxParticle = MaxParticle;
                        
                            if(TimeToDestroy >= 0)
                                {
                                    TimeToDestroy -= Time.deltaTime;
                                    MaxParticle = Mathf.Lerp(OriginalMaxParticle, 0, OriginalTimeToDestroy);
                                    fireParticles.maxParticles = Mathf.RoundToInt(MaxParticle);
                                }
                                else{
                                    // TimeToDestroy = OriginalTimeToDestroy;
                                    Destroy(hit.transform.gameObject);
                                }

                    }
                }
            }
    }


}
