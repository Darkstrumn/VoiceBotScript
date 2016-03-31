using System;
using System.Collections.Generic;//<<--needed for Dictionary
using System.Data; //<<--in references
using System.Data.OleDb; //<<--provided by System.Data.DataSetExtensions.dll
using System.Diagnostics;//<<--needed for debug (visual studio IDE only)
using System.Linq;//<<--provided by C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Data.Linq.dll
using System.Threading;
using System.Threading.Tasks;
using System.Drawing; //<<--in references
using System.Management; //<<--in references
using System.Speech.Recognition;//<<-- provided by C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll
using System.Speech.Synthesis;
using System.Web; //<<--in references
using System.Windows; //<<--in references
using System.Xml; //<<--in references
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text; //<<--provided by mscorlib.dll
using Microsoft.CSharp; //<<--in system.dll
//=============================================================================
namespace VoiceBotScriptAOSCore
    {
    //=========================================================================
    class Program
        {
        //---------------------------------------------------------------------
        static void AOSCore(string[] args)
            {
            VoiceBotScript.Run(new IntPtr());
            }//</AOSCore(string[] args)>
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
                {;}//</RegistryEntry()>
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
                //>>>>>diagnostic output
                //str_return = "deployCargoScoop|3|SetShipState,cargoScoop,1|SendKeys,{HOME}|TTS,Acknowledged. cargo scoop active.";
                //str_return = "shipName,DIN Ka'pla|cargoScoop,0|landingGear,0|externalLights,0|flightAssist,1|hardpoints,0|silentRunning,0|activeFiregroup,0|shipType,8|modules,20|firegoups,5|refineryBins,5|systemsPower,2|enginesPower,2|weaponsPower,2|turretMode,2|beacon,0|confirmation,0|jettison,0";
                //str_return = "deployCargoScoop|2|Set,CargoScoop,1|SendKeys,{HOME}";
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
    #endregion
//*****************************************************************************
/// <summary>
/// OSCore script for VoiceBot
/// </summary>
//using System;
//using System.Collections.Generic;
//using System.Data; //<<--in references
//using System.Data.OleDb; //<<--System.Data.DataSetExtensions.dll is needed
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Drawing; //<<--in references
//using System.Management; //<<--in references
//using System.Speech.Recognition; //<<--needs C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll
//using System.Speech.Synthesis;
//using System.Web; //<<--in references
//using System.Windows; //<<--in references
//using System.Xml; //<<--in references
//using System.CodeDom.Compiler;
//using System.Reflection;
//using System.Text; //<<--mscorlib.dll needed
//=============================================================================
#region main
//=============================================================================
//==main
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::160116.00
/// Function: testing includes for Speech Prompting
/// <summary>
//=============================================================================
public static class VoiceBotScript
  {
  private const string _script_name = "LoadTestSpeechIncludes";
  private enum enum_response { ok, fail };
  //>>>>>this array will store our random response sets (2 typically , successful\\ok messages and failure\\not-ok messages)
  private static string[,] _arr_str_responses = new string[,]
    {
      {/* comply verbiage */
  
      "Sir, Confirmed."
      ,"Confirmation acknowledged."
      }/* /comply verbiage */
      ,{/*unable to comply verbiage */
  
      "Commander, failure to load accepted."
      ,"Fail achknowledged."
      }/* /unable to comply verbiage */
    };
    //---------------------------------------------------------------------------
  public static void Run(IntPtr windowHandle)
    {
    string ipc_var_name = _script_name + "_ipc";
    //>>>>>includes
    object obj_fx_lib = ScriptEngine.GetInclude(windowHandle, "IncludeFxLib","");//<<--include speech prompting
    object obj_ship_model = ScriptEngine.GetInclude(windowHandle, "IncludeShipModel","");//<<--include speech prompting
    object obj_database = ScriptEngine.GetInclude(windowHandle, "IncludeDatabase","");//<<--include speech prompting
    object obj_speech = ScriptEngine.GetInclude(windowHandle, "IncludeSpeech","");//<<--include speech prompting
    //
    string str_confirmation = (String)ScriptEngine.CallFunction(obj_speech, "SpeechRecogizer", new object[]{"Commander, please confirm the Speech includes have loaded and work"});//<<--function of the include
    SupportClasses.Args args = new SupportClasses.Args(); if ( FxLib.LoadArgs(ipc_var_name).argc > 0 ) { args = FxLib.LoadArgs(ipc_var_name); } else {; }//<<--key for ipc data, defaults to empty set if no args defined
    string str_caller = ( args.argc > 2 ? args.argv[0].value : "" ); //<<--if called using IPC, this will be the calling module
    int int_numParams = ( str_caller.Length > 0 ? (args.argv.Count - 1) : 0 ); //<<--used for IPC argument handling
    int int_num_subparams;
    int int_expected_num;
    string str_method;
    string ship_state;
    string[] arr_arguments;
    obj_fx_libLoadArgs();
            //
            if ( args.argc > 0 )//>>>>>we have args, parse and store
                {
                //>>>>>process based on IPC data
                for ( var intLoop = 2; intLoop < ( 2 + int_numParams ); intLoop++ )
                    {
                    str_arguments = args.argv[intLoop].value;
                    arr_arguments = str_arguments.Split(',');
                    str_method = args.argv[intLoop].key;//<<--alias
                    int_num_subparams = (arr_arguments.Length);
                    //>>>>>handle requested methods
                    switch ( str_method.ToLower() )
                        {
                        case "tts":
                            int_expected_num = 1;
                            //>>>>>arr_arguments[0]; //<<--message to speak
                            if ( int_num_subparams == int_expected_num )//>>>>>execute
                                {
                                BFS.Speech.TextToSpeech(arr_arguments[0]);
                                }
                            else //>>>>>warn
                                {
                                VoiceArgcError(str_method.ToUpper(), int_num_subparams, int_expected_num);
                                }//</if ( (arr_arguments.Length - 1) == 2)>
                            break;
                        case "initshipstate":
                            Ship.resetShipState();
                            break;
                        case "getshipstate":
                            int_expected_num = 1;
                            //>>>>>arr_arguments[0]; //<<--var to get
                            if ( int_num_subparams == int_expected_num )//>>>>>execute
                                {
                                ship_state = Ship.getState(arr_arguments[0]);
                                }
                            else //>>>>>warn
                                {
                                VoiceArgcError(str_method.ToUpper(), int_num_subparams, int_expected_num);
                                }//</if ( (arr_arguments.Length - 1) == 2)>
                            break;
                        case "setshipstate":
                            int_expected_num = 2;
                            //>>>>>arr_arguments[0]; //<<--var to set
                            //>>>>>arr_arguments[1]; //<<--value to set var to
                            if ( int_num_subparams == int_expected_num )//>>>>>execute
                                {
                                Ship.setState(arr_arguments[0], arr_arguments[1]);
                                }
                            else //>>>>>warn
                                {
                                VoiceArgcError(str_method.ToUpper(), int_num_subparams, int_expected_num);
                                }//</if ( (arr_arguments.Length - 1) == 2)>
                            break;
                        case "set":
                            int_expected_num = 2;
                            //>>>>>arr_arguments[0]; //<<--var to set
                            //>>>>>arr_arguments[1]; //<<--value to set var to
                            if ( int_num_subparams == int_expected_num )//>>>>>execute
                                {
                                FxLib.SaveArgs(arr_arguments[0], arr_arguments[1].Split('|'));
                                }
                            else //>>>>>warn
                                {
                                VoiceArgcError(str_method.ToUpper(), int_num_subparams, int_expected_num);
                                }//</if ( (arr_arguments.Length - 1) == 2)>
                            break;
                        case "sendkeys":
                            int_expected_num = 1;
                            //>>>>>arr_arguments[0]; //<<--key-sequence to send
                            if ( int_num_subparams == int_expected_num )//>>>>>execute
                                {
                                BFS.Input.SendKeys(arr_arguments[0]);
                                }
                            else //>>>>>warn
                                {
                                VoiceArgcError(str_method.ToUpper(), int_num_subparams, int_expected_num);
                                }//</if ( (arr_arguments.Length - 1) == 2)>
                            break;
                        default:
                            break;
                        }//</switch>
                    }//</for(var intLoop = 0; intLoop < args.argc; intLoop++)>
                }
            else
                { /*BFS.Speech.TextToSpeech("No IPC data found.")*/; }
            //</if(int_argc > 0)>
            //
            if ( args.argc != 0 )
                { FxLib.SaveArgs(ipc_var_name, null); }//<<--"delete" the value (I think the registry key remains...)
            else
                {; }
            //</if ( args.argc != 0 )>
    }/*</Run(IntPtr windowHandle)>*/
    //------------------------------------------------------------------------------
    public static void VoiceArgcError(string str_method, int int_num_args, int int_expected_num)
      {
      /*Customize audio error as desired*/
      BFS.Speech.TextToSpeech(_script_name + " Error detected in {METHOD}" + str_method + " parameters, number of arguments provided was {NUM}".Replace("{METHOD", str_method).Replace("NUM}", int_num_args.ToString()));
      BFS.Speech.TextToSpeech("Number of arguments expected is {NUM}".Replace("NUM}", int_expected_num.ToString()));
      }/*</VoiceArgcError(string str_method, int int_num_args, int int_expected_num)>*/
    //------------------------------------------------------------------------------
		 }/*</class::VoiceBotScript>*/
//=============================================================================
//==/main
//=============================================================================
#endregion
//=============================================================================
#region ScriptEngine
//=============================================================================
//== ScriptEngine Function Library
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::160115.03
/// Function: define standard library functions - The Toolbox - 
/// with the GetInclude functionality, additional functions can be stored as variables,
/// and loaded dynamically for common library functionaity
/// </summary>
public static class ScriptEngine
  {
  //-------------------------------------------------------------------------
  /// <summary>
  /// Eval takes provided CS source and attempts to compile code, then returns an instance object of the assembly
  /// viable for loading aux scripts to form includes or dynamic code loading
  /// </summary>
  /// <param name="windowHandle"></param>
  /// <param name="str_source_cs"></param>
  /// <param name="str_references"></param>
  /// <returns></returns>
  public static object Eval( IntPtr windowHandle, string str_source_cs, string str_references = "")
    {  
    object obj_return = null;
    str_references = (str_references.Length != 0 ? str_references : "System.Data.dll|System.Data.DataSetExtensions.dll|System.dll|System.Drawing.dll|System.Management.dll|System.Web.dll|System.Windows.Forms.dll|System.Xml.dll");
    //
    //CodeDomProvider provider = new CSharpCodeProvider(new Dictionary<String, String>{{ "CompilerVersion","v3.5" }});
    CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
    //
    CompilerParameters cp_compiler_params = new CompilerParameters();
    //>>>>>compileing options to build code
    cp_compiler_params.CompilerOptions = "/t:library";//<<--craft as library dll
    cp_compiler_params.GenerateExecutable  = false;//<<--do not craft executable
    cp_compiler_params.GenerateInMemory = true;//<<--output in memmory vs output file
    cp_compiler_params.TreatWarningsAsErrors = false;//<<--warning handling
    str_references += (str_references.Length > 0 ? "|" : "") + "C:\\Program Files (x86)\\VoiceBot\\VoiceBot.exe";
    foreach(string str_reference in str_references.Split('|'))
      {
      cp_compiler_params.ReferencedAssemblies.Add(str_reference.Trim());
      }//</foreach(string str_reference in str_references.Split('|'))>
    //
    StringBuilder sb_script_core = new StringBuilder("");//<<--more flexible than string concatination if we add hardcoded library logic here
    //
    sb_script_core.Append(@"namespace ScriptCore
    {
    " + str_source_cs + @"
    }
    ");//</sb_script_core>
    //-------------------------
    //>>>>>attempt to compile
    CompilerResults cr_result = provider.CompileAssemblyFromSource(cp_compiler_params, sb_script_core.ToString());
    //
    if(cr_result.Errors.Count > 0)//>>>>>report error, and fail
      {
      foreach(CompilerError CompErr in cr_result.Errors)
        {
        BFS.Dialog.ShowMessageError("Eval\\\\ERROR: Line number {LINE}, Error Number: {NUMBER}, '{TEXT}';".Replace("{LINE}",CompErr.Line.ToString()).Replace("{NUMBER}",CompErr.ErrorNumber).Replace("{TEXT}",CompErr.ErrorText) );
        }//</foreach(CompilerError CompErr in cr_result.Errors)>
      }
    else//>>>>>execute code
      {
      System.Reflection.Assembly assembly_library_code = cr_result.CompiledAssembly;
      object obj_library_code_instance = assembly_library_code.CreateInstance("ScriptCore.Includes");
      obj_return = obj_library_code_instance;
      }
    //</if(cr_result.Errors.Count > 0)>
    return(obj_return);
    }/*</Eval( IntPtr windowHandle, string str_source_cs, string str_references = "")>*/
  //-------------------------------------------------------------------------
  /// <summary>
  /// CallFunction call the included functions specified
  /// </summary>
  /// <param name="obj_library_code_instance"></param>
  /// <param name="str_function_name"></param>
  /// <param name="obj_parameters_array"></param>
  /// <returns></returns>
  public static object CallFunction(Object obj_library_code_instance, string str_function_name, object[] obj_parameters_array)
  	{
    //
    Type type_instance_type = obj_library_code_instance.GetType();
    var method_info = type_instance_type.GetMethod(str_function_name);
    //
    object obj_return = method_info.Invoke(obj_library_code_instance, obj_parameters_array);    
  	return(obj_return);
  	}//</CallFunction(Object obj_library_code_instance, str_function_name, object[] obj_parameters_array)>
  //---------------------------------------------------------------------------
  /// <summary>
  /// GetInclude is an alias to the loading of includes. Store unboxed object to instance variable and use it with the CallFunction
  /// function to call the included functions
  /// </summary>
  /// <param name="windowHandle"></param>
  /// <param name="str_include"></param>
  /// <param name="str_references"></param>
  /// <returns></returns>
  public static object GetInclude(IntPtr windowHandle, string str_include,string str_references = "")
    {
    str_references = (str_references.Length != 0 ? str_references : "System.Data.dll | System.dll | System.Drawing.dll | System.Management.dll | System.Web.dll | System.Windows.Forms.dll | System.Xml.dll | mscorlib.dll | C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll");
    string str_code = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(BFS.ScriptSettings.ReadValue(str_include)));
    var obj_include = ScriptEngine.Eval(windowHandle, str_code,str_references);
    return((object)obj_include);
    }//</GetInclude(IntPtr windowHandle, string str_include,string str_references = "")>
  //---------------------------------------------------------------------------
  }/*</class::ScriptEngine>*/
   //=============================================================================
   //== /ScriptEngine Function Library
   //=============================================================================
    #endregion
//=============================================================================
//*****************************************************************************
}/*</namespace::VoiceBotScriptTemplate2>*/

