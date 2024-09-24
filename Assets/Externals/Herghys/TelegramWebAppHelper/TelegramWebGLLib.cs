using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;

namespace Herghys.Telegram.WebGL
{
    public class TelegramWebGLLib
    {
        public static string Protocol { get { return location_protocol(); } }
        public static string Hostname { get { return location_hostname(); } }
        public static string Port { get { return location_port(); } }
        public static string Pathname { get { return location_pathname(); } }
        public static string Search { get { return location_search(); } set { location_set_search(value); } }
        public static string Hash { get { return location_hash(); } set { location_set_hash(value); } }

        public static string Host { get { return location_host(); } }
        public static string Origin { get { return location_origin(); } }
        public static string Href { get { return location_href(); } }

#if UNITY_WEBGL
    [DllImport("__Internal")] public static extern string location_protocol();
    [DllImport("__Internal")] public static extern string location_hostname();
    [DllImport("__Internal")] public static extern string location_port();
    [DllImport("__Internal")] public static extern string location_pathname();
    [DllImport("__Internal")] public static extern string location_search();
    [DllImport("__Internal")] public static extern string location_hash();
    [DllImport("__Internal")] public static extern string location_host();
    [DllImport("__Internal")] public static extern string location_origin();
    [DllImport("__Internal")] public static extern string location_href();

    [DllImport("__Internal")] public static extern void location_set_search(string aSearch);
    [DllImport("__Internal")] public static extern void location_set_hash(string aHash);
    [DllImport("__Internal")] public static extern string request_user_data();
#endif

#if UNITY_EDITOR
        private static string m_EmbeddedLib = @"
var URLParamLib = {
    location_protocol: function()
    {
        var str = window.location.protocol;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_hostname: function()
    {
        var str = window.location.hostname;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_port: function()
    {
        var str = window.location.port;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_pathname: function()
    {
        var str = window.location.pathname;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_search: function()
    {
        var str = window.location.search;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_hash: function()
    {
        var str = window.location.hash;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_host: function()
    {
        var str = window.location.host;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_origin: function()
    {
        var str = window.location.origin;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_href: function()
    {
        var str = window.location.href;
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },
    location_set_search: function(str)
    {
        window.location.search = Pointer_stringify(str);
    },
    location_set_hash: function(str)
    {
        window.location.hash = Pointer_stringify(str);
    },
};
mergeInto(LibraryManager.library, URLParamLib);
";

        [UnityEditor.InitializeOnLoadMethod]
        private static void ExtractJSLib()
        {
            var path = System.IO.Path.Combine(Application.dataPath, "Plugins");
            var folder = new System.IO.DirectoryInfo(path);
            if (!folder.Exists)
                folder.Create();
            path = System.IO.Path.Combine(path, "TelegramWebGLLibrary.jslib");
            if (System.IO.File.Exists(path))
                return;
            Debug.Log("URLParameters.jslib does not exist in the plugins folder, extracting");
            System.IO.File.WriteAllText(path, m_EmbeddedLib);
            UnityEditor.AssetDatabase.Refresh();
            UnityEditor.EditorApplication.RepaintProjectWindow();

        }
#endif
    }
}