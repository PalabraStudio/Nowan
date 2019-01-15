using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateMove : MonoBehaviour {
    public List<GameObject> listeOuverte;
    public List<GameObject> listeFermee;
    public GameObject origine;
    public GameObject current;
    private Vector3 cPosition;
    private Vector3 nPosition;
    private Vector3 dPosition;
    public GameObject destination;
    private int tempG;
    public int overloop;
    private int lim;
    private int fmin;
    private GameObject nfmin;
    public bool isPathF;
    public List<GameObject> path;
    public int directionX;
    public int directionY;
    private bool pathIsFoud;
    public bool pathIsReady;
    private GameObject pathO;
    private Vector2 directSuiv;
    private Vector2 directAct;
    public List<GameObject> lNoeud;
    public List<Vector2> vRoutine;
    public List<Vector2> vPath;
    public List<GameObject> lParent;
    public List<int> lG;
    public List<int> lF;
    public List<int> lH;
    public List<GameObject> ld;
    public List<GameObject> lf;
    public GameObject NodeGrid;
    public List<GameObject> routine;
    public bool boucleRoutine;
    public bool pathfind;
    public bool routining;
    private bool firstRoutine;
    private GameObject pPuce;
    public Vector2 pDirection;
    public bool following;
    public GameObject lastKnownPNode;
    public Vector2 returnLastNode;
    public float TimeUntilStopFollow;
    public float CountDown;
    public bool onPath;
    public GameObject nextToPath;
    public bool nextToPathB;
    public float overtime;
    public bool entendu;
    // Use this for initialization
    void Start () {
        lim = 100;
        routining = true;
        NodeGrid=GameObject.Find("NodeGrid");
        onPath = true;
        nextToPathB = true;
        CountDown = TimeUntilStopFollow;
        pPuce = GameObject.Find("pPuce");
        Cleaner();//Rend le programe propre avant démarrage
        foreach (Transform transform in NodeGrid.GetComponentInChildren<Transform>())
        {
            lNoeud.Add(transform.gameObject);
            vRoutine.Add(new Vector2(0, 0));
            vPath.Add(new Vector2(0, 0));
            lParent.Add(null);
            ld.Add(null);
            lf.Add(null);
            lG.Add(0);
            lF.Add(0);
            lH.Add(0);

        }
    }
	
	// Update is called once per frame
	void Update () {
        //entendu = this.GetComponentInChildren<OuieDistVerif>().entendu;
        //pDirection = pPuce.transform.position-this.transform.position;
        //pDirection = pDirection.normalized;
        returnLastNode = DirectionToNode(origine);
        CountDown -= Time.deltaTime;
        /*if ((pPuce.GetComponentInParent<MoveCaracter>().shift||!routining)&&CountDown>0&&entendu)
        {
            lastKnownPNode = pPuce.GetComponent<setNode>().noeud;
        }*/
        if (lastKnownPNode != null&&CountDown>0) { destination = lastKnownPNode; }
        if (current== lastKnownPNode&&lastKnownPNode==pPuce.GetComponent<setNode>().noeud)
        {
            CountDown = TimeUntilStopFollow;
            following = true;
            this.GetComponent<MoveEnnemi>().direction = pDirection;
            onPath = false;
            nextToPathB = true;
        }
        else if (CountDown > 0&&!routining)
        {
            if (!onPath)
            {
                if (nextToPathB) { nextToPath = lastKnownPNode;nextToPathB = false; }

                            if (DirectionToNode(nextToPath).magnitude > 2)
                            {
                                this.GetComponent<MoveEnnemi>().direction = DirectionToNode(nextToPath).normalized;
                            }
                            else
                            {
                                onPath = true;
                                nextToPathB = true;
                            }
            }
            
            if (onPath&&following)
            {
                this.GetComponent<MoveEnnemi>().direction = new Vector2 (0,0);
                following = false;
                pathfind = true;
                destination = lastKnownPNode;
                Cleaner();
            }
        }
        else if (!routining&&CountDown<0 && (returnLastNode.magnitude>2)&&lastKnownPNode!=null)
        {
            pathfind = false;
            returnLastNode = returnLastNode.normalized;
            this.GetComponent<MoveEnnemi>().direction = returnLastNode;
        }
        else if (!routining&&!pathfind)
        {
                        lastKnownPNode = null;
            Debug.Log("c'est ok");
            onPath = true;
            following = false;
            destination = routine[routine.Count - 1];
            origine = current;
            this.GetComponent<MoveEnnemi>().direction = new Vector2(0, 0);
            pathfind = true;
            Cleaner();
            goto forcePathfind;

        }

        if (CountDown < -overtime)
        {
            onPath = true;
            following = false;
            routining = true;
            destination = null;
            pathfind = false;
            firstRoutine = true;
            Cleaner();
            this.transform.position = routine[routine.Count-1].transform.position;
            current = routine[routine.Count - 1];
            origine = routine[routine.Count - 1];
            //this.GetComponent<MoveEnnemi>().direction = new Vector2(0, 0);
            CountDown = TimeUntilStopFollow;
            goto forceRoutine;
        }
        if (destination!=null && routining)
        {
            pathfind = true;
            routining = false;
            origine =path[path.IndexOf(current)-1];
            Cleaner();

        }
        forcePathfind:
        if (pathfind&&!following)
        {

            if (destination != null)
            {
                dPosition = destination.transform.position;//Nécessaire pour A*
            }
            //Définit le premier élément de path
            if (path.Count != 0) { pathO = path[0]; }
            else { pathO = null; }
            //Permet de changer de destination en cours de route
            if (destination != pathO && pathIsFoud&& path.Contains(current)&&origine!=destination)
            {
                Debug.Log(current);
                if (path.IndexOf(current) == 0) { origine = path[path.Count - 1]; }
                else { origine = path[path.IndexOf(current) - 1]; }
                Cleaner();
            }
            else if (!path.Contains(current))
            {

                Cleaner();
            }
            //Nettoie les éléments du code pour pouvoir le relancer
            if ((origine == destination && path.Count != 0) || (origine != null && current == null))
            {
                Cleaner();
            }
            //Calcule le chemin si un certain nombre de conditions sont remplies
            if (current == origine && !pathIsFoud && destination != null && listeFermee.Count == 0 && origine != destination && overloop != lim)
            {
                Pathfinder(); Debug.Log("pathfinder");
            }
            //Calcule le chemin, et applique à chaque noeud une direction
            if (current == destination && pathIsFoud&& origine!=destination) { path.Add(destination); Pathdefiner(); Debug.Log("pathdef"); ChangeDirection(); }

        }
        if (destination == null) { routining = true; }
        forceRoutine:   
        if (routining&&!following )
        {
            CountDown = TimeUntilStopFollow;
            if (boucleRoutine && firstRoutine) 
            {
                firstRoutine = false;
                foreach (GameObject node in routine)
                {
                   
                    path.Add(node);
                    if (routine.IndexOf(node) == 0)
                    {
                        lParent[lNoeud.IndexOf(node)] = routine[routine.Count - 1];
                    }
                    else
                    {

                        lParent[lNoeud.IndexOf(node)] = routine[routine.IndexOf(node) - 1];
                    }
                }
                foreach (GameObject node in routine)
                {
                    vPath[lNoeud.IndexOf(lParent[lNoeud.IndexOf(node)])] =
                                (node.transform.position - lParent[lNoeud.IndexOf(node)].transform.position).normalized;
                }              
                
            }

            else
            {
                if (current == routine[0] && !firstRoutine)
                {
                    path.Clear();
                    Debug.Log("retour");
                    firstRoutine = true;
                    foreach (GameObject node in routine)
                    {
                        if (routine.IndexOf(node) != 0)
                        {
                            lParent[lNoeud.IndexOf(node)] = routine[routine.IndexOf(node) - 1];
                        }
                    }
                    for (int id = routine.Count - 1; id > 0; id--)
                    {
                        path.Add(routine[id]);
                    }
                    foreach (GameObject node in routine)
                    {
                        if (lParent[lNoeud.IndexOf(node)] != null)
                        { 
                            vPath[lNoeud.IndexOf(lParent[lNoeud.IndexOf(node)])] = 
                                (node.transform.position- lParent[lNoeud.IndexOf(node)].transform.position).normalized;
                        }
                    }
                }
                else if ((current == routine[routine.Count-1]&&firstRoutine)||(current!=routine[0]&&firstRoutine&&pathfind))
                {
                    Cleaner();
                    pathfind = false;
                    firstRoutine = false;
                    Debug.Log("aller");
                    for (int id = routine.Count-1; id >= 0; id--)
                    {
                        if (id != routine.Count - 1)
                        {
                            lParent[lNoeud.IndexOf(routine[id])] = routine[routine.IndexOf(routine[id]) + 1];
                        }
                    }
                    foreach(GameObject node in routine)
                    {
                        if (node != routine[routine.Count - 1]) { path.Add(node); }
                    }
                    for (int id = routine.Count-1; id >= 0; id--)
                    {
                        if (lParent[lNoeud.IndexOf(routine[id])] != null)
                        { 
                            vPath[lNoeud.IndexOf(lParent[lNoeud.IndexOf(routine[id])])] = 
                                (routine[id].transform.position- lParent[lNoeud.IndexOf(routine[id])].transform.position).normalized;
                        }
                    }
                }
            }
        }

    }
    //Code qui effectue l'algo A*
    void Pathfinder()
    {
       
        fmin = lF[lNoeud.IndexOf(listeOuverte[0])];
        foreach (GameObject noeud in listeOuverte)
        {
            if (fmin >= lF[lNoeud.IndexOf(noeud)])
            {
                fmin = lF[lNoeud.IndexOf(noeud)];
                nfmin = noeud;
            }
        }
        current = nfmin;
        listeFermee.Add(current);
        if (!listeOuverte.Contains(current)) { Debug.Log("abscent"); }
        listeOuverte.Remove(current);
        overloop++;
        cPosition = current.transform.position;
        foreach (GameObject noeud in current.GetComponent<Node>().voisins)
        {
            nPosition = noeud.transform.position;
            if (listeOuverte.Contains(noeud))
            {
                tempG = lG[lNoeud.IndexOf(current)] + Mathf.Abs(((int)cPosition.x) - ((int)nPosition.x))
                                + Mathf.Abs(((int)cPosition.y) - ((int)nPosition.y));
                if (tempG < lG[lNoeud.IndexOf(noeud)])
                {
                    lParent[lNoeud.IndexOf(noeud)] = current;
                    lG[lNoeud.IndexOf(noeud)] = lG[lNoeud.IndexOf(current)] + Mathf.Abs(((int)cPosition.x) - ((int)nPosition.x))
                                        + Mathf.Abs(((int)cPosition.y) - ((int)nPosition.y));
                    lH[lNoeud.IndexOf(noeud)] = Mathf.Abs(((int)dPosition.x) - ((int)nPosition.x))
                            + Mathf.Abs(((int)dPosition.y) - ((int)dPosition.y));
                    lF[lNoeud.IndexOf(noeud)] = lG[lNoeud.IndexOf(noeud)] + lH[lNoeud.IndexOf(noeud)];
                }

            }
            else if (!listeFermee.Contains(noeud))
            {
                listeOuverte.Add(noeud);
                lParent[lNoeud.IndexOf(noeud)] = current;
                lG[lNoeud.IndexOf(noeud)] = lG[lNoeud.IndexOf(current)] + Mathf.Abs(((int)cPosition.x) - ((int)nPosition.x))
                                    + Mathf.Abs(((int)cPosition.y) - ((int)nPosition.y));
                lH[lNoeud.IndexOf(noeud)] = Mathf.Abs(((int)dPosition.x) - ((int)nPosition.x))
                        + Mathf.Abs(((int)dPosition.y) - ((int)dPosition.y));
                lF[lNoeud.IndexOf(noeud)] = lG[lNoeud.IndexOf(noeud)] + lH[lNoeud.IndexOf(noeud)];
            }

               
        }
        if (overloop == lim)
        {
            Debug.Log("overloop");
            Debug.Log(listeFermee);
            Debug.Log(listeOuverte);
            return;
        }
        if (current != destination) { Pathfinder(); }
        else { pathIsFoud = true; }
    }
    //Code qui bidouille les noeuds
    void Pathdefiner()
    {
        vPath[lNoeud.IndexOf(lParent[lNoeud.IndexOf(current)])] =
                            (current.transform.position-lParent[lNoeud.IndexOf(current)].transform.position).normalized;
        current = lParent[lNoeud.IndexOf(current)];
        path.Add(current);
        if (current!= origine) { Pathdefiner(); }
        else { pathIsReady = true; }
    }
    //Code qui nettoie les objets
    void Cleaner()
    {
        Debug.Log("cleaner");
        listeFermee.Clear();
        listeOuverte.Clear();
        listeOuverte.Add(origine);
        foreach (GameObject noeud in lNoeud)
        {
            lParent[lNoeud.IndexOf(noeud)] = null;
            vPath[lNoeud.IndexOf(noeud)] = new Vector2(0, 0);
            lH[lNoeud.IndexOf(noeud)] = 0;
            lG[lNoeud.IndexOf(noeud)] = 0;
            lF[lNoeud.IndexOf(noeud)] = 0;
            lf[lNoeud.IndexOf(noeud)] = null;
            ld[lNoeud.IndexOf(noeud)] = null;
        }
        path.Clear();
        current = origine;
        pathIsFoud = false;
        pathIsReady = false;
        overloop = 0;
        if (routine.Contains(destination)&&routine.Contains(current)&&!this.GetComponent<MoveEnnemi>().ismoving) { destination = null; }
        firstRoutine = true;
        lastKnownPNode = null;
    }

    //Permet de changer de direction en cours de route (faire demi-tour si jamais ça va plus vite)
    void ChangeDirection()
    {
        directAct = this.GetComponent<MoveEnnemi>().direction;
        directSuiv = vPath[lNoeud.IndexOf(path[path.Count - 1])];
        directSuiv = directSuiv * -1;
        if (directSuiv == directAct) { this.GetComponent<MoveEnnemi>().direction = -directAct; }
    }
    Vector2 DirectionToNode (GameObject node)
    {
        return node.transform.position - this.transform.position;
    }
}
