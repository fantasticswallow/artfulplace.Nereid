using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artfulplace.Nereid
{
    public class XmlUtility
    {
        public static string CreateXml(string elementName)
        {
            return $"<{elementName} />\n";
        }

        public static string CreateXml(string elementName, Dictionary<string, object> attributes)
        {
            var at = attributes.Where(x =>
            {
                if (x.Value.GetType().IsClass)
                {
                    return x.Value != null;
                }
                else
                {
                    return !x.Value.Equals(Activator.CreateInstance(x.GetType()));
                }
            }).Select(x => $"{x.Key}=\"{x.Value}\"").ToArray();
            return $"<{elementName} {string.Join(" ", at)} />\n";
        }

        public static string CreateXml(string elementName, Dictionary<string, string> attributes)
        {
            var at = attributes.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => $"{x.Key}=\"{x.Value}\"").ToArray();
            return $"<{elementName} {string.Join(" ", at)} />\n";
        }

        public static string CreateHeadXml(string elementName)
        {
            return $"<{elementName}>\n";
        }

        public static string CreateHeadXml(string elementName, Dictionary<string, object> attributes)
        {
            var at = attributes.Where(x =>
            {
                if (x.Value.GetType().IsClass)
                {
                    return x.Value != null;
                }
                else
                {
                    return x.Value != Activator.CreateInstance(x.GetType());
                }
            }).Select(x => $"{x.Key}=\"{x.Value}\"").ToArray();
            if (at.Length == 0)
            {
                return $"<{elementName}>\n";
            }

            return $"<{elementName} {string.Join(" ", at)}>\n";
        }

        public static string CreateHeadXml(string elementName, Dictionary<string, string> attributes)
        {
            var at = attributes.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => $"{x.Key}=\"{x.Value}\"").ToArray();
            return $"<{elementName} {string.Join(" ", at)}>\n";
        }

        public static string CreateFootXml(string elementName)
        {
            return $"</{elementName}>\n";
        }
    }
}
