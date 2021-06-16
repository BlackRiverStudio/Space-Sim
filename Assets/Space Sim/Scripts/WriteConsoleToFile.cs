using System;
using System.IO;
using UnityEngine;

public class WriteConsoleToFile : MonoBehaviour
{
    private void OnEnable() => Application.logMessageReceived += Log;
    private void OnDisable() => Application.logMessageReceived -= Log;
    public void Log(string _logString, string _stackTrace, LogType _type)
    {
        if (_type == LogType.Log) return;
        
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GameLogs";
        Directory.CreateDirectory(filePath);
        
        string fileName = filePath + "/log.txt";
        StreamWriter file = new StreamWriter(fileName, true);
        
        try { file.WriteLine("[" + DateTime.Now.ToString() + "] " + _logString + "\n" + _stackTrace); }
        catch (IOException e)
        {
            Application.logMessageReceived -= Log;
            Debug.LogError(e + " Error logged to file.");
        }
        catch (Exception e)
        {
            Application.logMessageReceived -= Log;
            Debug.LogError(e + " Error logged to file.");
        }
        finally { if (file != null) file.Close(); }
    }
}