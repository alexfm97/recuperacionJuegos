using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordData : MonoBehaviour
{
    int record;

    public RecordData(int record)
    {
        this.record = record;
    }

    public int GetRecord()
    {
        return record;
    }

    public void SetRecord(int record)
    {
        this.record = record;
    }
}
