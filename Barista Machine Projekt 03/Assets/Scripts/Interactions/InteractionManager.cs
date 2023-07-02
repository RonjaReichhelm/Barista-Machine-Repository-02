using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionLabel;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    
    // ErrorCounter
    [SerializeField] private TextMeshProUGUI errorCountLabel;
    private int errorCount;
    
    // helpCounter
    [SerializeField] private TextMeshProUGUI helpCountLabel;
    private int helpCount;
    
    // Endbildschirm
    [SerializeField] private TextMeshProUGUI endErrorCountLabel;
    private int endErrorCount;
    [SerializeField] private TextMeshProUGUI endHelpCountLabel;
    private int endHelpCount;
    
    [SerializeField] private LayerMask layerMask;
    
    [SerializeField] private List<Interaction> interactions;
    private Interaction currentInteraction;
    private int interactionIndex;
    
    private Camera cam;
    
    private bool isHelpCountIncremented = false; //EinmaligHelp
    private Coroutine displayCoroutine;
    private bool coroutineRunning  = false;
    
    
    private void Awake() => cam = Camera.main;

    private void Start()
    {
        helpLabel.SetText("");
        errorLabel.SetText("");
        
        errorCountLabel.SetText("Errors: " + errorCount); // ErrorCounter
        helpCountLabel.SetText("Help Requests: " + helpCount); // helpCounter
        
        // Endbildschirm
        errorCountLabel.SetText("Errors: " + endErrorCount); 
        helpCountLabel.SetText("Help Requests: " + endHelpCount);
        
        currentInteraction = interactions[interactionIndex];
        instructionLabel.SetText(currentInteraction.Instruction);
    }

    void Update()
    {
        DebugDrawRay();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
            {
                CheckInteractionOrder(hit.transform.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        { 
         
            
            //Einmalig HelpCount
            if (!isHelpCountIncremented) 
            {
                helpCount++;
                endHelpCount++;
                helpCountLabel.SetText("Help Requests: " + helpCount); // helpCounter
                endHelpCountLabel.SetText("Help Requests: " + helpCount); // Endbildschirm
                isHelpCountIncremented = true;
            }
            
            helpCountLabel.SetText("Help Requests: " + helpCount); // HelpCounter
            endHelpCountLabel.SetText("Help Requests: " + helpCount); // Endbildschirm
            
            StopHelpAndErrorDisplay();
            if (!coroutineRunning)
            {
                StartCoroutine(DisplayForDuration(helpLabel, currentInteraction.HelpMsg, 3.0f));
            }
        }
    }

    private void CheckInteractionOrder(GameObject selectedGameObject)
    {
        if (selectedGameObject.Equals(currentInteraction.GameObject))
        {
            StopHelpAndErrorDisplay();
            currentInteraction.OnExecution?.Invoke();
            
            interactionIndex++;
            if(interactionIndex >= interactions.Count)
                return;
            
            currentInteraction = interactions[interactionIndex];
            instructionLabel.SetText(currentInteraction.Instruction);
        }
        else
        {
            errorCount++; // ErrorCounter
            errorCountLabel.SetText("Errors: " + errorCount);
            
            // Endbildschirm
            endErrorCount++; 
            endErrorCountLabel.SetText("Errors: " + endErrorCount);

            StartCoroutine(DisplayErrorForDuration(errorLabel, currentInteraction.ErrorMsg, 3.0f));

        }
    }

    private void DebugDrawRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 20.0f, Color.red);
        }
    }
    
    /// <summary>
    /// This coroutine displays a text (msg) for a fixed number of seconds (duration)
    /// on a Text UI Element (label).
    /// </summary>
    private IEnumerator DisplayForDuration(TextMeshProUGUI label, string msg, float duration)
    {

        label.text = msg;
        yield return new WaitForSeconds(duration);
        helpCountLabel.SetText("Help Requests: " + helpCount); // helpCounter
        endHelpCountLabel.SetText("Help Requests: " + helpCount); // Endbildschirm
        label.text = "";

        isHelpCountIncremented = false;
        coroutineRunning = false;
    }
    
    private IEnumerator DisplayErrorForDuration(TextMeshProUGUI label, string msg, float duration)
    {
        label.text = msg;
        yield return new WaitForSeconds(duration);
        label.text = "";
    }
    
    private IEnumerator increaseForDuration(TextMeshProUGUI label, string msg, float duration)
    {
        yield return new WaitForSeconds(duration);
    }
    private void StopHelpAndErrorDisplay()
    {
        StopAllCoroutines();
        errorLabel.SetText("");
        helpLabel.SetText("");
    }
}
