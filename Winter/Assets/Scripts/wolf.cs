using UnityEngine;
using System;
using System.Diagnostics;

public class wolf : MonoBehaviour {

    enum CharacterState {
        Sniffing = 0,
        Walking  = 1,
        Floating = 2,
    }
    public  Transform      player;
    private CharacterState animator;
    private NavMeshAgent   navigator;
    Stopwatch              sniffer;
    Stopwatch              location;
    Stopwatch              timer;
    // Maybe should have an action queue?

    private float temperature;
    private float velocity;
    private bool  ready;
    private bool  ending;

    private Vector3 destination;
    private Vector3 historical;
    private float radius;
    private float proximity;

    public GameObject girlCorpse;
    public GameObject wolfCorpse;


    // Called at Script Initialization
    void Start() {

        // Setup Character Controller
        navigator = GetComponent<NavMeshAgent>();
        animator  = CharacterState.Sniffing;
        sniffer   = new Stopwatch();
        location  = new Stopwatch();
        timer     = new Stopwatch();

        // Set Default Values
        temperature = 1f;
        velocity    = 0f;
        ready       = true;
        ending      = false;

        radius = 10;
        location.Start();
        historical = gameObject.transform.position;

        /*
        Vector3 movVec = new Vector3(
            UnityEngine.Random.Range(-100,500),
            0,
            UnityEngine.Random.Range(213,840));
        navigator.SetDestination(movVec);
        */

        // Generate New Coordinate
        // Set Velocity Based on Heat

    }

    // Called Once Every Frame
    void Update() {

        // If Player is Within Radius of Wolf, Increase Temperature
        proximity = getProximity(player.position);
        if (proximity <= radius) {
            float heat = 0.5f / proximity;
            // if (heat < 0.1) { heat = 0.1f; }
            if (heat > 0.4) { heat = 0.4f; }
            if (sniffer.IsRunning == false) {
                temperature += heat;
            }
        }
        else if (animator != CharacterState.Sniffing) {
            temperature -= 0.0025f * proximity;
        }

        // Set Some Default Assertions Regarding Wolf Temperature
        if (temperature < 1)   { temperature = 1;   } // Min Temp
        if (temperature > 100) { temperature = 100;   // Max Temp
            ending = true;
        }

        // Wolf is Stationary Under Threshold Temperature
             if (temperature <= 5) { velocity = 0; }
        else if (temperature >  5) {

            // Set a New Destination on Ready Event
            if (ready == true) {
                print("Setting New Destination");
                destination = getDestination();
                ready = false;
            } else { setVelocity(); }

            // Trigger Sniffing When Close to Destination
            if (getProximity(destination) <= 2) {
                animator = CharacterState.Sniffing;
                velocity = 0f; // Stop Wolf Movement
                if (sniffer.IsRunning == false) {
                    print("Starting Timer");
                    sniffer.Start();
                    ready = false;
            }} // Sniffer Check Outside Temperature Conditional
        }

        // Set New Destination After 5 Seconds of Sniffing
        if (sniffer.Elapsed.Seconds >= 5) {
            print("Resetting Timer");
            sniffer.Reset();
            ready = true;
        }

        // Set Character Animator State Variables
        if      (velocity == 0) { animator = CharacterState.Sniffing; }
        else if (velocity >  0) { animator = CharacterState.Walking;  }

        // Handle the Ending Sequence
        if (ending == true) {
            destination = new Vector3(552f,1f,527f);
            wolfCorpse.SetActive(true);
            girlCorpse.SetActive(true);

            if (getProximity(destination) <= 1) {
                if (timer.IsRunning == false) { timer.Start(); }
                else if (timer.Elapsed.Seconds >= 5) {
                    // Let the Player Roam Around then Trigger End Scene
                    animator = CharacterState.Floating;
                    gameObject.transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y + 1,
                        transform.position.z);
                    velocity = 0;
                }
                if (timer.Elapsed.Seconds >= 30) {
                    Application.LoadLevel("Win");
                }
            }
        }

        // Update the Historical Location Along an Interval (AM I STUCK?!)
        if (location.Elapsed.Seconds >= 2) {
            // If Distance from Historical Coordinate to Current Coordinate
            if (getProximity(historical) <= 5)       {
            if (animator != CharacterState.Sniffing) {
                print("I am possibly stuck.  Resetting!");
                destination = getDestination();
                ready = false;
            }}
            else { historical = gameObject.transform.position; }
            location.Reset();
            location.Start();
        }

        // Set Character Controller State Variables
        navigator.speed = velocity;
        navigator.SetDestination(destination);
        temperature -= 0.1f;
    }

    // Set Velocity as a Function of Temperature and Player Proximity
    void setVelocity()
    {
        velocity = 0.15f * temperature;
    }

    // Computes the Proximity of a Given Vector from the Wolf
    float getProximity(Vector3 input) {

        // Compute the Difference in Coordinate Positions
        float x = input.x - gameObject.transform.position.x;
        float y = input.y - gameObject.transform.position.y;
        float z = input.z - gameObject.transform.position.z;
        y = 0;

        // Return the Proximity Using the Distance Formula
        return Mathf.Sqrt((x * x) + (y * y) + (z * z));
    }

    // Create a New Destination Coordinate
    Vector3 getDestination()
    {
        float offset = UnityEngine.Random.Range(-75f, 50f);
        float x = gameObject.transform.position.x + offset;
        float z = gameObject.transform.position.z + offset;
        float y = UnityEngine.Random.Range(-5f, 5f);
        print(new Vector3(x, y, z));
        return new Vector3(x, y, z);
    }

    // Pass Variables to Mekanim Animation Controller
    public float GetTemp           () { return temperature; }
    public float GetSpeed          () { return velocity;    }
    public bool  GetGameOver       () { return false; }
    public bool  getFrozen         () { return temperature == 0; }
    public bool GetSniffing        () { return animator == CharacterState.Sniffing; }
    public bool GetStartedFloating () { return animator == CharacterState.Floating; }
}
