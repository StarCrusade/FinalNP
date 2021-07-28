using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerDirection direction;
    [HideInInspector]
    public float stepLength = 0.2f;
    [HideInInspector]
    public float movementFrequency = 0.1f;
    [SerializeField]
    private GameObject tailPrefab;
    
    private List<Vector3> deltaPosition;
    private List<Rigidbody> nodes;

    private Rigidbody mainBody;
    private Rigidbody headBody;
    private Transform tr;

    private float counter;
    private bool move;
    private bool CreateNodeAtTail;


    // Start is called before the first frame update
  
    void Awake()
    {
        
        tr = transform;
        mainBody = GetComponent<Rigidbody>();

        InitSnakeNodes();
        InitPlayer();

        deltaPosition = new List<Vector3>()
        {
            new Vector3 (-stepLength,0f,0f), // LEFT
            new Vector3 (0f,0f, stepLength), // UP
            new Vector3 (stepLength,0f,0f),  // RIGHT
            new Vector3 (0f, 0f,-stepLength) // DOWN
        };

    }

    // Update is called once per frame
    void Update()
    {
      CheckMovementFrequency();
    }
    void FixedUpdate()
    {
        if(move)
        {
            move = false;
            Move();
        }
    }

    void InitSnakeNodes()
    {
        nodes = new List<Rigidbody>();
        nodes.Add(tr.GetChild(0).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(1).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(2).GetComponent<Rigidbody>());

        headBody = nodes [0];
    }
    void SetDirectionRandom()
    {
        int dirRandom = Random.Range(0, (int)PlayerDirection.COUNT);
        direction = (PlayerDirection)dirRandom;
    }

    void InitPlayer()
    {
        SetDirectionRandom();

        switch(direction)
        {
            case PlayerDirection.RIGHT:
                nodes[1].position = nodes[0].position - new Vector3(0f, 0f, Metrics.NODE);
                nodes[2].position = nodes[0].position - new Vector3(0f, 0f, Metrics.NODE * 2);
                break;
            case PlayerDirection.LEFT:
                nodes[1].position = nodes[0].position + new Vector3(0f, 0f, Metrics.NODE);
                nodes[2].position = nodes[0].position + new Vector3(0f, 0f, Metrics.NODE * 2);
                break;
            case PlayerDirection.UP:
                nodes[1].position = nodes[0].position - new Vector3(Metrics.NODE, 0f, 0f);
                nodes[2].position = nodes[0].position - new Vector3(Metrics.NODE * 2, 0f, 0f);
                break;
            case PlayerDirection.DOWN:
                nodes[1].position = nodes[0].position + new Vector3(Metrics.NODE, 0f, 0f);
                nodes[2].position = nodes[0].position + new Vector3(Metrics.NODE * 2, 0f, 0f);
                break;
        }
    }

    void Move()
    {
        Vector3 dPosition = deltaPosition[(int) direction];
        Vector3 parentPos = headBody.position;
        Vector3 prevPosition;

        mainBody.position = mainBody.position + dPosition;
        headBody.position = headBody.position + dPosition;

        for(int i = 1; i < nodes.Count; i++)
        {
            prevPosition = nodes[i].position;
            nodes[i].position = parentPos;
            parentPos = prevPosition;
        }


        //create new node? 
        // because ate fruit? 
        if(CreateNodeAtTail)
        {
            CreateNodeAtTail = false;
            GameObject newNode = Instantiate(tailPrefab,nodes[nodes.Count - 1].position, Quaternion.identity);
            newNode.transform.SetParent(transform, true);
            nodes.Add(newNode.GetComponent<Rigidbody>());
        }


    }

    void CheckMovementFrequency()
    {
        counter += Time.deltaTime;
        if(counter >= movementFrequency)
        {
            counter = 0;
            move = true;
        }
    }

    public void SetInputDirection(PlayerDirection dir)
    {
        if(dir == PlayerDirection.UP && direction == PlayerDirection.DOWN || 
            dir == PlayerDirection.DOWN && direction == PlayerDirection.UP ||
            dir == PlayerDirection.LEFT && direction == PlayerDirection.RIGHT ||
            dir == PlayerDirection.RIGHT && direction == PlayerDirection.LEFT)
        {
            return;
        }

        direction = dir;
        ForceMove();
    }
    void ForceMove()
    {
        counter = 0;
        move = false;
        Move(); 
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == SnakeTags.Fruit)
        {
            target.gameObject.SetActive(false);
            CreateNodeAtTail = true;
        }
        if (target.tag == SnakeTags.Wall || target.tag == SnakeTags.Tail)
        {
            print("Touched Wall or tail");
            Destroy(gameObject);
        }
        


    }
}
