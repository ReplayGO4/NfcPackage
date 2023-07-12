using System;
using UnityEngine;

namespace DynaPro
{
    [CreateAssetMenu]
    public class DynaProSettings : ScriptableObject
    {

        public bool logDebug;
        
        
        [SerializeField]
        private string commandPath = "D:\\proj\\dynapro\\DynaProx\\Cli\bin\\Release\\net6.0\\win-x64\\publish\\Cli.exe";

        public string CommandPath
        {
            get
            {
                var envOverride = Environment.GetEnvironmentVariable("DYNAPRO_PATH");
                return string.IsNullOrWhiteSpace(envOverride) ? commandPath : envOverride;
            }
        }
        
        
    }
}