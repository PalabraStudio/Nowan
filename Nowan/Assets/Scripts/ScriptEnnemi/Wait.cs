using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    private MoveEnnemi MoveEnnemi;
    private CalculateMove calcMove;
    public int waiter;
    public float wait;
    public float timeBeforeSearch;
    public float timeBeforeGoback;
    private bool waitSearch;
    private bool waitReturn;
    // Start is called before the first frame update
    void Start()
    {
        wait = 0;
        waiter = 1;
        MoveEnnemi = this.GetComponent<MoveEnnemi>();
        calcMove = this.GetComponent<CalculateMove>();
        waitSearch = calcMove.waitSearch;
        waitReturn = calcMove.waitReturn;
    }

    // Update is called once per frame
    void Update()
    {
        if (wait > 0) { wait -= Time.deltaTime; }
        if (calcMove.waitSearch!=waitSearch&&waiter==1)
        {
            waitSearch = calcMove.waitSearch;
            if (waitSearch == true)
            {
                waiter = 0;
                wait = timeBeforeSearch;
            }
           
        }
        if (calcMove.waitReturn != waitReturn && waiter == 1)
        {
            waitReturn = calcMove.waitReturn;
            if (waitSearch == true)
            {
                waiter = 0;
                wait = timeBeforeGoback;
            }
        }
        if (wait < 0) { waiter = 1; }
        if (!this.GetComponent<StunEnnemi>().stun) { MoveEnnemi.waiter = waiter; }
        MoveEnnemi.waiter = waiter;
    }
}
