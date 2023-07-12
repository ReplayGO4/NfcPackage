using System;
using System.Reflection;
namespace Beamable.Microservices
{
    public static class JsonHack
    {
        private static MethodInfo _convertMethod;
        
        public static void Load()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var asm in assemblies)
            {
                if (!asm.FullName.StartsWith("Newtonsoft.Json"))
                {
                    continue;
                }
                
                var jsonConvertType = asm.GetType("Newtonsoft.Json.JsonConvert", true);
     
                _convertMethod = jsonConvertType.GetMethod("SerializeObject", new Type[]{typeof(object)});
            }
            
        }

        public static string ToJson(object obj)
        {
            var result = _convertMethod?.Invoke(null, new[] { obj }) as string;
            return result;
        }
    }
}