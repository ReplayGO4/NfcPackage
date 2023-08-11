using System;
using UnityEngine;

namespace Beamable.Go4.Nfc
{
    [CreateAssetMenu]
    public class DynaProSettings : ScriptableObject
    {

        public bool logDebug;
        public bool disableEnvOverride;
        
        
        [SerializeField]
        private string commandPath = "D:\\proj\\dynapro\\DynaProx\\Cli\bin\\Release\\net6.0\\win-x64\\publish\\Cli.exe";

        public string CommandPath
        {
            get
            {
                if (disableEnvOverride)
                {
                    return commandPath;
                }
                
                var envOverride = Environment.GetEnvironmentVariable("DYNAPRO_PATH");
                return string.IsNullOrWhiteSpace(envOverride) ? commandPath : $"\"{envOverride}\"";
            }
        }
        
        
    }
}