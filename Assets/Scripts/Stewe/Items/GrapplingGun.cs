using System;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private SpringJoint joint;

    private LineRenderer lineRenderer;

    private Vector3 grapplePoint;

    public LayerMask grappableLayer;

    public float maxDistance;
    public float maxJointLength;
    public float minJointLength;
    public float jointSpring;
    public float jointDamper;
    public float jointScale;


    public Transform cam;
    public Transform gun;
    public Transform player;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGraple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGraple();
        }
    }

    private void LateUpdate()
    {
        drawLine();
    }

    private void StopGraple()
    {
        GameObject.Destroy(joint);
        lineRenderer.positionCount = 0;
    }

    private void StartGraple()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, grappableLayer))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * maxJointLength;
            joint.minDistance = distanceFromPoint * minJointLength;

            joint.spring = jointSpring;
            joint.damper = jointDamper;
            joint.massScale = jointScale;

            lineRenderer.positionCount = 2;

        }
    }

    private void drawLine()
    {
        if (!joint) return;

        lineRenderer.SetPosition(0, gun.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }
}