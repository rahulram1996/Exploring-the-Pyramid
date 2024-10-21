using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeighingScaleManager : MonoBehaviour
{

    public Transform leftPan; // Reference to the left pan
    public Transform rightPan; // Reference to the right pan
    public Transform rod; // Reference to the center balancing rod

    public float leftWeight = 13f; // Weight on the left pan
    public float rightWeight = 0f; // Weight on the right pan

    private float rodLength = 2f; // Length of the rod (distance between pans)
    private float maxAngle = 10f; // Maximum angle the rod can tilt
    private float angleOffset = 10f; // Maximum angle the rod can tilt

    public UnityEvent kingsChamberCompleted = new UnityEvent();
    private float successDelay = 2;
    private float timer;
    public bool isKingChamberTaskCompleted;


    public static WeighingScaleManager instance;

    private void Awake()
    {
        instance = this; 
    }


    void Start()
    {
        // Initialize the rod length based on the positions of the pans
        //rodLength = Vector3.Distance(leftPan.position, rightPan.position);
    }



    void Update()
    {
        //// Calculate the torque based on the weights and distances
        //float torque = CalculateTorque();

        //// Apply the torque to the rod's rotation
        //ApplyTorque(torque);

        //// Adjust the pans' positions based on the rod's rotation
        AdjustPanPositions();
    }



    //float CalculateTorque()
    //{
    //    // Calculate the torque based on the weights and the length of the rod
    //    leftWeight = leftPan.GetComponent<WeighingScalePlatform>().totalMass;
    //    rightWeight = rightPan.GetComponent<WeighingScalePlatform>().totalMass;
    //    //float leftTorque = leftWeight * (rodLength / 2f);
    //    //float rightTorque = rightWeight * (rodLength / 2f);

    //    //// The net torque is the difference between the left and right torques
    //    //return rightTorque - leftTorque;
    //}

    void ApplyTorque(float torque)
    {
        // Calculate the angle to apply based on the torque
        //float angle = torque * Time.deltaTime * angleOffset * (-1); // Adjust the torque with time delta

        //// Clamp the angle to the maximum angle
        //float currentAngle = rod.localEulerAngles.y;
        //if (currentAngle > 180f) currentAngle -= 360f;
            
        //float newAngle = Mathf.Clamp(currentAngle + angle, -maxAngle, maxAngle);
        //Debug.LogError("angle is :" + angle);

        //// Apply the clamped angle to the rod's rotation
        //rod.localEulerAngles = new Vector3(0f, newAngle, 0f);
    }

    void AdjustPanPositions()
    {
        // Calculate the vertical displacement based on the rod's rotation
        //float angle = rod.localEulerAngles.y;


        //if (angle > 180f) angle -= 360f;

        //float panVerticalOffset = Mathf.Sin(angle * Mathf.Deg2Rad) * (rodLength / 2f) * 0.01f;

        //// Apply the vertical displacement to the left and right pans
        //leftPan.localPosition = new Vector3(leftPan.localPosition.x, leftPan.localPosition.y, - panVerticalOffset);
        //rightPan.localPosition = new Vector3(rightPan.localPosition.x, rightPan.localPosition.y, panVerticalOffset);
        //leftWeight = leftPan.GetComponent<WeighingScalePlatform>().totalMass;
        rightWeight = rightPan.GetComponent<WeighingScalePlatform>().totalMass;

        if (leftWeight > rightWeight)
        {
            Debug.Log("Left side is heavier.");
        }
        //else if (rightWeight > leftWeight)
        //{
        //    Debug.Log("Right side is heavier.");
        //}
        else
        {
            Debug.Log("The scale is balanced.");
            if (!isKingChamberTaskCompleted)
            {
                timer += Time.deltaTime;

                if (timer > successDelay)
                {
                    kingsChamberCompleted.Invoke();
                    isKingChamberTaskCompleted = true;
                    timer = 0;
                }
            }
        }
    }

    // Function to set the weight on the left pan
    public void SetLeftWeight(float weight)
    {
        leftWeight = weight;
    }

    // Function to set the weight on the right pan
    public void SetRightWeight(float weight)
    {
        rightWeight = weight;
    }











    //public Transform leftPlatform;
    //public Transform rightPlatform;

    //public float maxMovementRange = 1.0f; // Maximum movement range for the platforms
    //public float balanceSpeed = 2.0f; // Speed at which the platforms move to balance

    //public static WeighingScaleManager instance;

    //public UnityEvent kingsChamberCompleted = new UnityEvent();
    //private float successDelay = 4;
    //private float timer;
    //public bool isKingChamberTaskCompleted;

    //private void Awake()
    //{
    //    instance = this; 
    //}

    //private void Update()
    //{
    //    float leftMass = CalculateMass(rightPlatform);
    //    float rightMass = CalculateMass( leftPlatform);

    //    AdjustPlatformPositions(leftMass, rightMass);

    //    if (leftMass > rightMass)
    //    {
    //        Debug.Log("Left side is heavier.");
    //    }
    //    else if (rightMass > leftMass)
    //    {
    //        Debug.Log("Right side is heavier.");
    //    }
    //    else
    //    {
    //        Debug.Log("The scale is balanced.");
    //        if (!isKingChamberTaskCompleted)
    //        {
    //            timer += Time.deltaTime;

    //            if (timer > successDelay)
    //            {
    //                kingsChamberCompleted.Invoke();
    //                isKingChamberTaskCompleted = true;
    //                timer = 0;
    //            } 
    //        }
    //    }
    //}

    //private float CalculateMass(Transform platform)
    //{
    //    float totalMass = 0;

    //    totalMass = platform.GetComponent<WeighingScalePlatform>().totalMass * -1;
    //    return totalMass;
    //}

    //private void AdjustPlatformPositions(float leftMass, float rightMass)
    //{
    //    float totalMass = leftMass + rightMass;
    //    if (totalMass == 0) return;

    //    float leftWeightRatio = leftMass / totalMass;
    //    float rightWeightRatio = rightMass / totalMass;

    //    // Calculate target positions
    //    float leftTargetY = Mathf.Lerp(0, -maxMovementRange, rightWeightRatio);
    //    float rightTargetY = Mathf.Lerp(0, -maxMovementRange, leftWeightRatio);

    //    // Move platforms to the target positions smoothly
    //    leftPlatform.localPosition = Vector3.Lerp(leftPlatform.localPosition, new Vector3(leftPlatform.localPosition.x, leftPlatform.localPosition.y, leftTargetY), Time.deltaTime * balanceSpeed);
    //    rightPlatform.localPosition = Vector3.Lerp(rightPlatform.localPosition, new Vector3(rightPlatform.localPosition.x, rightPlatform.localPosition.y, rightTargetY), Time.deltaTime * balanceSpeed);
    //}
}
