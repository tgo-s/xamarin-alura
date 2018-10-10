using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace carros_2.config
{
    /// <summary>
    /// Class to read a config json file
    /// Credits: Les Brown - https://www.linkedin.com/pulse/xamarinforms-using-configuration-files-les-brown/
    /// More in: https://github.com/azdevelopnet/CommonCore.ReferenceGuide
    /// ---
    /// A model class is needed to read the .json file, so you will need to create it exactly like the config file to parse it to the model.
    /// Don't forget to change de build action property of cofig.json to Embedded Resource
    /// and create your config.json at the root of shared project
    /// </summary>
    public static class ResourceLoader
    {
        public static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)
        {
            string[] resourceNames = assembly.GetManifestResourceNames();
            string[] resourcePaths = resourceNames.Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase)).ToArray();

            if (!resourcePaths.Any())
            {
                throw new Exception(string.Format("Resource ending with {0} was not found!", resourceFileName));
            }

            if (resourcePaths.Length > 1)
            {
                throw new Exception(string.Format("Multiple resources ending with {0} was found: {1}{2}", resourceFileName, Environment.NewLine, string.Join(Environment.NewLine, resourcePaths)));
            }

            return assembly.GetManifestResourceStream(resourcePaths.Single());
        }

        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string resourceFileName)
        {
            var stream = GetEmbeddedResourceStream(assembly, resourceFileName);

            using (var memStream = new MemoryStream())
            {
                stream.CopyTo(memStream);
                return memStream.ToArray();
            }
        }

        public static string GetEmbeddedResourceString(Assembly assembly, string resourceFileName)
        {
            var stream = GetEmbeddedResourceStream(assembly, resourceFileName);

            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }

        internal static void GetEmbeddedResourceString(object assemby)
        {
            throw new NotImplementedException();
        }
    }
}
