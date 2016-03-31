﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;//<<--needed for Dictionary
using System.Data; //<<--in references
using System.Data.OleDb; //<<--provided by System.Data.DataSetExtensions.dll
using System.Diagnostics;//<<--needed for debug (visual studio IDE only)
using System.Drawing; //<<--in references
using System.IO;//<<--text file io for loading includes files
using System.Linq;//<<--provided by C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Data.Linq.dll
using System.Management; //<<--in references
using System.Reflection;
using System.Speech.Recognition;//<<-- provided by C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll
using System.Speech.Synthesis;
using System.Text; //<<--provided by mscorlib.dll
using System.Threading;
using System.Threading.Tasks;
using System.Web; //<<--in references
using System.Windows; //<<--in references
using System.Xml; //<<--in references
using Microsoft.CSharp; //<<--in system.dll

//<references:>System.Core.dll |System.Data.dll | System.dll | System.Drawing.dll | System.Management.dll | System.Web.dll | System.Windows.Forms.dll | System.Xml.dll | mscorlib.dll | C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Speech.dll | C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Data.Linq.dll
//=============================================================================
namespace VoiceBotScriptLevel1Diagnostics
    {
    //=========================================================================
    internal class Program
        {
        //---------------------------------------------------------------------
        public static bool s_isInDev = true;

        //---------------------------------------------------------------------
        public static void Level1Diagnostics(string[] args)
            {
            VoiceBotScript.Run(new IntPtr());
            }//</Level1Diagnostics(string[] args)>
        }/*</class::Program>*/

    //=========================================================================
    //*****************************************************************************

    #region Development Scaffolding Support Classes

    //=============================================================================
    //==Development Scaffolding Support Classes
    //=============================================================================
    /// <summary>
    /// developmental\\scaffolding stub for binary fortress services class while in development (outside of voicebot editor> ie visual studio (for intellisense and such purposes)
    /// </summary>
    namespace BFS
        {
        //=========================================================================
        public static class Dialog
            {
            public static void ShowMessageError(string str_message)
                {/*<stub>*/
                Debug.WriteLine(str_message);
                }/*</ShowMessageError()>*/
            }/*</class::Dialog>*/

             //=========================================================================
        public static class General
            {
            public static String GetAppInstallPath()
                {/*<stub>*/
                return ( "C:\\mnt\\W\\DevCore\\ProtoLab\\dotnet\\dotnet2k15\\Projects\\VoiceBotScript\\VoiceBotScript\\bin\\Debug" );
                }/*</GetAppInstallPath()>*/
            }/*</class::General>*/

             //=========================================================================
        public static class Input
            {
            public static void SendKeys(string str_key_sequence)
                {/*<stub>*/
                Debug.WriteLine("SendKeys::{KEYS}".Replace("{KEYS}", str_key_sequence));
                }/*</SendKeys(string str_message)>*/
            }/*</class::Input>*/

             //=========================================================================
        public static class Speech
            {
            public static void TextToSpeech(string str_message)
                {/*<stub>*/
                Debug.WriteLine(str_message);
                //
                using ( SpeechSynthesizer synth = new SpeechSynthesizer() )
                    {
                    // Configure the audio output.
                    synth.SetOutputToDefaultAudioDevice();
                    // Speak a string synchronously.
                    synth.Speak(str_message);
                    }//</using ( SpeechSynthesizer synth = new SpeechSynthesizer() )>
                }/*</TextToSpeech(string str_message)>*/
            }/*</class::Speech>*/

             //=========================================================================
        public class RegistryEntry : IEquatable<RegistryEntry>
            {
            public RegistryEntry(string str_key, string str_value)
                {
                Key = str_key;
                Dword = str_value;
                }//</RegistryEntry(string str_key, string str_value)>

            //---------------------------------------------------------------------
            public RegistryEntry()
                {; }//</RegistryEntry()>

            //---------------------------------------------------------------------
            public string Dword { get; set; }

            //---------------------------------------------------------------------
            private string key;

            public string Key
                {
                get
                    { return ( key ); }//</set>
                set
                    {
                    key = value;
                    Id = new DateTime().Millisecond;
                    }//</set>
                }//</Key>

                 //---------------------------------------------------------------------
            private int Id { get; set; }

            //---------------------------------------------------------------------
            public override string ToString()
                {
                return ( Dword );
                }//</ToString()>

                 //---------------------------------------------------------------------
            public override bool Equals(object obj)
                {
                bool bln_return = false;
                //
                if ( obj != null )
                    {
                    RegistryEntry objAsRegistryEntry = obj as RegistryEntry;
                    if ( objAsRegistryEntry != null )
                        { bln_return = Equals(objAsRegistryEntry); }
                    else {; }
                    //</if ( objAsRegistryEntry != null )>
                    }
                else {; }
                //</if ( obj != null )>
                return ( bln_return );
                }//</Equals(object obj)>

                 //---------------------------------------------------------------------
            public override int GetHashCode()
                {
                return Id;
                }//</GetHashCode()>

                 //---------------------------------------------------------------------
            public bool Equals(RegistryEntry other)
                {
                bool bln_return = false;
                if ( other != null )
                    { bln_return = ( this.Key.Equals(other.Key) ); }
                else {; }
                //</if ( other != null )>
                return ( bln_return );
                }//</Equals(RegistryEntry other)>

                 //---------------------------------------------------------------------
            }/*</class::RegistryEntry>*/

             //=========================================================================
        public static class ScriptSettings
            {
            private static List<RegistryEntry> lst_registry = new List<RegistryEntry>();

            //---------------------------------------------------------------------
            public static string ReadValue(string str_variable_name)
                { /*<stub>*/
                string str_return = "";
                int fnd = lst_registry.IndexOf(new RegistryEntry() { Key = str_variable_name });
                //
                if ( fnd != -1 )//>>>>>found, return
                    {
                    str_return = lst_registry[fnd].Dword;
                    }
                else//>>>>>return empty string, or static dev value (depending on need)
                    {
                    str_return = "";
                    }
                //</if ( fnd != -1 )>
                //>>>>>diagnostic output overrides, allow fixures to emulate "existing" registry values
                switch ( str_variable_name.ToLower() )
                    {
                case "includes_darklibs":
                str_return = "dXNpbmcgU3lzdGVtOw0KdXNpbmcgU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWM7Ly88PC0tbmVlZGVkIGZvciBEaWN0aW9uYXJ5DQp1c2luZyBTeXN0ZW0uRGF0YTsgLy88PC0taW4gcmVmZXJlbmNlcw0KdXNpbmcgU3lzdGVtLkxpbnE7Ly88PC0tcHJvdmlkZWQgYnkgQzpcXFByb2dyYW0gRmlsZXMgKHg4NilcXFJlZmVyZW5jZSBBc3NlbWJsaWVzXFxNaWNyb3NvZnRcXEZyYW1ld29ya1xcLk5FVEZyYW1ld29ya1xcdjQuMFxcUHJvZmlsZVxcQ2xpZW50XFxTeXN0ZW0uRGF0YS5MaW5xLmRsbA0KdXNpbmcgU3lzdGVtLkRhdGEuT2xlRGI7IC8vPDwtLXByb3ZpZGVkIGJ5IFN5c3RlbS5EYXRhLkRhdGFTZXRFeHRlbnNpb25zLmRsbA0KdXNpbmcgU3lzdGVtLkRpYWdub3N0aWNzOy8vPDwtLW5lZWRlZCBmb3IgZGVidWcgKHZpc3VhbCBzdHVkaW8gSURFIG9ubHkpDQp1c2luZyBTeXN0ZW0uVGhyZWFkaW5nOw0KdXNpbmcgU3lzdGVtLlRocmVhZGluZy5UYXNrczsNCnVzaW5nIFN5c3RlbS5EcmF3aW5nOyAvLzw8LS1pbiByZWZlcmVuY2VzDQp1c2luZyBTeXN0ZW0uTWFuYWdlbWVudDsgLy88PC0taW4gcmVmZXJlbmNlcw0KdXNpbmcgU3lzdGVtLlNwZWVjaC5SZWNvZ25pdGlvbjsvLzw8LS0gcHJvdmlkZWQgYnkgQzpcXFByb2dyYW0gRmlsZXMgKHg4NilcXFJlZmVyZW5jZSBBc3NlbWJsaWVzXFxNaWNyb3NvZnRcXEZyYW1ld29ya1xcLk5FVEZyYW1ld29ya1xcdjQuMFxcUHJvZmlsZVxcQ2xpZW50XFxTeXN0ZW0uU3BlZWNoLmRsbA0KdXNpbmcgU3lzdGVtLlNwZWVjaC5TeW50aGVzaXM7DQp1c2luZyBTeXN0ZW0uV2ViOyAvLzw8LS1pbiByZWZlcmVuY2VzDQp1c2luZyBTeXN0ZW0uV2luZG93czsgLy88PC0taW4gcmVmZXJlbmNlcw0KdXNpbmcgU3lzdGVtLlhtbDsgLy88PC0taW4gcmVmZXJlbmNlcw0KdXNpbmcgU3lzdGVtLkNvZGVEb20uQ29tcGlsZXI7DQp1c2luZyBTeXN0ZW0uUmVmbGVjdGlvbjsNCnVzaW5nIFN5c3RlbS5UZXh0OyAvLzw8LS1wcm92aWRlZCBieSBtc2NvcmxpYi5kbGwNCnVzaW5nIE1pY3Jvc29mdC5DU2hhcnA7IC8vPDwtLWluIHN5c3RlbS5kbGwNCg0KbmFtZXNwYWNlIEluY2x1ZGVzDQogICAgew0KICAgIC8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KICAgIA0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI3JlZ2lvbiBTY3JpcHRFbmdpbmUNCi8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCi8vPT0gU2NyaXB0RW5naW5lIEZ1bmN0aW9uIExpYnJhcnkNCi8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCi8vLyA8c3VtbWFyeT4NCi8vLyBBdXRob3I6IERhcmtzdHJ1bW46XGNyZWF0ZWQ6OjE2MDExNS4wMw0KLy8vIEZ1bmN0aW9uOiBkZWZpbmUgc3RhbmRhcmQgbGlicmFyeSBmdW5jdGlvbnMgLSBUaGUgVG9vbGJveCAtIA0KLy8vIHdpdGggdGhlIEdldEluY2x1ZGUgZnVuY3Rpb25hbGl0eSwgYWRkaXRpb25hbCBmdW5jdGlvbnMgY2FuIGJlIHN0b3JlZCBhcyB2YXJpYWJsZXMsDQovLy8gYW5kIGxvYWRlZCBkeW5hbWljYWxseSBmb3IgY29tbW9uIGxpYnJhcnkgZnVuY3Rpb25haXR5DQovLy8gPC9zdW1tYXJ5Pg0KcHVibGljIHN0YXRpYyBjbGFzcyBTY3JpcHRFbmdpbmUNCiAgew0KICAvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgLy8vIDxzdW1tYXJ5Pg0KICAvLy8gRXZhbCB0YWtlcyBwcm92aWRlZCBDUyBzb3VyY2UgYW5kIGF0dGVtcHRzIHRvIGNvbXBpbGUgY29kZSwgdGhlbiByZXR1cm5zIGFuIGluc3RhbmNlIG9iamVjdCBvZiB0aGUgYXNzZW1ibHkNCiAgLy8vIHZpYWJsZSBmb3IgbG9hZGluZyBhdXggc2NyaXB0cyB0byBmb3JtIGluY2x1ZGVzIG9yIGR5bmFtaWMgY29kZSBsb2FkaW5nDQogIC8vLyA8L3N1bW1hcnk+DQogIC8vLyA8cGFyYW0gbmFtZT0id2luZG93SGFuZGxlIj48L3BhcmFtPg0KICAvLy8gPHBhcmFtIG5hbWU9InN0cl9zb3VyY2VfY3MiPjwvcGFyYW0+DQogIC8vLyA8cGFyYW0gbmFtZT0ic3RyX3JlZmVyZW5jZXMiPjwvcGFyYW0+DQogIC8vLyA8cmV0dXJucz48L3JldHVybnM+DQogIHB1YmxpYyBzdGF0aWMgb2JqZWN0IEV2YWwoIEludFB0ciB3aW5kb3dIYW5kbGUsIHN0cmluZyBzdHJfc291cmNlX2NzLCBzdHJpbmcgc3RyX3JlZmVyZW5jZXMgPSAiIikNCiAgICB7ICANCiAgICBvYmplY3Qgb2JqX3JldHVybiA9IG51bGw7DQogICAgc3RyX3JlZmVyZW5jZXMgPSAoc3RyX3JlZmVyZW5jZXMuTGVuZ3RoICE9IDAgPyBzdHJfcmVmZXJlbmNlcyA6IFNjcmlwdENvcmUuSW5jbHVkZXMuU3VwcG9ydENsYXNzZXMuQ29uc3RhbnRzLnN0cl9kZWZhdWx0X3JlZmVyZW5jZXMpOw0KICAgIC8vDQogICAgLy9Db2RlRG9tUHJvdmlkZXIgcHJvdmlkZXIgPSBuZXcgQ1NoYXJwQ29kZVByb3ZpZGVyKG5ldyBEaWN0aW9uYXJ5PFN0cmluZywgU3RyaW5nPnt7ICJDb21waWxlclZlcnNpb24iLCJ2NC4wIiB9fSk7DQogICAgQ29kZURvbVByb3ZpZGVyIHByb3ZpZGVyID0gQ29kZURvbVByb3ZpZGVyLkNyZWF0ZVByb3ZpZGVyKCJDU2hhcnAiKTsNCiAgICAvLw0KICAgIENvbXBpbGVyUGFyYW1ldGVycyBjcF9jb21waWxlcl9wYXJhbXMgPSBuZXcgQ29tcGlsZXJQYXJhbWV0ZXJzKCk7DQogICAgLy8+Pj4+PmNvbXBpbGVpbmcgb3B0aW9ucyB0byBidWlsZCBjb2RlDQogICAgY3BfY29tcGlsZXJfcGFyYW1zLkNvbXBpbGVyT3B0aW9ucyA9ICIvdDpsaWJyYXJ5IjsvLzw8LS1jcmFmdCBhcyBsaWJyYXJ5IGRsbA0KICAgIGNwX2NvbXBpbGVyX3BhcmFtcy5HZW5lcmF0ZUV4ZWN1dGFibGUgID0gZmFsc2U7Ly88PC0tZG8gbm90IGNyYWZ0IGV4ZWN1dGFibGUNCiAgICBjcF9jb21waWxlcl9wYXJhbXMuR2VuZXJhdGVJbk1lbW9yeSA9IHRydWU7Ly88PC0tb3V0cHV0IGluIG1lbW1vcnkgdnMgb3V0cHV0IGZpbGUNCiAgICBjcF9jb21waWxlcl9wYXJhbXMuVHJlYXRXYXJuaW5nc0FzRXJyb3JzID0gZmFsc2U7Ly88PC0td2FybmluZyBoYW5kbGluZw0KICAgIHN0cl9yZWZlcmVuY2VzICs9IChzdHJfcmVmZXJlbmNlcy5MZW5ndGggPiAwID8gInwiIDogIiIpICsgIkM6XFxQcm9ncmFtIEZpbGVzICh4ODYpXFxWb2ljZUJvdFxcVm9pY2VCb3QuZXhlIjsNCiAgICBmb3JlYWNoKHN0cmluZyBzdHJfcmVmZXJlbmNlIGluIHN0cl9yZWZlcmVuY2VzLlNwbGl0KCd8JykpDQogICAgICB7DQogICAgICBjcF9jb21waWxlcl9wYXJhbXMuUmVmZXJlbmNlZEFzc2VtYmxpZXMuQWRkKHN0cl9yZWZlcmVuY2UuVHJpbSgpKTsNCiAgICAgIH0vLzwvZm9yZWFjaChzdHJpbmcgc3RyX3JlZmVyZW5jZSBpbiBzdHJfcmVmZXJlbmNlcy5TcGxpdCgnfCcpKT4NCiAgICAvLw0KICAgIFN0cmluZ0J1aWxkZXIgc2Jfc2NyaXB0X2NvcmUgPSBuZXcgU3RyaW5nQnVpbGRlcigiIik7Ly88PC0tbW9yZSBmbGV4aWJsZSB0aGFuIHN0cmluZyBjb25jYXRpbmF0aW9uIGlmIHdlIGFkZCBoYXJkY29kZWQgbGlicmFyeSBsb2dpYyBoZXJlDQogICAgLy8+Pj4+PlNjcmlwdENvcmUuSW5jbHVkZXMuSU5DTFVERV9DTEFTUy5JTkNMVURFX0ZVTkNUSU9ODQogICAgc2Jfc2NyaXB0X2NvcmUuQXBwZW5kKEAibmFtZXNwYWNlIFNjcmlwdENvcmUNCiAgICB7DQogICAgIiArIHN0cl9zb3VyY2VfY3MgKyBAIg0KICAgIH0vKjwvbmFtZXNwYWNlOjpTY3JpcHRDb3JlPiovDQogICAgIik7Ly88L3NiX3NjcmlwdF9jb3JlPg0KICAgIC8vLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KICAgIC8vPj4+Pj5hdHRlbXB0IHRvIGNvbXBpbGUNCiAgICBDb21waWxlclJlc3VsdHMgY3JfcmVzdWx0ID0gcHJvdmlkZXIuQ29tcGlsZUFzc2VtYmx5RnJvbVNvdXJjZShjcF9jb21waWxlcl9wYXJhbXMsIHNiX3NjcmlwdF9jb3JlLlRvU3RyaW5nKCkpOw0KICAgIC8vDQogICAgaWYoY3JfcmVzdWx0LkVycm9ycy5Db3VudCA+IDApLy8+Pj4+PnJlcG9ydCBlcnJvciwgYW5kIGZhaWwNCiAgICAgIHsNCiAgICAgIGZvcmVhY2goQ29tcGlsZXJFcnJvciBDb21wRXJyIGluIGNyX3Jlc3VsdC5FcnJvcnMpDQogICAgICAgIHsNCiAgICAgICAgQkZTLkRpYWxvZy5TaG93TWVzc2FnZUVycm9yKCJTb3VyY2U6XG57U09VUkNFfSIuUmVwbGFjZSgie1NPVVJDRX0iLHNiX3NjcmlwdF9jb3JlLlRvU3RyaW5nKCkpICk7DQogICAgICAgIEJGUy5EaWFsb2cuU2hvd01lc3NhZ2VFcnJvcigiRXZhbFxcXFxFUlJPUjogTGluZSBudW1iZXIge0xJTkV9LCBFcnJvciBOdW1iZXI6IHtOVU1CRVJ9LCAne1RFWFR9JyIuUmVwbGFjZSgie0xJTkV9IixDb21wRXJyLkxpbmUuVG9TdHJpbmcoKSkuUmVwbGFjZSgie05VTUJFUn0iLENvbXBFcnIuRXJyb3JOdW1iZXIpLlJlcGxhY2UoIntURVhUfSIsQ29tcEVyci5FcnJvclRleHQpICk7DQogICAgICAgIH0vLzwvZm9yZWFjaChDb21waWxlckVycm9yIENvbXBFcnIgaW4gY3JfcmVzdWx0LkVycm9ycyk+DQogICAgICB9DQogICAgZWxzZS8vPj4+Pj5leGVjdXRlIGNvZGUNCiAgICAgIHsNCiAgICAgIFN5c3RlbS5SZWZsZWN0aW9uLkFzc2VtYmx5IGFzc2VtYmx5X2xpYnJhcnlfY29kZSA9IGNyX3Jlc3VsdC5Db21waWxlZEFzc2VtYmx5Ow0KICAgICAgLy88bW92ZWQ+b2JqZWN0IG9ial9saWJyYXJ5X2NvZGVfaW5zdGFuY2UgPSBhc3NlbWJseV9saWJyYXJ5X2NvZGUuQ3JlYXRlSW5zdGFuY2UoIlNjcmlwdENvcmUuSW5jbHVkZXMiKTsNCiAgICAgIC8vb2JqX3JldHVybiA9IG9ial9saWJyYXJ5X2NvZGVfaW5zdGFuY2U7DQogICAgICBvYmpfcmV0dXJuID0gYXNzZW1ibHlfbGlicmFyeV9jb2RlOw0KICAgICAgfQ0KICAgIC8vPC9pZihjcl9yZXN1bHQuRXJyb3JzLkNvdW50ID4gMCk+DQogICAgcmV0dXJuKG9ial9yZXR1cm4pOw0KICAgIH0vKjwvRXZhbCggSW50UHRyIHdpbmRvd0hhbmRsZSwgc3RyaW5nIHN0cl9zb3VyY2VfY3MsIHN0cmluZyBzdHJfcmVmZXJlbmNlcyA9ICIiKT4qLw0KICAvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgLy8vIDxzdW1tYXJ5Pg0KICAvLy8gQ2FsbEZ1bmN0aW9uIGNhbGwgdGhlIGluY2x1ZGVkIGZ1bmN0aW9ucyBzcGVjaWZpZWQNCiAgLy8vIDwvc3VtbWFyeT4NCiAgLy8vIDxwYXJhbSBuYW1lPSJvYmpfbGlicmFyeV9jb2RlX2luc3RhbmNlIj48L3BhcmFtPg0KICAvLy8gPHBhcmFtIG5hbWU9InN0cl9mdW5jdGlvbl9uYW1lIj48L3BhcmFtPg0KICAvLy8gPHBhcmFtIG5hbWU9Im9ial9wYXJhbWV0ZXJzX2FycmF5Ij48L3BhcmFtPg0KICAvLy8gPHJldHVybnM+PC9yZXR1cm5zPg0KICBwdWJsaWMgc3RhdGljIG9iamVjdCBDYWxsRnVuY3Rpb24oT2JqZWN0IGFzc2VtYmx5X2xpYnJhcnlfY29kZSwgc3RyaW5nIHN0cl9mdW5jdGlvbl9uYW1lLCBvYmplY3RbXSBvYmpfcGFyYW1ldGVyc19hcnJheSkNCiAgCXsNCiAgICAvLw0KICAgIHZhciBvYmpfbGlicmFyeV9jb2RlX2luc3RhbmNlID0gKChBc3NlbWJseSlhc3NlbWJseV9saWJyYXJ5X2NvZGUpLkNyZWF0ZUluc3RhbmNlKCJTY3JpcHRDb3JlLkluY2x1ZGVzLiIgKyBzdHJfZnVuY3Rpb25fbmFtZSk7DQogICAgLy88ZGlhZ25vc3RpY3M+VHlwZVtdIG9ial9saWJyYXJ5X3R5cGVzID0gKChBc3NlbWJseSlhc3NlbWJseV9saWJyYXJ5X2NvZGUpLkdldFR5cGVzKCk7DQogICAgVHlwZSB0eXBlX2luc3RhbmNlX3R5cGUgPSBvYmpfbGlicmFyeV9jb2RlX2luc3RhbmNlLkdldFR5cGUoKTsNCiAgICB2YXIgbWV0aG9kX2luZm8gPSB0eXBlX2luc3RhbmNlX3R5cGUuR2V0TWV0aG9kKHN0cl9mdW5jdGlvbl9uYW1lKTsNCiAgICAvLw0KICAgIG9iamVjdCBvYmpfcmV0dXJuID0gbWV0aG9kX2luZm8uSW52b2tlKG9ial9saWJyYXJ5X2NvZGVfaW5zdGFuY2UsIG9ial9wYXJhbWV0ZXJzX2FycmF5KTsgICAgDQogIAlyZXR1cm4ob2JqX3JldHVybik7DQogIAl9Ly88L0NhbGxGdW5jdGlvbihPYmplY3Qgb2JqX2xpYnJhcnlfY29kZV9pbnN0YW5jZSwgc3RyX2Z1bmN0aW9uX25hbWUsIG9iamVjdFtdIG9ial9wYXJhbWV0ZXJzX2FycmF5KT4NCiAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgLy8vIDxzdW1tYXJ5Pg0KICAvLy8gR2V0SW5jbHVkZSBpcyBhbiBhbGlhcyB0byB0aGUgbG9hZGluZyBvZiBpbmNsdWRlcy4gU3RvcmUgdW5ib3hlZCBvYmplY3QgdG8gaW5zdGFuY2UgdmFyaWFibGUgYW5kIHVzZSBpdCB3aXRoIHRoZSBDYWxsRnVuY3Rpb24NCiAgLy8vIGZ1bmN0aW9uIHRvIGNhbGwgdGhlIGluY2x1ZGVkIGZ1bmN0aW9ucw0KICAvLy8gPC9zdW1tYXJ5Pg0KICAvLy8gPHBhcmFtIG5hbWU9IndpbmRvd0hhbmRsZSI+PC9wYXJhbT4NCiAgLy8vIDxwYXJhbSBuYW1lPSJzdHJfaW5jbHVkZSI+PC9wYXJhbT4NCiAgLy8vIDxwYXJhbSBuYW1lPSJzdHJfcmVmZXJlbmNlcyI+PC9wYXJhbT4NCiAgLy8vIDxyZXR1cm5zPjwvcmV0dXJucz4NCiAgcHVibGljIHN0YXRpYyBvYmplY3QgR2V0SW5jbHVkZShJbnRQdHIgd2luZG93SGFuZGxlLCBzdHJpbmcgc3RyX2luY2x1ZGUsc3RyaW5nIHN0cl9yZWZlcmVuY2VzID0gIiIpDQogICAgew0KICAgIHN0cl9yZWZlcmVuY2VzID0gKHN0cl9yZWZlcmVuY2VzLkxlbmd0aCAhPSAwID8gc3RyX3JlZmVyZW5jZXMgOiBTY3JpcHRDb3JlLkluY2x1ZGVzLlN1cHBvcnRDbGFzc2VzLkNvbnN0YW50cy5zdHJfZGVmYXVsdF9yZWZlcmVuY2VzKTsNCiAgICBzdHJpbmcgc3RyX2NvZGUgPSBTeXN0ZW0uVGV4dC5FbmNvZGluZy5VVEY4LkdldFN0cmluZyhDb252ZXJ0LkZyb21CYXNlNjRTdHJpbmcoQkZTLlNjcmlwdFNldHRpbmdzLlJlYWRWYWx1ZShzdHJfaW5jbHVkZSkpKTsNCiAgICB2YXIgb2JqX2luY2x1ZGUgPSBTY3JpcHRFbmdpbmUuRXZhbCh3aW5kb3dIYW5kbGUsIHN0cl9jb2RlLHN0cl9yZWZlcmVuY2VzKTsNCiAgICByZXR1cm4oKG9iamVjdClvYmpfaW5jbHVkZSk7DQogICAgfS8vPC9HZXRJbmNsdWRlKEludFB0ciB3aW5kb3dIYW5kbGUsIHN0cmluZyBzdHJfaW5jbHVkZSxzdHJpbmcgc3RyX3JlZmVyZW5jZXMgPSAiIik+DQogIC8vLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQogIH0vKjwvY2xhc3M6OlNjcmlwdEVuZ2luZT4qLw0KICAgLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KICAgLy89PSAvU2NyaXB0RW5naW5lIEZ1bmN0aW9uIExpYnJhcnkNCiAgIC8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCiAgICAjZW5kcmVnaW9uDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQojcmVnaW9uIFNwZWVjaA0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KLy89PSBTcGVlY2ggRnVuY3Rpb24gTGlicmFyeQ0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KLy8vIDxzdW1tYXJ5Pg0KLy8vIFNwZWVjaCBmdW5jdGlvbiBsaWJyYXJ5IHByb3ZpZGluZyBleHBhbmRlZCBmdW5jdGlvbmFsaXR5LCBzdWNoIGFzIHZvaWNlDQovLy8gcmVjb2duaXRpb24sIGV0Yy4NCi8vLyB1c2luZyBTeXN0ZW0uU3BlZWNoLlJlY29nbml0aW9uOyAvLzw8LS1uZWVkcyBDOlxcUHJvZ3JhbSBGaWxlcyAoeDg2KVxcUmVmZXJlbmNlIEFzc2VtYmxpZXNcXE1pY3Jvc29mdFxcRnJhbWV3b3JrXFwuTkVURnJhbWV3b3JrXFx2NC4wXFxQcm9maWxlXFxDbGllbnRcXFN5c3RlbS5TcGVlY2guZGxsDQovLy8gdXNpbmcgU3lzdGVtLlNwZWVjaC5TeW50aGVzaXM7DQovLy8gPC9zdW1tYXJ5Pg0KcHVibGljIHN0YXRpYyBjbGFzcyBTcGVlY2gNCiAgICB7DQogICAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgICAvLy8gPHN1bW1hcnk+DQogICAgLy8vIFNwZWVjaFJlY29nbml6ZXIgcHJvdmlkZSB2b2ljZSBwcm9tcHRzLCB3aGVyZSB0aGUgdXNlciBjYW4gYmUgcHJvbXB0ZWQNCiAgICAvLy8gYXVyYWxseSB0byByZXNwb25kIHZlcmJhbGx5IGFuZCB0aGUgcmVzcG9uc2UgaXMgY29udmVydGVkIHRvIHN0cmluZyBhbmQNCiAgICAvLy8gcmV0dXJuZWQgZm9yIGZ1cnRoZXIgcHJvY2Vzc2luZw0KICAgIC8vLyA8L3N1bW1hcnk+DQogICAgLy8vIDxwYXJhbSBuYW1lPSJzdHJfdm9pY2VfcHJvbXB0Ij48L3BhcmFtPg0KICAgIC8vLyA8cmV0dXJucz48L3JldHVybnM+DQogICAgcHVibGljIHN0YXRpYyBzdHJpbmcgU3BlZWNoUmVjb2duaXplcihzdHJpbmcgc3RyX3ZvaWNlX3Byb21wdCkNCiAgICB7DQogICAgc3RyaW5nIHN0cl9yZXR1cm4gPSAiIjsNCiAgICBTcGVlY2hSZWNvZ25pdGlvbkVuZ2luZSByZWNvZ25pemVyID0gbmV3IFNwZWVjaFJlY29nbml0aW9uRW5naW5lKCk7DQogICAgR3JhbW1hciBkaWN0YXRpb25HcmFtbWFyID0gbmV3IERpY3RhdGlvbkdyYW1tYXIoKTsNCiAgICByZWNvZ25pemVyLkxvYWRHcmFtbWFyKGRpY3RhdGlvbkdyYW1tYXIpOw0KICAgIEJGUy5TcGVlY2guVGV4dFRvU3BlZWNoKHN0cl92b2ljZV9wcm9tcHQpOw0KICAgIC8vDQogICAgdHJ5DQoJICAgIHsNCgkgICAgcmVjb2duaXplci5TZXRJbnB1dFRvRGVmYXVsdEF1ZGlvRGV2aWNlKCk7DQoJICAgIFJlY29nbml0aW9uUmVzdWx0IHJlc3VsdCA9IHJlY29nbml6ZXIuUmVjb2duaXplKCk7DQoJICAgIGlmKHJlc3VsdCAhPSBudWxsKXtzdHJfcmV0dXJuID0gcmVzdWx0LlRleHQ7fWVsc2V7O30NCgkgICAgLy88ZGlhZ25vc3RpY3M+QkZTLlNwZWVjaC5UZXh0VG9TcGVlY2gocmVzdWx0LlRleHQpOw0KCSAgICB9DQogICAgY2F0Y2ggKEludmFsaWRPcGVyYXRpb25FeGNlcHRpb24gZXhjZXB0aW9uKQ0KCSAgICB7DQoJICAgIEJGUy5EaWFsb2cuU2hvd01lc3NhZ2VFcnJvcigiRXJyb3IgZGV0ZWN0ZWQgZHVyaW5nIHNvdW5kIGFjcXVpc2l0aW9uOiB7U09VUkNFfSAtIHtNRVNTQUdGfS4iLlJlcGxhY2UoIntTT1VSQ0V9IixleGNlcHRpb24uU291cmNlKS5SZXBsYWNlKCJ7TUVTU0FHRn0iLGV4Y2VwdGlvbi5NZXNzYWdlKSk7DQoJICAgIH0NCiAgICBmaW5hbGx5DQoJICAgIHsNCgkgICAgcmVjb2duaXplci5VbmxvYWRBbGxHcmFtbWFycygpOw0KCSAgICB9Ly88L3RyeT4NCiAgICByZXR1cm4gKHN0cl9yZXR1cm4pOw0KICAgIH0vLzwvU3BlYWNoUmVjb2duaXplcigpPg0KLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCn0vKjwvY2xhc3MgU3BlZWNoPiovDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLz09IC9TcGVlY2ggRnVuY3Rpb24gTGlicmFyeQ0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI2VuZHJlZ2lvbg0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI3JlZ2lvbiBGeExpYg0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KLy89PSBGeExpYiBGdW5jdGlvbiBMaWJyYXJ5DQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLy8gPHN1bW1hcnk+DQovLy8gQXV0aG9yOiBEYXJrc3RydW1uOlxjcmVhdGVkOjoxNjAxMDUuMjENCi8vLyBGdW5jdGlvbjogZGVmaW5lIHN0YW5kYXJkIGxpYnJhcnkgZnVuY3Rpb25zIC0gVGhlIFRvb2xib3gNCi8vLyB3aXRoIHRoZSBTY3JpcHRFbmdpbmUgR2V0SW5jbHVkZSBmdW5jdGlvbmFsaXR5LCBhZGRpdGlvbmFsIGZ1bmN0aW9ucyBjYW4gYmUgc3RvcmVkIGFzIHZhcmlhYmxlcywNCi8vLyBhbmQgbG9hZGVkIGR5bmFtaWNhbGx5IGZvciBjb21tb24gbGlicmFyeSBmdW5jdGlvbmFpdHkNCi8vLyA8L3N1bW1hcnk+DQpwdWJsaWMgc3RhdGljIGNsYXNzIEZ4TGliDQogICAgew0KICAgIC8vLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQogICAgcHVibGljIHN0YXRpYyBTY3JpcHRDb3JlLkluY2x1ZGVzLlN1cHBvcnRDbGFzc2VzLkFyZ3MgR2V0QXJncyhzdHJpbmcgc3RyX3ZhcmlhYmxlX25hbWUpDQogICAgew0KICAgIHZhciBhcmdzX3JldHVybiA9IG5ldyBTY3JpcHRDb3JlLkluY2x1ZGVzLlN1cHBvcnRDbGFzc2VzLkFyZ3MoKTsNCiAgICBzdHJpbmcgc3RyX2tleTsNCiAgICBzdHJpbmcgc3RyX3ZhbHVlOw0KICAgIEJGUy5TcGVlY2guVGV4dFRvU3BlZWNoKCJEaWFnbm9zdGljczo6QkZTLlNjcmlwdFNldHRpbmdzLlJlYWRWYWx1ZSgiICsgc3RyX3ZhcmlhYmxlX25hbWUgKyAiKSIgKyBCRlMuU2NyaXB0U2V0dGluZ3MuUmVhZFZhbHVlKHN0cl92YXJpYWJsZV9uYW1lKSk7DQogICAgdHJ5IHsNCiAgICAgICAgZm9yZWFjaCAoIHN0cmluZyBlbGVtZW50IGluIEJGUy5TY3JpcHRTZXR0aW5ncy5SZWFkVmFsdWUoc3RyX3ZhcmlhYmxlX25hbWUpLlNwbGl0KCd8JykgKQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgc3RyX2tleSA9IGVsZW1lbnQuU3BsaXQoJywnKVswXTsNCiAgICAgICAgICAgIHN0cl92YWx1ZSA9ICggZWxlbWVudC5TcGxpdCgnLCcpLkxlbmd0aCA+IDEgPyBlbGVtZW50LlJlcGxhY2Uoc3RyX2tleSArICIsIiwiIikgOiBlbGVtZW50ICk7DQogICAgICAgICAgICBhcmdzX3JldHVybi5hcmd2LkFkZChhcmdzX3JldHVybi5hcmdjLCBuZXcgU2NyaXB0Q29yZS5JbmNsdWRlcy5TdXBwb3J0Q2xhc3Nlcy5BcmcoKSB7IGtleSA9IHN0cl9rZXksIHZhbHVlID0gc3RyX3ZhbHVlIH0pOw0KICAgICAgICAgICAgfSANCiAgICAgICAgfQ0KICAgICBjYXRjaChFeGNlcHRpb24gRXJyb3IpDQogICAgICAgIHsNCiAgICAgICAgQkZTLkRpYWxvZy5TaG93TWVzc2FnZUVycm9yKCIhISFHZXRBcmdzXFxcXEVycm9yOjoiICsgRXJyb3IuTWVzc2FnZSk7Lyo8PC0tZGVmYXVsdCBpZiBub3QgZGVmaW5lZCovDQogICAgICAgIEJGUy5TcGVlY2guVGV4dFRvU3BlZWNoKCIhISFHZXRBcmdzXFxcXEVycm9yOjoiICsgRXJyb3IuTWVzc2FnZSk7DQogICAgICAgIH0NCiAgICByZXR1cm4gKCBhcmdzX3JldHVybiApOw0KICAgIH0vKjwvR2V0QXJncyhzdHJpbmcgc3RyX3ZhcmlhYmxlX25hbWUpPiovDQogICAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgICAvLy8gPHN1bW1hcnk+DQogICAgLy8vIGJhc2ljIHNlcmlhbGl6YXRpb246IHRoZSBkZXZlbG9wZXIgaXMgcmVzcG9uc2libGUgZm9yIGRvY3VtZW50aW5nIHRoZSBwYXJhbWV0ZXIgbGlzdCBhcyB0aGlzDQogICAgLy8vIHN1cHBvcnRzIHBvc2l0aW9uIGJhc2VkIGFyZ3MsIG5vdCBleGFjdGx5IG5hbWUgYmFzZWQsIGJ1dCBjYW4gYmUgZXhwYW5kZWQgdG8gZWFzaWx5Lg0KICAgIC8vLyBleGFtcGxlOg0KICAgIC8vLyBGeExpYi5TYXZlQXJncygiTXlTY3JpcHQiLCgiaGVsbG98d29ybGQiKS5TcGxpdCgnfCcpKTsgLy88PC0td2lsbCBzYXZlIHRoZSAyIGVsZW1lbnQgYXJyYXkgWyJoZWxsbyIsIndvcmxkIl0NCiAgICAvLy8gYXMgYSBzZXJpYWxpemVkIHN0cmluZyAiaGVsbG98d29ybGQiIGluIHRoZSByZWdpc3RyeSBmb3IgbGF0ZXIgZXh0cmFjdGlvbiBieSB0aGUgaW50ZW5kZWQgbWFjcm8uDQogICAgLy8vIDwvc3VtbWFyeT4NCiAgICBwdWJsaWMgc3RhdGljIHZvaWQgU2F2ZUFyZ3Moc3RyaW5nIHN0cl92YXJpYWJsZV9uYW1lLCBMaXN0PHN0cmluZz4gbHN0X2NvbnRlbnQpDQogICAgew0KICAgIHN0cmluZyBzdHJfY29udGVudCA9ICIiOy8vPDwtLWRlZmF1bHQgdG8gZGVsZXRpbmcgdmFyaWFibGUgdmFsdWUNCiAgICBzdHJpbmdbXSBhcnJfc3RyX2NvbnRlbnQgPSBsc3RfY29udGVudC5Ub0FycmF5KCk7DQogICAgLy8NCiAgICBpZiAoIGFycl9zdHJfY29udGVudCAhPSBudWxsICkvLz4+Pj4+c2VyaWFsaXplDQogICAgICAgIHsNCiAgICAgICAgZm9yZWFjaCAoIHN0cmluZyBzdHJfaXRlbSBpbiBhcnJfc3RyX2NvbnRlbnQgKQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgc3RyX2NvbnRlbnQgKz0gKCBzdHJfY29udGVudC5MZW5ndGggPiAwID8gInwiIDogIiIgKSArIHN0cl9pdGVtOw0KICAgICAgICAgICAgfS8vPC9mb3JlYWNoIChzdHJpbmcgc3RyX2l0ZW0gaW4gYXJyX3N0cl9jb250ZW50KT4NCiAgICAgICAgfQ0KICAgIGVsc2UgeyBzdHJfY29udGVudCA9ICJOVUxMIjsgfS8vPDwtLWRvIG5vdGhpbmcNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIC8vPC8+DQogICAgQkZTLlNjcmlwdFNldHRpbmdzLldyaXRlVmFsdWUoc3RyX3ZhcmlhYmxlX25hbWUsIHN0cl9jb250ZW50KTsNCiAgICB9Lyo8L1NhdmVBcmdzKHN0cmluZyBzdHJfdmFyaWFibGVfbmFtZSwgTGlzdDxzdHJpbmc+IGxzdF9jb250ZW50KT4qLw0KICAgIC8vLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KICAgIH0vKjwvY2xhc3M6OkZ4TGliPiovDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLz09IC9GeExpYiBGdW5jdGlvbiBMaWJyYXJ5DQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQojZW5kcmVnaW9uDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQojcmVnaW9uIFN1cHBvcnQgQ2xhc3Nlcw0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KLy89PSBTdXBwb3J0IENsYXNzZXMNCi8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCm5hbWVzcGFjZSBTdXBwb3J0Q2xhc3Nlcw0KICAgIHsNCiAgICAjcmVnaW9uIENvbnN0YW50cw0KICAgIC8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCiAgICBwdWJsaWMgc3RhdGljIGNsYXNzIENvbnN0YW50cw0KICAgICAgICB7DQogICAgICAgIHB1YmxpYyBzdGF0aWMgc3RyaW5nIHN0cl9kZWZhdWx0X3JlZmVyZW5jZXMgPSAiU3lzdGVtLkNvcmUuZGxsIHxTeXN0ZW0uRGF0YS5kbGwgfCBTeXN0ZW0uZGxsIHwgU3lzdGVtLkRyYXdpbmcuZGxsIHwgU3lzdGVtLk1hbmFnZW1lbnQuZGxsIHwgU3lzdGVtLldlYi5kbGwgfCBTeXN0ZW0uV2luZG93cy5Gb3Jtcy5kbGwgfCBTeXN0ZW0uWG1sLmRsbCB8IG1zY29ybGliLmRsbCB8IEM6XFxQcm9ncmFtIEZpbGVzICh4ODYpXFxSZWZlcmVuY2UgQXNzZW1ibGllc1xcTWljcm9zb2Z0XFxGcmFtZXdvcmtcXC5ORVRGcmFtZXdvcmtcXHY0LjBcXFByb2ZpbGVcXENsaWVudFxcU3lzdGVtLlNwZWVjaC5kbGwgfCBDOlxcUHJvZ3JhbSBGaWxlcyAoeDg2KVxcUmVmZXJlbmNlIEFzc2VtYmxpZXNcXE1pY3Jvc29mdFxcRnJhbWV3b3JrXFwuTkVURnJhbWV3b3JrXFx2NC4wXFxQcm9maWxlXFxDbGllbnRcXFN5c3RlbS5EYXRhLkxpbnEuZGxsIjsNCiAgICAgICAgcHVibGljIHN0YXRpYyBzdHJpbmcgc3RyX2RlZmF1bHRfY29ubmVjdGlvbl9zdHJpbmcgPSAiUHJvdmlkZXI9J01pY3Jvc29mdC5BQ0UuT0xFREIuMTIuMCc7IERhdGEgU291cmNlPSdDOlxcbW50XFxXXFxEZXZDb3JlXFxQcm90b0xhYlxcZG90bmV0XFxkb3RuZXQyazE1XFxQcm9qZWN0c1xcVm9pY2VCb3RTY3JpcHRcXFZvaWNlQm90U2NyaXB0XFxiaW5cXERlYnVnXFxTY3JpcHRFeHRlbnNpb25cXExvZ0Jvb2subWRiJzsgUGVyc2lzdCBTZWN1cml0eSBJbmZvPUZhbHNlIjsNCiAgICAgICAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgICAgICAgfS8qPC9jbGFzcyBDb25zdGFudHMoKT4qLw0KICAgICNlbmRyZWdpb24NCiAgICAvLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQogICAgLy8vIDxzdW1tYXJ5Pg0KICAgIC8vLyBBdXRob3I6IERhcmtzdHJ1bW46XGNyZWF0ZWQ6OjE2MDEwNS4yMQ0KICAgIC8vLyBGdW5jdGlvbjogZGVmaW5lIGhlbHBlciBkYXRhdHlwZSBjbGFzczo6QXJncywgZm9yIElQQyBhZ3VtZW50XFxkYXRhIHBhc3NpbmdcXHN0b3JhZ2UNCiAgICAvLy8gPC9zdW1tYXJ5Pg0KICAgIHB1YmxpYyBjbGFzcyBBcmcNCiAgICAgICAgew0KICAgICAgICBwdWJsaWMgc3RyaW5nIGtleSB7IGdldDsgc2V0OyB9Ly88L2FyZz4NCiAgICAgICAgcHVibGljIHN0cmluZyB2YWx1ZSB7IGdldDsgc2V0OyB9Ly88L3ZhbHVlPg0KICAgICAgICAvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KICAgICAgICBwdWJsaWMgIEFyZygpDQogICAgICAgICAgICB7O30vLzwvQXJnKCk+DQogICAgICAgIH0vKjwvY2xhc3M6OkFyZz4qLw0KICAgIC8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCiAgICBwdWJsaWMgY2xhc3MgQXJncw0KICAgICAgICB7DQogICAgICAgIC8vLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KICAgICAgICBwdWJsaWMgQXJncygpDQogICAgICAgICAgICB7DQogICAgICAgICAgICBhcmd2ID0gbmV3IERpY3Rpb25hcnk8aW50LCBTY3JpcHRDb3JlLkluY2x1ZGVzLlN1cHBvcnRDbGFzc2VzLkFyZz4oKTsvLzw8LS1pbml0IGRpY3Rpb25hcnkNCiAgICAgICAgICAgIH0vLzwvQXJncygpPg0KICAgICAgICAvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgICAgICAgcHVibGljIERpY3Rpb25hcnk8aW50LEFyZz4gYXJndiB7IGdldDsgc2V0OyB9Ly88L2FyZz4NCiAgICAgICAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQogICAgICAgIHB1YmxpYyBpbnQgYXJnYw0KICAgICAgICAgICAgew0KICAgICAgICAgICAgZ2V0DQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIGludCBpbnRfc2l6ZSA9IDA7DQogICAgICAgICAgICAgICAgLy8NCiAgICAgICAgICAgICAgICBpZiAoIGFyZ3YgIT0gbnVsbCApDQogICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgLy8NCiAgICAgICAgICAgICAgICAgICAgaWYgKCAoIGFyZ3YuQ291bnQgPT0gMSApICYmICggYXJndlswXS5rZXkgPT0gIk5VTEwiICkgKQ0KICAgICAgICAgICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICAgICAgaW50X3NpemUgPSAwOw0KICAgICAgICAgICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgICAgICBlbHNlDQogICAgICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICBpbnRfc2l6ZSA9ICggYXJndi5Db3VudCA9PSAxID8gKCBhcmd2WzBdLmtleS5MZW5ndGggPiAwID8gYXJndi5Db3VudCA6IDAgKSA6IGFyZ3YuQ291bnQgKTsNCiAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgLy88L2lmICggKCBhcmd2Lkxlbmd0aCA9PSAxICkgJiYgKCBhcmd2WzBdID09ICJOVUxMIiApICk+DQogICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICBlbHNlIHs7IH0NCiAgICAgICAgICAgICAgICAvLzwvaWYgKGFyZ3YgIT0gbnVsbCk+DQogICAgICAgICAgICAgICAgcmV0dXJuICggaW50X3NpemUgKTsNCiAgICAgICAgICAgICAgICB9Ly88L2dldD4NCiAgICAgICAgICAgIH0vLzwvYXJnYz4NCiAgICAgICAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQogICAgICAgIH0vKjwvY2xhc3M6OkFyZ3M+Ki8NCiAgICB9Lyo8L25hbWVzcGFjZTo6U3VwcG9ydENsYXNzZXM+Ki8NCi8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCi8vPT0gL1N1cHBvcnQgQ2xhc3Nlcw0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI2VuZHJlZ2lvbg0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI3JlZ2lvbiBTaGlwIE1vZGVsIENsYXNzZXMNCi8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCi8vPT0gU2hpcCBNb2RlbCBDbGFzc2VzDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLy8gPHN1bW1hcnk+DQovLy8gQXV0aG9yOiBEYXJrc3RydW1uOlxjcmVhdGVkOjoxNjAxMTIuMTINCi8vLyBGdW5jdGlvbjogbW9kZWwgc2hpcCBzeXN0ZW0gc3RhdGUuIHZvaWNlYm90IHN0b3JlcyB2YXJzIGluIHJlZ2lzdHJ5IGFzIGENCi8vLyBzdHJpbmcsIHNvIHdlIHdpbGwgdXNlIG9uZSBzdHJpbmcgdG8gc3RvcmUgdGhlIHN0YXRlIG9mIHRoZSBzaGlwLCB2cy4gbXVsdGlwbGUNCi8vLyA8L3N1bW1hcnk+DQpwdWJsaWMgc3RhdGljIGNsYXNzIFNoaXBNb2RlbA0KICAgIHsNCiAgICAvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgICBwdWJsaWMgc3RhdGljIHZvaWQgUmVzZXRTaGlwU3RhdGUoKQ0KICAgICAgICB7DQogICAgICAgIFNjcmlwdENvcmUuSW5jbHVkZXMuU3VwcG9ydENsYXNzZXMuQXJncyBhcmdzX3NoaXBfc3RhdGUgPSBGeExpYi5HZXRBcmdzKCJzaGlwX3N0YXRlIik7DQogICAgICAgIHN0cmluZ1ssXSBhcnJfc2hpcF9zdGF0ZSA9IG5ldyBzdHJpbmdbLF0gew0KeyAic2hpcE5hbWUiLCAiRElOIEthJ3BsYSIgfSAvLzw8LS1uYW1lDQoseyJjYXJnb1Njb29wIiwiMCIgfSAvLzw8LS1jYXJnbyBzY29vcCBkZXBsb3llZA0KLHsibGFuZGluZ0dlYXIiLCIwIiB9IC8vPDwtLWxhbmRpbmcgZ2VhciBkZXBsb3llZA0KLHsiZXh0ZXJuYWxMaWdodHMiLCIwIiB9IC8vPDwtLXNoaXAgbGlnaHRzIGRlcGxveWVkDQoseyJmbGlnaHRBc3Npc3QiLCIxIiB9IC8vPDwtLWZsaWdodCBhc3Npc3QNCix7ImhhcmRwb2ludHMiLCIwIiB9IC8vPDwtLWhhcmRwb2ludHMgZGVwbG95ZWQNCix7InNpbGVudFJ1bm5pbmciLCIwIiB9IC8vPDwtLXNpbGVudCBydW5uaW5nDQoseyJhY3RpdmVGaXJlZ3JvdXAiLCIwIiB9IC8vPDwtLWFjdGl2ZSBmaXJlIGdyb3VwDQoseyJzaGlwVHlwZSIsIjgiIH0gLy88PC0tc2hpcCB0eXBlIGlkICh1c2VkIHRvIHNldCBwcm9wZXJ0aWVzIHN1Y2ggYXMgbnVtYmVyIG9mIHNsb3RzIGZvciBNb2R1bGVzIGFuZCBzdWNoDQoseyJtb2R1bGVzIiwiMjAiIH0gLy88PC0tbW9kdWxlcyAobnVtYmVyIG9mIG1vZHVsZSBzbG90cykNCix7ImZpcmVnb3VwcyIsIjUiIH0gLy88PC0tZmlyZSBncm91cHMgKG51bWJlciBvZiBmaXJlIGdyb3VwcywgZGVmYXVsdCA1KQ0KLHsicmVmaW5lcnlCaW5zIiwiNSIgfSAvLzw8LS1yZWZpbmFyeSBwcmVzZW50ICh2YWx1ZSBpcyBudW1iZXIgb2YgaG9wcGVyIGJpbnMgYXZpbGFibGUpDQoseyJzeXN0ZW1zUG93ZXIiLCIyIiB9IC8vPDwtLXN5c3RlbXMgKHBvd2VyIGRpc3RyaWJ1dGlvbiBzdGF0ZSkNCix7ImVuZ2luZXNQb3dlciIsIjIiIH0gLy88PC0tZW5naW5lcyAocG93ZXIgZGlzdHJpYnV0aW9uIHN0YXRlKQ0KLHsid2VhcG9uc1Bvd2VyIiwiMiIgfSAvLzw8LS13ZWFwb25zIChwb3dlciBkaXN0cmlidXRpb24gc3RhdGUpDQoseyJ0dXJyZXRNb2RlIiwiMiIgfSAvLzw8LS10dXJyZXQgd2VhcG9ucyBtb2RlICgxPWZpeGVkLCAyPXRhcmdldCBvbmx5LCAzPWZpcmUgYXQgd2lsbCAoZGVmYXVsdCAyKSkNCix7ImJlYWNvbiIsIjAiIH0gLy88PC0tYmVhY29uICgwPW9mZiwgMT13aW5nIChkZWZ1bHQgMCkpDQoseyJjb25maXJtYXRpb24iLCIwIiB9IC8vPDwtLWV4cGVjdGluZyBjb25maXJtYXRpb24gKDA9bm8sIDE9eWVzKSB1c2VkIHRvIGlnbm9yZSBjb25maXJtYXRpb24gcmVzcG9uc2UgdHJpZ2dlcnMgaWYgdW5leHBlY3RlZA0KLHsiamV0dGlzb24iLCIwIiB9IC8vPDwtLWpldHRpc29uIGFsbCBjYXJnbyAoMD1ubywgMT1jb25maXJtaW5nLCAyPSBjb21taXQpDQp9Ow0KICAgICAgICBzdHJpbmdbLF0gYXJyX3NoaXBfc2NyZWVuc19zdGF0ZSA9IG5ldyBzdHJpbmdbLF0gew0KeyAiMSIsICIwIn0gLy88PC0tc2NyZWVuMS10YXJnZXQgdGFiKGxlZnRSaWdodCkgaW5kZXgNCix7ICIxLjEueSIsICIyIn0gLy88PC0tc3Vic2NyZWVuIDEgdGFiIDFcXE5hdmlnYXRpb24gdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIxLjEueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDEgdGFiIDFcXE5hdmlnYXRpb24gbGVmdFJpZ2h0IHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIxLjIueSIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDEgdGFiIDJcXFRyYW5zYWN0aW9ucyB1cERvd24gc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlDQoseyAiMS4yLngiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAxIHRhYiAyXFxUcmFuc2FjdGlvbnMgbGVmdFJpZ2h0IHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIxLjMueSIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDEgdGFiIDNcXENvbnRhY3RzIHVwRG93biBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UNCix7ICIxLjMueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDEgdGFiIDNcXENvbnRhY3RzIGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMS40LnkiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAxIHRhYiA0XFxJbnZlbnRvcnkgdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZQ0KLHsgIjEuNC54IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gMSB0YWIgNFxcSW52ZW50b3J5IGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMiIsICIwIn0gLy88PC0tc2NyZWVuMi1jb21tcyB0YWIobGVmdFJpZ2h0KSBpbmRleA0KLHsgIjIuMS55IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gMiB0YWIgMVxcTG9jYWwgdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIyLjEueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDIgdGFiIDFcXExvY2FsIGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMi4yLnkiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAyIHRhYiAyXFxWb2ljZSB1cERvd24gc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KLHsgIjIuMi54IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gMiB0YWIgMlxcVm9pY2UgbGVmdFJpZ2h0IHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIyLjMueSIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDIgdGFiIDNcXEVtYWlsIHVwRG93biBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMi4zLngiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAyIHRhYiAzXFxFbWFpbCBsZWZ0UmlnaHQgc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KLHsgIjIuNC55IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gMiB0YWIgNFxcV2luZyB1cERvd24gc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KLHsgIjIuNC54IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gMiB0YWIgNFxcV2luZyBsZWZ0UmlnaHQgc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KLHsgIjIuNS55IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gMiB0YWIgNVxcUHJlZnMgdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIyLjUueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDIgdGFiIDVcXFByZWZzIGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMyIsICIwIn0gLy88PC0tc2NyZWVuMy1yb2xlIHRhYihsZWZ0UmlnaHQpIGluZGV4DQoseyAiMy4xLnkiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAzIHRhYiAxXFxTaGlwIHVwRG93biBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMy4xLngiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAzIHRhYiAxXFxTaGlwIGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiMy4yLnkiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiAzIHRhYiAyXFxTUlYgdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICIzLjIueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDMgdGFiIDJcXFNSViBsZWZ0UmlnaHQgc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KLHsgIjQiLCAiMCJ9IC8vPDwtLXNjcmVlbjQtc3lzdGVtcyB0YWIobGVmdFJpZ2h0KSBpbmRleA0KLHsgIjQuMS55IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gNCB0YWIgMVxcU3RhdHVzIHVwRG93biBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiNC4xLngiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiA0IHRhYiAxXFxTdGF0dXMgbGVmdFJpZ2h0IHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICI0LjIueSIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDQgdGFiIDJcXE1vZHVsZXMgdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICI0LjIueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDQgdGFiIDJcXE1vZHVsZXMgbGVmdFJpZ2h0IHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICI0LjMueSIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDQgdGFiIDNcXEludmVudG9yeSB1cERvd24gc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KLHsgIjQuMy54IiwgIjAifSAvLzw8LS1zdWJzY3JlZW4gNCB0YWIgM1xcSW52ZW50b3J5IGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiNC40LnkiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiA0IHRhYiA0XFxGaXJlR3JvdXBzIHVwRG93biBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiNC40LngiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiA0IHRhYiA0XFxGaXJlR3JvdXBzIGxlZnRSaWdodCBzZWxlY3Rpb24gaW5kZXggKHJlc2VydmVyZWQgZm9yIGZ1dHVyZSB1c2UpDQoseyAiNC41LnkiLCAiMCJ9IC8vPDwtLXN1YnNjcmVlbiA0IHRhYiA1XFxGdW5jdGlvbnMgdXBEb3duIHNlbGVjdGlvbiBpbmRleCAocmVzZXJ2ZXJlZCBmb3IgZnV0dXJlIHVzZSkNCix7ICI0LjUueCIsICIwIn0gLy88PC0tc3Vic2NyZWVuIDQgdGFiIDVcXEZ1bmN0aW9ucyBsZWZ0UmlnaHQgc2VsZWN0aW9uIGluZGV4IChyZXNlcnZlcmVkIGZvciBmdXR1cmUgdXNlKQ0KfTsNCg0KICAgICAgICBpbnQgaW50X2xvb3AgPSAwOw0KICAgICAgICBpbnQgaW50X2xvb3Bfc2l6ZSA9IGFycl9zaGlwX3N0YXRlLkdldExlbmd0aCgwKTsNCiAgICAgICAgc3RyaW5nIHN0cl9zaGlwX3N0YXRlID0gIiI7DQogICAgICAgIGZvciAoIGludF9sb29wID0gMDsgaW50X2xvb3AgPCBpbnRfbG9vcF9zaXplOyBpbnRfbG9vcCsrICkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgIHN0cl9zaGlwX3N0YXRlICs9ICggc3RyX3NoaXBfc3RhdGUuTGVuZ3RoID4gMCA/ICJ8IiA6ICIiICkgKyBhcnJfc2hpcF9zdGF0ZVtpbnRfbG9vcCwgMF0gKyAiLCIgKyBhcnJfc2hpcF9zdGF0ZVtpbnRfbG9vcCwgMV07Ly88PC0tc2ltcGxlLXNlcmlhbGl6YXRpb24NCiAgICAgICAgICAgIH0vLzwvZm9yICggaW50X2xvb3AgPSAwOyBpbnRfbG9vcCA8IGludF9sb29wX3NpemU7IGludF9sb29wKysgKT4NCiAgICAgICAgRnhMaWIuU2F2ZUFyZ3MoInNoaXBfc3RhdGUiLCBzdHJfc2hpcF9zdGF0ZS5TcGxpdCgnfCcpLlRvTGlzdDxzdHJpbmc+KCkpOw0KICAgICAgICB9Ly88L19SZXNldFNoaXBTdGF0ZSgpPg0KICAgIC8vLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KICAgIHB1YmxpYyBzdGF0aWMgc3RyaW5nIEdldFN0YXRlKHN0cmluZyBzdHJfcHJvcGVydHkpDQogICAgICAgIHsNCiAgICAgICAgc3RyaW5nIHN0cl9yZXR1cm4gPSAiIjsNCiAgICAgICAgc3RyaW5nIHN0cl9rZXkgPSAiIjsNCiAgICAgICAgYm9vbCBibG5fZm91bmQgPSBmYWxzZTsNCiAgICAgICAgU2NyaXB0Q29yZS5JbmNsdWRlcy5TdXBwb3J0Q2xhc3Nlcy5BcmdzIGFyZ3Nfc2hpcF9zdGF0ZSA9IEZ4TGliLkdldEFyZ3MoInNoaXBfc3RhdGUiKTsNCiAgICAgICAgLy88ZGlhZ25vc3RpY3M+QkZTLlNwZWVjaC5UZXh0VG9TcGVlY2goIkdldFN0YXRlOjpOdW1iZXIgb2YgZGF0YSBlbGVtZW50cyB0byBzY2FuIGlzIHtOVU19LiIuUmVwbGFjZSgie05VTX0iLCBhcmdzX3NoaXBfc3RhdGUuYXJnYy5Ub1N0cmluZygpKSk7DQogICAgICAgIGZvcmVhY2ggKEtleVZhbHVlUGFpcjxpbnQsIFNjcmlwdENvcmUuSW5jbHVkZXMuU3VwcG9ydENsYXNzZXMuQXJnPiByb3cgaW4gYXJnc19zaGlwX3N0YXRlLmFyZ3YpDQogICAgICAgICAgICB7DQogICAgICAgICAgICBzdHJfa2V5ID0gcm93LlZhbHVlLmtleTsNCiAgICAgICAgICAgIGlmICggc3RyX2tleSA9PSBzdHJfcHJvcGVydHkgKQ0KICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBibG5fZm91bmQgPSB0cnVlOw0KICAgICAgICAgICAgICAgIHN0cl9yZXR1cm4gPSByb3cuVmFsdWUudmFsdWU7DQogICAgICAgICAgICAgICAgYnJlYWs7Ly88PC0tYnJlYWNoIHRoZSBsb29wDQogICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgZWxzZSB7OyB9DQogICAgICAgICAgICAvLzwvaWYgKHN0cl9rZXkgPT0gc3RyX3Byb3BlcnR5ICk+DQogICAgICAgICAgICB9Ly88L2ZvcmVhY2ggKCBzdHJpbmcgcm93IGluIGFyZ3Nfc2hpcF9zdGF0ZS5hcmd2ICk+DQogICAgICAgIC8vDQogICAgICAgIGlmICggYmxuX2ZvdW5kICkNCiAgICAgICAgICAgIHsgQkZTLlNwZWVjaC5UZXh0VG9TcGVlY2goIkdldFN0YXRlOjpzdGF0ZSBwcm9wZXJ0eSAne1BST1BFUlRZfScgZm91bmQ6e1ZBTFVFfS4gIi5SZXBsYWNlKCJ7UFJPUEVSVFl9Iiwgc3RyX3Byb3BlcnR5KS5SZXBsYWNlKCJ7VkFMVUV9Iiwgc3RyX3JldHVybikpOyB9DQogICAgICAgIGVsc2UNCiAgICAgICAgICAgIHsgQkZTLlNwZWVjaC5UZXh0VG9TcGVlY2goIkdldFN0YXRlOjpzdGF0ZSBwcm9wZXJ0eSAne1BST1BFUlRZfScgbm90IGZvdW5kISAiLlJlcGxhY2UoIntQUk9QRVJUWX0iLCBzdHJfcHJvcGVydHkpKTsgfQ0KICAgICAgICAvLzwvaWYgKCAhYmxuX2ZvdW5kICk+DQogICAgICAgIHJldHVybiAoIHN0cl9yZXR1cm4gKTsNCiAgICAgICAgfS8vPC9HZXRTdGF0ZShzdHJpbmcgc3RyX3Byb3BlcnR5KT4NCgkvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCglwdWJsaWMgc3RhdGljIHZvaWQgU2V0U3RhdGUoc3RyaW5nIHN0cl9wcm9wZXJ0eSwgc3RyaW5nIHN0cl92YWx1ZSkNCgkJew0KCQlzdHJpbmcgc3RyX2tleSA9ICIiOw0KCQlpbnQgaW50X2luZGV4ID0gLTE7DQoJCWJvb2wgYmxuX2ZvdW5kID0gZmFsc2U7DQoJCXN0cmluZyBzdHJfc2hpcF9zdGF0ZSA9ICIiOw0KCQlzdHJpbmcgc3RyX29sZF9zdGF0ZSA9ICIiOw0KCQlzdHJpbmcgc3RyX25ld19zdGF0ZSA9ICIiOw0KCQlTY3JpcHRDb3JlLkluY2x1ZGVzLlN1cHBvcnRDbGFzc2VzLkFyZ3MgYXJnc19zaGlwX3N0YXRlID0gRnhMaWIuR2V0QXJncygic2hpcF9zdGF0ZSIpOw0KCQkvLz4+Pj4+ZW5zdXJlIHdlIGhhdmUgZGF0YSwgZWxzZSBpbml0aWFsaXplDQoJCWlmKGFyZ3Nfc2hpcF9zdGF0ZS5hcmdjID09IDApDQoJCQl7DQoJCQlTaGlwTW9kZWwuUmVzZXRTaGlwU3RhdGUoKTsvLzw8LS1pbml0DQoJCQlhcmdzX3NoaXBfc3RhdGUgPSBGeExpYi5HZXRBcmdzKCJzaGlwX3N0YXRlIik7Ly88PC0tcmVsb2FkDQoJCQl9DQoJCWVsc2UgezsgfS8vPj4+Pj5kbyBub3RoaW5nDQoJCS8vPC9pZihpZihhcmdzX3NoaXBfc3RhdGUuYXJnYyA9PSAwKSk+DQoJCVNjcmlwdENvcmUuSW5jbHVkZXMuU3VwcG9ydENsYXNzZXMuQXJncyBhcmdzX25ld19zaGlwX3N0YXRlID0gRnhMaWIuR2V0QXJncygic2hpcF9zdGF0ZSIpOw0KCQkvLzxkaWFnbm9zdGljcz5CRlMuU3BlZWNoLlRleHRUb1NwZWVjaCgiR2V0U3RhdGU6Ok51bWJlciBvZiBkYXRhIGVsZW1lbnRzIHRvIHNjYW4gaXMge05VTX0uIi5SZXBsYWNlKCJ7TlVNfSIsIGFyZ3Nfc2hpcF9zdGF0ZS5hcmdjLlRvU3RyaW5nKCkpKTsNCgkJZm9yZWFjaCAoS2V5VmFsdWVQYWlyPGludCwgU2NyaXB0Q29yZS5JbmNsdWRlcy5TdXBwb3J0Q2xhc3Nlcy5Bcmc+IHJvdyBpbiBhcmdzX3NoaXBfc3RhdGUuYXJndikNCgkJCXsNCgkJCWludF9pbmRleCsrOw0KCQkJc3RyX2tleSA9IHJvdy5WYWx1ZS5rZXk7DQoJCQlzdHJfb2xkX3N0YXRlID0gYXJnc19zaGlwX3N0YXRlLmFyZ3ZbaW50X2luZGV4XS52YWx1ZTsNCgkJCS8vDQoJCQlpZiAoIHN0cl9rZXkgPT0gc3RyX3Byb3BlcnR5ICkNCgkJCQl7DQoJCQkJYmxuX2ZvdW5kID0gdHJ1ZTsNCgkJCQlzdHJfbmV3X3N0YXRlID0gc3RyX3ZhbHVlOw0KCQkJCX0NCgkJCWVsc2UNCgkJCQl7DQoJCQkJc3RyX25ld19zdGF0ZSA9IHN0cl9vbGRfc3RhdGU7DQoJCQkgICAgfQ0KCQkJLy88L2lmIChzdHJfa2V5ID09IHN0cl9wcm9wZXJ0eSApPg0KCQkJc3RyX3NoaXBfc3RhdGUgKz0gKCBzdHJfc2hpcF9zdGF0ZS5MZW5ndGggPiAwID8gInwiIDogIiIgKSArIHN0cl9rZXkgKyAiLCIgKyBzdHJfbmV3X3N0YXRlOw0KCQkJfS8vPC9mb3JlYWNoICggc3RyaW5nIHJvdyBpbiBhcmdzX3NoaXBfc3RhdGUuYXJndiApPg0KCQkvLw0KCQlpZiAoICFibG5fZm91bmQgKS8vPj4+Pj5jcmVhdGUNCgkJCXsNCgkJCWFyZ3Nfc2hpcF9zdGF0ZS5hcmd2LkFkZChhcmdzX3NoaXBfc3RhdGUuYXJnYyxuZXcgU2NyaXB0Q29yZS5JbmNsdWRlcy5TdXBwb3J0Q2xhc3Nlcy5BcmcoKSB7IGtleSA9IHN0cl9rZXksIHZhbHVlID0gc3RyX3ZhbHVlIH0pOw0KCQkJfQ0KCQllbHNlLy8+Pj4+PmNvbnRpbnVlIHRvIHNhdmUNCgkJCXs7IH0NCgkJLy88L2lmICggYmxuX2ZvdW5kICk+DQoJCUJGUy5TY3JpcHRTZXR0aW5ncy5Xcml0ZVZhbHVlKCJzaGlwX3N0YXRlIiwgc3RyX3NoaXBfc3RhdGUpOw0KCQl9Ly88L1NldFN0YXRlKHN0cmluZyBzdHJfcHJvcGVydHksc3RyaW5nIHN0cl92YWx1ZSk+DQoJLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQogICAgfS8qPC9jbGFzczo6U2hpcE1vZGVsPiovDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLz09L1N1cHBvcnQgQ2xhc3Nlcw0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI2VuZHJlZ2lvbg0KLy89PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PQ0KI3JlZ2lvbiBEYXRhYmFzZSBDbGFzc2VzDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLz09IERhdGFiYXNlIENsYXNzZXMNCi8vPT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCi8vLyA8c3VtbWFyeT4NCi8vLyBBdXRob3I6IERhcmtzdHJ1bW46XGNyZWF0ZWQ6OjE2MDExMi4xMg0KLy8vIEZ1bmN0aW9uOiBwcm92aWRlcyBEQiBmdW5jdGlvbmFsaXR5IGZvciB1c2Ugd2l0aCBtYWNybyBzY3JpcHRzLCBpbXByb3ZlZCBJUEMgZmluY3Rpb25hbGl0eSBvdmVyIHRoZSB1c2Ugb2YgdGhlIHJlZ2lzdHJ5IGZvciBjb21wbGV4ZSBtYWNybyBsb2dpYw0KLy8vID4+Pj4+aWYgdm9pY2Vib3QgY29tcGxhaW5zIHRoYXQgdGhlIHByb3ZpZGVyIGlzIG5vdCByZWdpc3RlciBvbiB0aGUgbG9jYWwgbWFjaGluZSwgdGhlbiBpbnN0bGwgdGhlIGFjY2VzcyBlbmdpbmUgZm9yIHlvdXIgc3lzdGVtIFszMnw2NF1iaXQ6OiBodHRwczovL3d3dy5taWNyb3NvZnQuY29tL2VuLXVzL2Rvd25sb2FkL2RldGFpbHMuYXNweD9pZD0xMzI1NQ0KLy8vIHVzaW5nIFN5c3RlbS5EYXRhLk9sZURiOyAvLzw8LS1TeXN0ZW0uRGF0YS5EYXRhU2V0RXh0ZW5zaW9ucy5kbGwgaXMgbmVlZGVkDQovLy8gPC9zdW1tYXJ5Pg0KcHVibGljIHN0YXRpYyBjbGFzcyBEQlMNCiAgICB7DQogICAgLy8tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQogICAgLy8vIDxzdW1tYXJ5Pg0KICAgIC8vLyB0eXBlIGV4dGVuc2lvbiBmb3IgdHJ1ZSBudWxsIGhhbmRsaW5nDQogICAgLy8vIDwvc3VtbWFyeT4NCiAgICAvLy8gPHBhcmFtIG5hbWU9Im9ial9maWVsZCI+PC9wYXJhbT4NCiAgICAvLy8gPHJldHVybnM+PC9yZXR1cm5zPg0KICAgIHB1YmxpYyBzdGF0aWMgYm9vbCBJc051bGwodGhpcyBvYmplY3Qgb2JqX2ZpZWxkKQ0KICAgICAgICB7DQogICAgICAgIGJvb2wgYmxuX3JldHVybiA9ICgob2JqX2ZpZWxkID09IG51bGwpIHx8IChvYmpfZmllbGQgPT0gREJOdWxsLlZhbHVlKSk7DQogICAgICAgIHJldHVybihibG5fcmV0dXJuKTsNCiAgICAgICAgfS8vPC9Jc0RCTnVsbChvYmplY3Qgb2JqX2ZpZWxkKT4NCiAgICAvLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0NCiAgICAvLy8gPHN1bW1hcnk+DQogICAgLy8vIFF1ZXJ5IHByb3ZpZGVzIGJhc2ljIERCIHF1ZXJ5IGZ1bmN0aW9uYWxpdHkgKG1zc3FsXFxhY2Nlc3MgdHlwaWNhbGx5KSwgcmV0dXJucyBEYXRhdGFibGUgb2YgcmVzdWx0cw0KICAgIC8vLyA8L3N1bW1hcnk+DQogICAgLy8vIDxwYXJhbSBuYW1lPSJzdHJfcXVlcnkiPjwvcGFyYW0+DQogICAgLy8vIDxwYXJhbSBuYW1lPSJzdHJfY29ubmVjdGlvbnN0cmluZyI+PC9wYXJhbT4NCiAgICAvLy8gPHJldHVybnM+PC9yZXR1cm5zPg0KICAgIHB1YmxpYyBzdGF0aWMgRGF0YVRhYmxlIFF1ZXJ5KHN0cmluZyBzdHJfcXVlcnksIHN0cmluZyBzdHJfY29ubmVjdGlvbnN0cmluZykNCiAgICAgICAgew0KICAgICAgICBEYXRhVGFibGUgZHRfcmVzdWx0ID0gbmV3IERhdGFUYWJsZSgpOw0KICAgICAgICBzdHJfY29ubmVjdGlvbnN0cmluZyA9IChzdHJfY29ubmVjdGlvbnN0cmluZy5MZW5ndGggPiAwID8gc3RyX2Nvbm5lY3Rpb25zdHJpbmcgOiBTY3JpcHRDb3JlLkluY2x1ZGVzLlN1cHBvcnRDbGFzc2VzLkNvbnN0YW50cy5zdHJfZGVmYXVsdF9jb25uZWN0aW9uX3N0cmluZyk7IC8vICJcXFNjcmlwdEV4dGVuc2lvblxcIiA8PC0tdGhpcyBtdXN0IGJlIGNyZWF0ZWQgaW4gdm9pY2Vib3QgaW5zdGFsbCBmb2xkZXIgYW5kIHRoZSAubWRiIGZpbGVzIHNob3VsZCBiZSBzdG9yZWQgaW4gaGVyZSBzbyB0aGUgbWFjcm9zY3JpcHRzIGhhdmUgYWNjZXNzIHRvIGEgc3RhbmRhcmQgbG9jYXRpb24uDQogICAgICAgIC8vICAgICAgICANCiAgICAgICAgdHJ5DQogICAgICAgICAgICB7DQogICAgICAgICAgICAvLz4+Pj4+T3BlbiBPbGVEYiBDb25uZWN0aW9uIHVzaW5nIE1TQWNjZXNzIHR5cGUgbG9jYWxkYiBmaWxlDQogICAgICAgICAgICBPbGVEYkNvbm5lY3Rpb24gZGJfY29ubmVjdGlvbiA9IG5ldyBPbGVEYkNvbm5lY3Rpb24oKTsNCiAgICAgICAgICAgIGRiX2Nvbm5lY3Rpb24uQ29ubmVjdGlvblN0cmluZyA9IHN0cl9jb25uZWN0aW9uc3RyaW5nOw0KICAgICAgICAgICAgZGJfY29ubmVjdGlvbi5PcGVuKCk7DQogICAgICAgICAgICAvLz4+Pj4+RXhlY3V0ZSBRdWVyaWVzDQogICAgICAgICAgICBPbGVEYkNvbW1hbmQgZGJfY29udGV4dCA9IGRiX2Nvbm5lY3Rpb24uQ3JlYXRlQ29tbWFuZCgpOw0KICAgICAgICAgICAgZGJfY29udGV4dC5Db21tYW5kVGV4dCA9IHN0cl9xdWVyeTsNCiAgICAgICAgICAgIE9sZURiRGF0YVJlYWRlciBkYl9yZWFkZXIgPSBkYl9jb250ZXh0LkV4ZWN1dGVSZWFkZXIoQ29tbWFuZEJlaGF2aW9yLkNsb3NlQ29ubmVjdGlvbik7IC8vPj4+Pj5jbG9zZSBjb25uZWN0aW9uIGFmdGVyIGNvbXBsZXRlDQogICAgICAgICAgICAvLz4+Pj4+TG9hZCB0aGUgcmVzdWx0IGludG8gYSBEYXRhVGFibGUNCiAgICAgICAgICAgIGR0X3Jlc3VsdC5Mb2FkKGRiX3JlYWRlcik7DQogICAgICAgICAgICB9DQogICAgICAgIGNhdGNoICggRXhjZXB0aW9uIGVycm9yICkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgIFN0cmluZyBzdHJfZXJyb3JfbWVzc2FnZSA9ICJnZXREYXRhOjpDb21tYW5kZXIsIE9MRURCIENvbm5lY3Rpb24gRkFJTEVEOiB7RVJST1JNU0d9Ii5SZXBsYWNlKCJ7RVJST1JNU0d9IiwgZXJyb3IuTWVzc2FnZSk7DQogICAgICAgICAgICAvLzxyZXBsYWNlZD5CRlMuU3BlZWNoLlRleHRUb1NwZWVjaChzdHJfZXJyb3JfbWVzc2FnZSk7DQogICAgICAgICAgICBCRlMuRGlhbG9nLlNob3dNZXNzYWdlRXJyb3Ioc3RyX2Vycm9yX21lc3NhZ2UpOw0KICAgICAgICAgICAgfS8vPC90cnk+DQogICAgICAgIHJldHVybiAoIGR0X3Jlc3VsdCApOw0KICAgICAgICB9DQogICAgfS8qPC9jbGFzczo6REJTPiovDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQovLz09IC9EYXRhYmFzZSBDbGFzc2VzDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQojZW5kcmVnaW9uDQovLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09DQoNCiAgICAvLz09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0NCiAgICB9Lyo8L25hbWVzcGFjZTo6SW5jbHVkZXM+Ki8=";
                break;

                case "ship_state":
                str_return = "shipName,DIN Ka'pla|cargoScoop,0|landingGear,0|externalLights,0|flightAssist,1|hardpoints,0|silentRunning,0|activeFiregroup,0|shipType,8|modules,20|firegoups,5|refineryBins,5|systemsPower,2|enginesPower,2|weaponsPower,2|turretMode,2|beacon,0|confirmation,0|jettison,0";
                break;

                case "aoscore_ipc":
                str_return = "deployCargoScoop|SetShipState,cargoScoop,1|SendKeys,{HOME}|TTS,Acknowledged. cargo scoop active.";
                break;

                default:
                break;
                    }//</switch(str_variable_name.ToLower())>
                Debug.WriteLine("**ReadValue(string {NAME})::{RETURN}".Replace("{NAME}", str_variable_name).Replace("{RETURN}", str_return));
                return ( str_return );
                }/*</ReadValue(string str_variable_name)>*/

                 //---------------------------------------------------------------------
            public static void WriteValue(string str_variable_name, string str_variable_value)
                {/*<stub>*/
                int fnd = lst_registry.IndexOf(new RegistryEntry() { Key = str_variable_name });
                //
                if ( fnd == -1 )//>>>>>add
                    { lst_registry.Add(new RegistryEntry() { Key = str_variable_name, Dword = str_variable_value }); }
                else//>>>>>update
                    {
                    if ( str_variable_value.Length > 0 )
                        { lst_registry[fnd].Dword = str_variable_value; }
                    else
                        { lst_registry.RemoveAt(fnd); }
                    //</if ( str_variable_value.Length > 0 )>
                    }
                //>>>>>diagnostic output
                Debug.WriteLine("**WriteValue(string {NAME}, string {VALUE})\\\\Fake Registry::".Replace("{NAME}", str_variable_name).Replace("{VALUE}", str_variable_value));
                foreach ( RegistryEntry registry_entry in lst_registry )
                    { Debug.WriteLine("***(Dword){KEY} = {DWORD}".Replace("{KEY}", registry_entry.Key).Replace("{DWORD}", registry_entry.Dword)); }
                }/*</WriteValue(string str_variable_name, string str_variable_value)>*/

                 //---------------------------------------------------------------------
            }/*</class::ScriptSettings>*/
        }/*</namespace BFS>*/

         //=============================================================================
         //==Development Scaffolding Support Classes
         //=============================================================================

    #endregion Development Scaffolding Support Classes

    //*****************************************************************************
    /// <summary>
    /// Author: Darkstrumn:\created::160116.00
    /// Function: init ShipModel and Ship State
    /// <summary>
    //using System;
    //using System.Collections.Generic;//<<--needed for Dictionary
    //using System.Data; //<<--in references
    //using System.Data.OleDb; //<<--provided by System.Data.DataSetExtensions.dll
    //using System.Diagnostics;//<<--needed for debug (visual studio IDE only)
    //using System.Linq;//<<--provided by C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Data.Linq.dll
    //using System.Threading;
    //using System.Threading.Tasks;
    //using System.Drawing; //<<--in references
    //using System.IO;//<<--text file io for loading includes files
    //using System.Management; //<<--in references
    //using System.Speech.Recognition;//<<-- provided by C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll
    //using System.Speech.Synthesis;
    //using System.Web; //<<--in references
    //using System.Windows; //<<--in references
    //using System.Xml; //<<--in references
    //using System.CodeDom.Compiler;
    //using System.Reflection;
    //using System.Text; //<<--provided by mscorlib.dll
    //using Microsoft.CSharp; //<<--in system.dll
    //<references:>System.Core.dll |System.Data.dll | System.dll | System.Drawing.dll | System.Management.dll | System.Web.dll | System.Windows.Forms.dll | System.Xml.dll | mscorlib.dll | C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Speech.dll | C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\Profile\Client\System.Data.Linq.dll
    //=============================================================================

    #region main

    //=============================================================================
    //==main
    //=============================================================================
    /// <summary>
    /// Author: Darkstrumn:\created::160116.00
    /// Function: Non-Toggle Engage of Cargo Scoop.
    /// Companion Macro will Disengage Cargo Scoop.
    /// <summary>
    //=============================================================================
    public static class VoiceBotScript
        {
        #region private vars

        private static string str_script_name = "Level1Diagnostics";

        //>>>>>this array will store our random response sets (2 typically , successful\\ok messages and failure\\not-ok messages, but only ok in this case)
        private static string[] _arr_str_responses = new string[]
                    {
				/*comply verbiage*/
				"Initiating Level 1 System Diagnostics, please wait."
                ,"Level 1 diagnostics now underway."
                ,"Sir - Level 1 System Diagnostics engaged."
                ,"Acknowledged. commencing level 1 diagnostics"
                    };

        #endregion private vars

        //-------------------------------------------------------------------------
        /// <summary>
        /// Engage Level 1 Diagnostics macro script
        /// reset the ShipModel State to known state
        /// </summary>
        /// <param name="windowHandle"></param>
        public static void Run(IntPtr windowHandle)
            {
            int int_response_index = -1;
            string str_response = "";
            //>>>>>defaults
            int_response_index = ( new Random().Next(0, _arr_str_responses.GetLength(1)) );
            //
            str_response = _arr_str_responses[int_response_index];
            Includes.FxLib.SaveArgs("AOSCore_ipc", ( "deployCargoScoop|InitShipState,cargoScoop,1|SendKeys,{HOME}|TTS,{TTS}".Replace("{TTS}", str_response) ).Split('|'));//<<--second param is expected to be an array
            }//</Run(IntPtr windowHandle)>

             //-------------------------------------------------------------------------
        }/*</class::VoiceBotScript>*/

         //=============================================================================
         //==/main
         //=============================================================================

    #endregion main

    //=============================================================================

    #region Includes

    //=============================================================================
    //== Includes Classes
    //=============================================================================
    /// <summary>
    /// Includes
    /// How it works: includes are accomplished using the ScriptEngine coded above to
    /// in-line compile the "include" code into an assembly in memory. The in-memory
    /// assembly is then accessed directly or via delegates that connect the includes code to the
    /// Includes namespace.
    /// calls can then be made fully qualifying the call ie:
    /// string str_confirmation_response = Includes.Speech.SpeechRecognizer("Are your sure?");
    /// or directly:
    /// Assembly assem_Speech = (Assembly)Includes.VoiceBotSupportClasses.ScriptEngine.LoadInclude(new IntPtr(),"Include_DarkLibs",Includes.VoiceBotSupportClasses.Constants.str_default_references)).GetTypes().Where( x => x.FullName.Contains("Includes.Speech");
    /// string str_confirmation_response = (string)CallFunction(assem_Speech, "SpeechRecognizer", new object[] {"Are your sure?"})
    /// -----------------------------------------------------------------------
    /// Usings: using System.IO;//<<--text file io for loading includes files
    /// References: N/A
    /// NOTE: Includes can be done in 2 ways, using a separate .cs file to hold the
    /// cs code loaded via LoadIncludes(), and\or the VoiceBot registry variables loaded
    /// via GetIncludes(). The latter is more portable, easier to edit and backup,
    /// however, the former, is more compact and self-contained being stored in the
    /// registry. The choice is yours on which to use.
    /// </summary>
    namespace Includes
        {
        //=========================================================================
        /// <summary>
        /// Author: Darkstrumn 160120.01
        /// Function: faux-namespace\\alias includes via delegation. kinda messy, but "re-integrates" the namespace
        /// and cleanliness of code down the line the working code is housed in the include,
        /// but are craft delagation aliases for any items we want to, in this case the
        /// ShipModel.
        /// </summary>
        public static class ShipModel
            {
            //>>>>>load includes, then wireup aliases to assembly
            private static Type type_ShipModel = ( (Assembly)Includes.VoiceBotSupportClasses.ScriptEngine.LoadInclude(new IntPtr(), "Include_EliteDangerousShipModel", Includes.VoiceBotSupportClasses.Constants.str_default_references) ).GetTypes().Where(x => x.FullName.Contains("Includes.ShipModel")).ToArray<Type>()[0];

            //>>>>>appoint delagates (signatures)
            public delegate string GetStateDelegate(string str_property);

            public delegate void SetStateDelegate(string str_property, string str_value);

            public delegate void ResetShipStateDelegate();

            //>>>>>staff them
            public static GetStateDelegate GetState = (GetStateDelegate)Delegate.CreateDelegate(typeof(GetStateDelegate), ( ( type_ShipModel.GetMethods().Where(x => x.Name == "GetState").ToArray<MethodInfo>() ) )[0]);

            public static SetStateDelegate SetState = (SetStateDelegate)Delegate.CreateDelegate(typeof(SetStateDelegate), ( ( type_ShipModel.GetMethods().Where(x => x.Name == "SetState").ToArray<MethodInfo>() ) )[0]);
            public static ResetShipStateDelegate ResetShipState = (ResetShipStateDelegate)Delegate.CreateDelegate(typeof(ResetShipStateDelegate), ( ( type_ShipModel.GetMethods().Where(x => x.Name == "ResetShipState").ToArray<MethodInfo>() ) )[0]);
            }/*</class::ShipModel>*/

        #region Support Classes

        //=========================================================================
        //== Support Classes
        //=========================================================================
        /// <summary>
        /// Author: Darkstrumn:\created::160115.03
        /// Function: Support classes such are custom datatypes, etc.
        /// </summary>
        namespace VoiceBotSupportClasses
            {
            //=====================================================================
            /// <summary>
            /// Author: Darkstrumn
            /// Function: Provides central location for common or default global values, pseudo-constants
            /// </summary>
            public static class Constants
                {
                //-----------------------------------------------------------------
                public static string str_default_references = "System.Core.dll |System.Data.dll | System.dll | System.Drawing.dll | System.Management.dll | System.Web.dll | System.Windows.Forms.dll | System.Xml.dll | mscorlib.dll | C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll | C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Data.Linq.dll".Replace("\\", "\\\\");

                public static string str_default_connection_string = "Provider='Microsoft.ACE.OLEDB.12.0'; Data Source='{PATH}LogBook.mdb'; Persist Security Info=False".Replace("{PATH}", ( BFS.General.GetAppInstallPath() + "\\ScriptExtension\\" )).Replace("\\", "\\\\");
                /*
                The following path will likely need to be created to store any includes you make, as a common place to put them.
                The dir can be created using the following cmd from the command prompt:
                mkdir %LOCALAPPDATA%\VoiceBot\ScriptExtension\
                The path created should be something similar the following:
                C:\Users\YOUR_USER_NAME_HERE\AppData\Local\VoiceBot\ScriptExtension\
                */

                public static string str_default_Include_path = ( BFS.General.GetAppInstallPath() != "C:\\mnt\\W\\DevCore\\ProtoLab\\dotnet\\dotnet2k15\\Projects\\VoiceBotScript\\VoiceBotScript\\bin\\Debug" ) ?
                ( Environment.GetEnvironmentVariable("LOCALAPPDATA") + "\\VoiceBot\\ScriptExtension\\" ).Replace("\\", "\\\\")
                : "C:\\mnt\\DevCore\\ProtoLab\\dotnet\\dotnet2k15\\Projects\\VoiceBotScript\\VoiceBotScript\\ScriptExtension\\".Replace("\\", "\\\\");

                //-----------------------------------------------------------------
                }/*</class Constants>*/

                 //=====================================================================

            #region ScriptEngine

            //=====================================================================
            //== ScriptEngine Function Library
            //=====================================================================
            /// <summary>
            /// Author: Darkstrumn:\created::160115.03
            /// Function: define standard library functions - The Toolbox -
            /// with the GetInclude functionality, additional functions can be stored as variables,
            /// and loaded dynamically for common library functionaity
            /// </summary>
            public static class ScriptEngine
                {
                //-------------------------------------------------------------------
                /// <summary>
                /// Author: Darkstrumn
                /// Function: CsCodeAssembler takes provided CS source and attempts to compile code, then returns an instance object of the assembly
                /// viable for loading aux scripts to form includes or dynamic code loading
                /// </summary>
                /// <param name="windowHandle"></param>
                /// <param name="str_source_cs"></param>
                /// <param name="str_references"></param>
                /// <returns></returns>
                public static object Eval(IntPtr windowHandle, string str_source_cs, string str_references = "")
                    {
                    object obj_return = null;
                    str_references = ( str_references.Length != 0 ? str_references : Includes.VoiceBotSupportClasses.Constants.str_default_references );
                    //
                    //CodeDomProvider provider = new CSharpCodeProvider(new Dictionary<String, String>{{ "CompilerVersion","v4.0" }});
                    CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                    //
                    CompilerParameters cp_compiler_params = new CompilerParameters();
                    //>>>>>compileing options to build code
                    cp_compiler_params.CompilerOptions = "/t:library";//<<--craft as library dll
                    cp_compiler_params.GenerateExecutable = false;//<<--do not craft executable
                    cp_compiler_params.GenerateInMemory = true;//<<--output in memmory vs output file
                    cp_compiler_params.TreatWarningsAsErrors = false;//<<--warning handling
                    str_references += ( str_references.Length > 0 ? "|" : "" ) + "C:\\Program Files (x86)\\VoiceBot\\VoiceBot.exe";
                    foreach ( string str_reference in str_references.Split('|') )
                        {
                        cp_compiler_params.ReferencedAssemblies.Add(str_reference.Trim());
                        }//</foreach(string str_reference in str_references.Split('|'))>
                         //
                    StringBuilder sb_script_core = new StringBuilder("");//<<--more flexible than string concatination if we add hardcoded library logic here
                                                                         //>>>>>ScriptCore.Includes.INCLUDE_CLASS.INCLUDE_FUNCTION
                    sb_script_core.Append(@"//<reserved for future use>namespace Library
            //{
            " + str_source_cs + @"
            //}/*</namespace::Library>*/
            ");//</sb_script_core>
               //>>>>>attempt to compile
                    CompilerResults cr_result = provider.CompileAssemblyFromSource(cp_compiler_params, sb_script_core.ToString());
                    //
                    if ( cr_result.Errors.Count > 0 )//>>>>>report error, and fail
                        {
                        foreach ( CompilerError CompErr in cr_result.Errors )
                            {
                            string str_line = sb_script_core.ToString().Split('\n')[CompErr.Line - 1];
                            //BFS.Dialog.ShowMessageError("Source:\n{SOURCE}".Replace("{SOURCE}",sb_script_core.ToString()) );
                            BFS.Dialog.ShowMessageError("CsCodeAssembler\\\\ERROR: Line number {LINE}, Error Number: {NUMBER}, '{TEXT}'".Replace("{LINE}", CompErr.Line.ToString()).Replace("{NUMBER}", CompErr.ErrorNumber).Replace("{TEXT}", CompErr.ErrorText));
                            BFS.Dialog.ShowMessageError("CsCodeAssembler\\\\Line number: {NUMBER} :: '{LINE}'".Replace("{NUMBER}", CompErr.Line.ToString()).Replace("{LINE}", str_line));
                            }//</foreach(CompilerError CompErr in cr_result.Errors)>
                        }
                    else//>>>>>execute code
                        {
                        System.Reflection.Assembly assembly_library_code = cr_result.CompiledAssembly;
                        //<moved>object obj_library_code_instance = assembly_library_code.CreateInstance("ScriptCore.Includes");
                        //obj_return = obj_library_code_instance;
                        obj_return = assembly_library_code;
                        }
                    //</if(cr_result.Errors.Count > 0)>
                    return ( obj_return );
                    }/*</CsCodeAssembler( IntPtr windowHandle, string str_source_cs, string str_references = "")>*/

                     //-------------------------------------------------------------------
                     /// <summary>
                     /// call non-statics like the type class Args
                     /// </summary>
                     /// <param name="assembly_library_code"></param>
                     /// <param name="str_class_name"></param>
                     /// <param name="str_function_name"></param>
                     /// <param name="obj_parameters_array"></param>
                     /// <returns></returns>
                public static dynamic CreateClassInstance(Assembly assembly_library_code, string str_class_name, object[] obj_parameters_array, System.Reflection.BindingFlags int_flags = ( BindingFlags.Public | BindingFlags.Instance ))
                    {
                    //<diagnostics to see if member names are proper>((((System.Reflection.RuntimeAssembly)assembly_library_code).DefinedTypes).Where(c=>c.FullName.Contains("Includes." + str_class_name)))
                    string str_fullname = "Includes." + str_class_name;
                    bool bln_ignore_case = false;
                    System.Reflection.BindingFlags flags = ( BindingFlags.Public | BindingFlags.Instance );
                    var obj_return = assembly_library_code.CreateInstance(str_fullname, bln_ignore_case, flags, null, obj_parameters_array, null, new object[] { });
                    return ( obj_return );
                    }//</CreateClassInstance(Assembly assembly_library_code, string str_class_name, object[] obj_parameters_array)>

                     //-------------------------------------------------------------------
                     /// <summary>
                     /// Author: Darkstrumn
                     /// Function:  CallFunction call the included functions specified
                     /// </summary>
                     /// <param name="obj_library_code_instance"></param>
                     /// <param name="str_function_name"></param>
                     /// <param name="obj_parameters_array"></param>
                     /// <returns></returns>
                public static object CallFunction(Assembly assembly_library_code, string str_function_name, object[] obj_parameters_array)
                    {
                    //
                    var obj_library_code_instance = assembly_library_code.CreateInstance("Includes." + str_function_name);
                    //<diagnostics>Type[] obj_library_types = ((Assembly)assembly_library_code).GetTypes();
                    Type type_instance_type = obj_library_code_instance.GetType();
                    var method_info = type_instance_type.GetMethod(str_function_name);
                    //
                    object obj_return = method_info.Invoke(obj_library_code_instance, obj_parameters_array);
                    return ( obj_return );
                    }//</CallFunction(Object obj_library_code_instance, str_function_name, object[] obj_parameters_array)>

                     //-------------------------------------------------------------------
                     /// <summary>
                     /// Author: Darkstrumn
                     /// Function: GetInclude is an alias to the loading of Includes. Store unboxed object to instance variable and use it with the CallFunction
                     /// function to call the included functions
                     /// </summary>
                     /// <param name="windowHandle"></param>
                     /// <param name="str_include"></param>
                     /// <param name="str_references"></param>
                     /// <returns></returns>
                public static object GetInclude(IntPtr windowHandle, string str_include, string str_references = "")
                    {
                    str_references = ( str_references.Length != 0 ? str_references : Includes.VoiceBotSupportClasses.Constants.str_default_references );
                    string str_code = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(BFS.ScriptSettings.ReadValue(str_include)));
                    var obj_include = ScriptEngine.Eval(windowHandle, str_code, str_references);
                    return ( (object)obj_include );
                    }//</GetInclude(IntPtr windowHandle, string str_include,string str_references = "")>

                     //-------------------------------------------------------------------
                     /// <summary>
                     /// Author: Darkstrumn
                     /// Function: LoadInclude is an alias to the loading of includes via local cs file. Store unboxed object to instance variable and use it with the CallFunction
                     /// function to call the included functions
                     /// </summary>
                     /// <param name="windowHandle"></param>
                     /// <param name="str_path"></param>
                     /// <param name="str_references"></param>
                     /// <returns></returns>
                public static object LoadInclude(IntPtr windowHandle, string str_path, string str_references = "")
                    {
                    object obj_include = null;
                    str_references = ( str_references.Length != 0 ? str_references : Includes.VoiceBotSupportClasses.Constants.str_default_references );
                    string str_include_path = ( Includes.VoiceBotSupportClasses.Constants.str_default_Include_path + str_path + ".cs" ).Replace("\\\\", "\\");//<<--conditioning:: undo the script compatibility conditioning of the constant = app.path\ScriptExtension\IncludeFile.cs
                                                                                                                                                              //
                    try
                        {
                        TextReader tr_include_code = new StreamReader(str_include_path);
                        string str_code = tr_include_code.ReadToEnd().ToString();
                        if ( str_code.Length > 0 )
                            { obj_include = ScriptEngine.Eval(windowHandle, str_code, str_references); }
                        else
                            {; }
                        //</if(str_code.Length > 0)>
                        }
                    catch {; }
                    //</try>
                    return ( (object)obj_include );
                    }//</GetInclude(IntPtr windowHandle, string str_include,string str_references = "")>

                     //-------------------------------------------------------------------
                }/*</class::ScriptEngine>*/

                 //=====================================================================
                 //== /ScriptEngine Function Library
                 //=====================================================================

            #endregion ScriptEngine

            //=====================================================================
            }/*</namespace::VoiceBotSupportClasses>*/

             //=========================================================================
             //== /Support Classes
             //=========================================================================

        #endregion Support Classes

        //=========================================================================
        /// <summary>
        /// Author: Darkstrumn 160120.01
        /// Function: faux-namespace\\alias includes via delegation. kinda messy, but "re-integrates" the namespace
        /// and cleanliness of code down the line the working code is housed in the include,
        /// but are craft delagation aliases for any items we want to, in this case the
        /// FxLib.
        /// </summary>
        public static class FxLib
            {
            //>>>>>load includes, then wireup aliases to assembly
            public static Type type_FxLib = ( (Assembly)Includes.VoiceBotSupportClasses.ScriptEngine.LoadInclude(new IntPtr(), "Include_DarkLibs", Includes.VoiceBotSupportClasses.Constants.str_default_references) ).GetTypes().Where(x => x.FullName.Contains("Includes.FxLib")).ToArray<Type>()[0];

            //>>>>>appoint delagates (signatures)
            //public delegate Includes.VoiceBotSupportClasses.Args GetArgsDelegate(string str_variable_name);
            public delegate Dictionary<int, KeyValuePair<string, string>> GetArgsDelegate(string str_variable_name);

            public delegate void SaveArgsDelegate(string str_variable_name, string[] arr_content);

            //>>>>>staff them
            public static GetArgsDelegate GetArgs = (GetArgsDelegate)Delegate.CreateDelegate(typeof(GetArgsDelegate), ( ( type_FxLib.GetMethods().Where(x => x.Name == "GetArgs").ToArray<MethodInfo>() ) )[0]);

            public static SaveArgsDelegate SaveArgs = (SaveArgsDelegate)Delegate.CreateDelegate(typeof(SaveArgsDelegate), ( ( type_FxLib.GetMethods().Where(x => x.Name == "SaveArgs").ToArray<MethodInfo>() ) )[0]);
            }/*</class::FxLib>*/

             //=========================================================================
             /// <summary>
             /// Author: Darkstrumn 160120.01
             /// Function: faux-namespace\\alias includes via delegation. kinda messy, but "re-integrates" the namespace
             /// and cleanliness of code down the line the working code is housed in the include,
             /// but are craft delagation aliases for any items we want to, in this case the
             /// Speech.
             /// </summary>
        public static class Speech
            {
            //>>>>>load includes, then wireup aliases to assembly
            private static Type type_Speech = ( (Assembly)Includes.VoiceBotSupportClasses.ScriptEngine.LoadInclude(new IntPtr(), "Include_DarkLibs", Includes.VoiceBotSupportClasses.Constants.str_default_references) ).GetTypes().Where(x => x.FullName.Contains("Includes.Speech")).ToArray<Type>()[0];

            //>>>>>appoint delagates (signatures)
            public delegate string SpeechRecognizerDelegate(string str_voice_prompt);

            //>>>>>staff them
            public static SpeechRecognizerDelegate SpeechRecognizer = (SpeechRecognizerDelegate)Delegate.CreateDelegate(typeof(SpeechRecognizerDelegate), ( ( type_Speech.GetMethods().Where(x => x.Name == "SpeechRecognizer").ToArray<MethodInfo>() ) )[0]);
            }/*</class::ShipModel>*/

             //=========================================================================
             /// <summary>
             /// Author: Darkstrumn 160120.01
             /// Function: faux-namespace\\alias includes via delegation. kinda messy, but "re-integrates" the namespace
             /// and cleanliness of code down the line the working code is housed in the include,
             /// but are craft delagation aliases for any items we want to, in this case the
             /// DBServices.
             /// </summary>
        public static class DBS
            {
            //>>>>>load includes, then wireup aliases to assembly
            private static Type type_DBS = ( (Assembly)Includes.VoiceBotSupportClasses.ScriptEngine.LoadInclude(new IntPtr(), "Include_DarkLibs", Includes.VoiceBotSupportClasses.Constants.str_default_references) ).GetTypes().Where(x => x.FullName.Contains("Includes.DBS")).ToArray<Type>()[0];

            //>>>>>appoint delagates (signatures)
            public delegate DataTable QueryDelegate(string str_query, string str_connectionstring);

            //>>>>>staff them
            public static QueryDelegate Query = (QueryDelegate)Delegate.CreateDelegate(typeof(QueryDelegate), ( ( type_DBS.GetMethods().Where(x => x.Name == "Query").ToArray<MethodInfo>() ) )[0]);
            }/*</class::DBS>*/

             //=========================================================================
             //== /Support Classes
             //=========================================================================
        }/*</namespace Includes>*/

         //=============================================================================
         //== /Includes Classes
         //=============================================================================

    #endregion Includes

    //=============================================================================
    }/*</namespace::VoiceBotScriptLevel1Diagnostics>*/