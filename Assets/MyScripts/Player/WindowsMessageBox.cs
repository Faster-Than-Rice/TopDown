using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Windows.Forms;

public class WindowsMessageBox : MonoBehaviour
{
    private void Start()
    {
        MessageBox.Show("ÇÊÇ§Ç±ÇªÅA " + Environment.UserName + " !");
    }
}
