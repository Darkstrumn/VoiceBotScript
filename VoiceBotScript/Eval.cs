using System;
using System.Collections.Generic;
using System.Data; //<<--in references
using System.Data.OleDb; //<<--System.Data.DataSetExtensions.dll is needed
using System.Linq;
using System.Threading.Tasks;
//-------------------------
//using System; //<<--in code
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Diagnostics;
using System.Text; //<<--mscorlib.dll needed
using Microsoft.CSharp; //<<--in system.dll
//-------------------------
using System.Drawing; //<<--in references
using System.Management; //<<--in references
using System.Speech.Synthesis;
using System.Web; //<<--in references
using System.Windows; //<<--in references
using System.Xml; //<<--in references
//=============================================================================
namespace VoiceBotScriptEval
    {
    class Program
        {
        public static void Eval(string[] args)
            {
            VoiceBotScript.Run(new IntPtr());
            }//</Eval(string[] args)>
        }/*</class::Program>*/
//*****************************************************************************
/// <summary>
/// OSCore script for VoiceBot
/// </summary>
//using System;
//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Data; //<<--in references
//using System.Drawing;
//using System.Data.OleDb; //<<--System.Data.DataSetExtensions.dll is needed
//using System.Diagnostics;
//using System.Reflection;
//using System.Text; //<<--mscorlib.dll needed
//using Microsoft.CSharp; //<<--in system.dll
//=============================================================================
#region main
//=============================================================================
//==main
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::000000.00
/// Function: 
/// <summary>
//=============================================================================
public static class VoiceBotScript
    {
    private const string _script_name = "MyScript";
    private enum enum_response { ok, fail };
    //>>>>>this array will store our random response sets (2 typically , successful\\ok messages and failure\\not-ok messages)
    private static string[,] _arr_str_responses = new string[,]
                    {
                    {/*comply verbiage*/

                    "Sir!"
                    ,"Acknowledged."
                    }
                    ,{/*unale to comply verbiage*/

                    "Commander, that course of action is currently inhibited."
                    ,"Unable to comply."
                    }
                    };
    //---------------------------------------------------------------------------
    public static void Run(IntPtr windowHandle)
        {
	BFS.Speech.TextToSpeech("Starting Test.");
	string str_code = @"
using System;
using System.Drawing;
using System.Speech.Recognition;//<<-- needs: C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll
using System.Speech.Synthesis;

public class VoiceBotScript
    {
    //-----------------------------------------
    public VoiceBotScript()
        {;}//</VoiceBotScript()>
    //-----------------------------------------
	public void Run(IntPtr windowHandle)
	    {
	    //BFS.Speech.TextToSpeech(""Hello world!"");
		string str_confirmation = Speech.SpeechRecogizer(""Commander, please confirm you wish to jettison all cargo."");
		BFS.Speech.TextToSpeech(""I heard. "" + str_confirmation);
	    }//</Run(IntPtr windowHandle)>
    //-----------------------------------------
    }/*</class::VoiceBotScript>*/
    //=============================================================================
    public static class Speech
        {
        //---------------------------------------------------------------------
        public static string SpeechRecogizer(string str_voice_prompt)
            {
            string str_return = """";
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            BFS.Speech.TextToSpeech(str_voice_prompt);
            //
            try
                {
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                str_return = result.Text;
                //<diagnostics>BFS.Speech.TextToSpeech(result.Text);
                }
            catch (InvalidOperationException exception)
                {
                BFS.Speech.TextToSpeech(String.Format(""Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}."", exception.Source, exception.Message));
                }
            finally
                {
                recognizer.UnloadAllGrammars();
                }//</try>
            return (str_return);
            }//</SpeachRecogizer()>
        }/*</class::Speech>*/
    //=============================================================================
";
	FxLib.Eval(windowHandle, str_code,"System.Data.dll | System.dll | System.Drawing.dll | System.Management.dll | System.Web.dll | System.Windows.Forms.dll | System.Xml.dll | mscorlib.dll | C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.0\\Profile\\Client\\System.Speech.dll");
	//IPC.Eval(windowHandle, str_code,"mscorlib.dll");
	BFS.Speech.TextToSpeech("End of line.");
        //
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
#region FxLib
//=============================================================================
//==IPC Function Library
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::160105.21
/// Function: define library functions - The Toolbox
/// </summary>
public static class FxLib
    {
    //---------------------------------------------------------------------------
    public static Args loadArgs(string str_macro_name)
        {
        var args_return = new Args();
        string str_key;
        string str_value;
        try {
            //args_return.argv. = BFS.ScriptSettings.ReadValue(str_macro_name).Split('|'); 
            foreach ( string element in BFS.ScriptSettings.ReadValue(str_macro_name).Split('|') )
                {
                str_key = element.Split(',')[0];
                str_value = ( element.Split(',').Length > 1 ? element.Replace(str_key + ",","") : element );
                args_return.argv.Add(args_return.argc, new Arg() { key = str_key, value = str_value });
                } 
            } catch(Exception Error) {Debug.Write("!!!LoadArgs\\\\Error::" + Error.Message); }//<<--default if not defined
        return ( args_return );
        }/*</LoadArgs(string str_macro_name)>*/
            //---------------------------------------------------------------------------
            /// <summary>
            /// basic serialization: the developer is responsible for documenting the parameter list as this
            /// supports position based args, not exactly name based, but can be expanded to easily.
            /// example:
            /// IPC.SaveArgs("MyScript",("hello|world").Split('|')); //<<--will save the 2 element array ["hello","world"]
            /// as a serialized string "hello|world" in the registry for later extraction by the intended macro.
            /// </summary>
    public static void saveArgs(string str_macro_name, string[] arr_content)
        {
        string str_content = "";//<<--default to deleting variable value
                                //
        if ( arr_content != null )//>>>>>serialize
            {
            foreach ( string str_item in arr_content )
                {
                str_content += ( str_content.Length > 0 ? "|" : "" ) + str_item;
                }//</foreach (string str_item in arr_content)>
            }
        else { str_content = "NULL"; }//<<--do nothing
                                        //</>
        BFS.ScriptSettings.WriteValue(str_macro_name, str_content);
        }/*</SaveArgs(string str_macro_name,string[] arr_content)>*/
    //-------------------------------------------------------------------------
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
    //>>>>>handle references, autoload all assemblies used by host, then any specific assemblies supplied
    /* var assemblies = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .Where(a => !a.IsDynamic)
                        .Select(a => a.Location);   

    cp_compiler_params.ReferencedAssemblies.AddRange(assemblies.ToArray());*/
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
        object obj_library_code_instance = assembly_library_code.CreateInstance("ScriptCore.VoiceBotScript");
        //
        Type type_instance_type = obj_library_code_instance.GetType();
        var method_info = type_instance_type.GetMethod("Run");
        object[] obj_parameters_array = new object[] { windowHandle };
        //
        obj_return = method_info.Invoke(obj_library_code_instance, obj_parameters_array);    
        }
    //</if(cr_result.Errors.Count > 0)>
    return(obj_return);
    }/*</Eval( IntPtr windowHandle, string str_source_cs, string str_references = "")>*/
    //-------------------------------------------------------------------------
    }/*</class::IPC>*/
        //=============================================================================
        //==/IPC Function Library
        //=============================================================================
#endregion
#region Support Classes
//=============================================================================
//==Support Classes
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::160105.21
/// Function: define helper datatype class::Args, for IPC agument\\data passing\\storage
/// </summary>
public class Arg
    {
    public string key { get; set; }//</arg>
    public string value { get; set; }//</value>
    }/*</class::Arg>*/
//=============================================================================
public class Args
    {
    //-------------------------------------------------------------------------
    public Args()
        {
        argv = new Dictionary<int, Arg>();//<<--init dictionary
        }//</Args()>
    //-------------------------------------------------------------------------
    public Dictionary<int,Arg> argv { get; set; }//</arg>
    //-------------------------------------------------------------------------
    public int argc
        {
        get
            {
            int int_size = 0;
            //
            if ( argv != null )
                {
                //
                if ( ( argv.Count == 1 ) && ( argv[0].key == "NULL" ) )
                    {
                    int_size = 0;
                    }
                else
                    {
                    int_size = ( argv.Count == 1 ? ( argv[0].key.Length > 0 ? argv.Count : 0 ) : argv.Count );
                    }
                //</if ( ( argv.Length == 1 ) && ( argv[0] == "NULL" ) )>
                }
            else {; }
            //</if (argv != null)>
            return ( int_size );
            }//</get>
        }//</argc>
    //-------------------------------------------------------------------------
    }/*</class::Args>*/
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::160112.12
/// Function: model ship system state. voicebot stores vars in registry as a
/// string, so we will use one string to store the state of the ship, vs. multiple
/// </summary>
public static class Ship
    {
    //-------------------------------------------------------------------------
    public static void resetShipState()
        {
        Args args_ship_state = FxLib.IPC.LoadArgs("ship_state");
        string[,] arr_ship_state = new string[,] {
{ "shipName", "DIN Ka'pla" } //<<--name
,{"cargoScoop","0" } //<<--cargo scoop deployed
,{"landingGear","0" } //<<--landing gear deployed
,{"externalLights","0" } //<<--ship lights deployed
,{"flightAssist","1" } //<<--flight assist
,{"hardpoints","0" } //<<--hardpoints deployed
,{"silentRunning","0" } //<<--silent running
,{"activeFiregroup","0" } //<<--active fire group
,{"shipType","8" } //<<--ship type id (used to set properties such as number of slots for Modules and such
,{"modules","20" } //<<--modules (number of module slots)
,{"firegoups","5" } //<<--fire groups (number of fire groups, default 5)
,{"refineryBins","5" } //<<--refinary present (value is number of hopper bins avilable)
,{"systemsPower","2" } //<<--systems (power distribution state)
,{"enginesPower","2" } //<<--engines (power distribution state)
,{"weaponsPower","2" } //<<--weapons (power distribution state)
,{"turretMode","2" } //<<--turret weapons mode (1=fixed, 2=target only, 3=fire at will (default 2))
,{"beacon","0" } //<<--beacon (0=off, 1=wing (defult 0))
,{"confirmation","0" } //<<--expecting confirmation (0=no, 1=yes) used to ignore confirmation response triggers if unexpected
,{"jettison","0" } //<<--jettison all cargo (0=no, 1=confirming, 2= commit)
};
        string[,] arr_ship_screens_state = new string[,] {
{ "1", "0"} //<<--screen1-target tab(leftRight) index
,{ "1.1.y", "2"} //<<--subscreen 1 tab 1\\Navigation upDown selection index (reservered for future use)
,{ "1.1.x", "0"} //<<--subscreen 1 tab 1\\Navigation leftRight selection index (reservered for future use)
,{ "1.2.y", "0"} //<<--subscreen 1 tab 2\\Transactions upDown selection index (reservered for future use
,{ "1.2.x", "0"} //<<--subscreen 1 tab 2\\Transactions leftRight selection index (reservered for future use)
,{ "1.3.y", "0"} //<<--subscreen 1 tab 3\\Contacts upDown selection index (reservered for future use
,{ "1.3.x", "0"} //<<--subscreen 1 tab 3\\Contacts leftRight selection index (reservered for future use)
,{ "1.4.y", "0"} //<<--subscreen 1 tab 4\\Inventory upDown selection index (reservered for future use
,{ "1.4.x", "0"} //<<--subscreen 1 tab 4\\Inventory leftRight selection index (reservered for future use)
,{ "2", "0"} //<<--screen2-comms tab(leftRight) index
,{ "2.1.y", "0"} //<<--subscreen 2 tab 1\\Local upDown selection index (reservered for future use)
,{ "2.1.x", "0"} //<<--subscreen 2 tab 1\\Local leftRight selection index (reservered for future use)
,{ "2.2.y", "0"} //<<--subscreen 2 tab 2\\Voice upDown selection index (reservered for future use)
,{ "2.2.x", "0"} //<<--subscreen 2 tab 2\\Voice leftRight selection index (reservered for future use)
,{ "2.3.y", "0"} //<<--subscreen 2 tab 3\\Email upDown selection index (reservered for future use)
,{ "2.3.x", "0"} //<<--subscreen 2 tab 3\\Email leftRight selection index (reservered for future use)
,{ "2.4.y", "0"} //<<--subscreen 2 tab 4\\Wing upDown selection index (reservered for future use)
,{ "2.4.x", "0"} //<<--subscreen 2 tab 4\\Wing leftRight selection index (reservered for future use)
,{ "2.5.y", "0"} //<<--subscreen 2 tab 5\\Prefs upDown selection index (reservered for future use)
,{ "2.5.x", "0"} //<<--subscreen 2 tab 5\\Prefs leftRight selection index (reservered for future use)
,{ "3", "0"} //<<--screen3-role tab(leftRight) index
,{ "3.1.y", "0"} //<<--subscreen 3 tab 1\\Ship upDown selection index (reservered for future use)
,{ "3.1.x", "0"} //<<--subscreen 3 tab 1\\Ship leftRight selection index (reservered for future use)
,{ "3.2.y", "0"} //<<--subscreen 3 tab 2\\SRV upDown selection index (reservered for future use)
,{ "3.2.x", "0"} //<<--subscreen 3 tab 2\\SRV leftRight selection index (reservered for future use)
,{ "4", "0"} //<<--screen4-systems tab(leftRight) index
,{ "4.1.y", "0"} //<<--subscreen 4 tab 1\\Status upDown selection index (reservered for future use)
,{ "4.1.x", "0"} //<<--subscreen 4 tab 1\\Status leftRight selection index (reservered for future use)
,{ "4.2.y", "0"} //<<--subscreen 4 tab 2\\Modules upDown selection index (reservered for future use)
,{ "4.2.x", "0"} //<<--subscreen 4 tab 2\\Modules leftRight selection index (reservered for future use)
,{ "4.3.y", "0"} //<<--subscreen 4 tab 3\\Inventory upDown selection index (reservered for future use)
,{ "4.3.x", "0"} //<<--subscreen 4 tab 3\\Inventory leftRight selection index (reservered for future use)
,{ "4.4.y", "0"} //<<--subscreen 4 tab 4\\FireGroups upDown selection index (reservered for future use)
,{ "4.4.x", "0"} //<<--subscreen 4 tab 4\\FireGroups leftRight selection index (reservered for future use)
,{ "4.5.y", "0"} //<<--subscreen 4 tab 5\\Functions upDown selection index (reservered for future use)
,{ "4.5.x", "0"} //<<--subscreen 4 tab 5\\Functions leftRight selection index (reservered for future use)
};

        int int_loop = 0;
        int int_loop_size = arr_ship_state.GetLength(0);
        string str_ship_state = "";
        for ( int_loop = 0; int_loop < int_loop_size; int_loop++ )
            {
            str_ship_state += ( str_ship_state.Length > 0 ? "|" : "" ) + arr_ship_state[int_loop, 0] + "," + arr_ship_state[int_loop, 1];//<<--simple-serialization
            }//</for ( int_loop = 0; int_loop < int_loop_size; int_loop++ )>
        FxLib.IPC.SaveArgs("ship_state", str_ship_state.Split('|'));
        }//</_resetShipState()>
    //-------------------------------------------------------------------------
    public static string getState(string str_property)
        {
        string str_return = "";
        string str_key = "";
        bool bln_found = false;
        Args args_ship_state = FxLib.IPC.LoadArgs("ship_state");
        //<diagnostics>BFS.Speech.TextToSpeech("getState::Number of data elements to scan is {NUM}.".Replace("{NUM}", args_ship_state.argc.ToString()));
        foreach (KeyValuePair<int, Arg> row in args_ship_state.argv)
            {
            str_key = row.Value.key;
            if ( str_key == str_property )
                {
                bln_found = true;
                str_return = row.Value.value;
                break;//<<--breach the loop
                }
            else {; }
            //</if (str_key == str_property )>
            }//</foreach ( string row in args_ship_state.argv )>
        //
        if ( bln_found )
            { BFS.Speech.TextToSpeech("getState::state property '{PROPERTY}' found:{VALUE}. ".Replace("{PROPERTY}", str_property).Replace("{VALUE}", str_return)); }
        else
            { BFS.Speech.TextToSpeech("getState::state property '{PROPERTY}' not found! ".Replace("{PROPERTY}", str_property)); }
        //</if ( !bln_found )>
        return ( str_return );
        }//</getState(string str_property)>
	//-------------------------------------------------------------------------
	public static void setState(string str_property, string str_value)
		{
		string str_key = "";
		int int_index = -1;
		bool bln_found = false;
		string str_ship_state = "";
		string str_old_state = "";
		string str_new_state = "";
		Args args_ship_state = FxLib.IPC.LoadArgs("ship_state");
		//>>>>>ensure we have data, else initialize
		if(args_ship_state.argc == 0)
			{
			Ship.resetShipState();//<<--init
			args_ship_state = FxLib.IPC.LoadArgs("ship_state");//<<--reload
			}
		else {; }//>>>>>do nothing
		//</if(if(args_ship_state.argc == 0))>
		Args args_new_ship_state = FxLib.IPC.LoadArgs("ship_state");
		//<diagnostics>BFS.Speech.TextToSpeech("getState::Number of data elements to scan is {NUM}.".Replace("{NUM}", args_ship_state.argc.ToString()));
		foreach (KeyValuePair<int, Arg> row in args_ship_state.argv)
			{
			int_index++;
			str_key = row.Value.key;
			str_old_state = args_ship_state.argv[int_index].value;
			//
			if ( str_key == str_property )
				{
				bln_found = true;
				str_new_state = str_value;
				}
			else
				{
				str_new_state = str_old_state;
			    }
			//</if (str_key == str_property )>
			str_ship_state += ( str_ship_state.Length > 0 ? "|" : "" ) + str_key + "," + str_new_state;
			}//</foreach ( string row in args_ship_state.argv )>
		//
		if ( !bln_found )//>>>>>create
			{
			args_ship_state.argv.Add(args_ship_state.argc,new Arg() { key = str_key, value = str_value });
			}
		else//>>>>>continue to save
			{; }
		//</if ( bln_found )>
		BFS.ScriptSettings.WriteValue("ship_state", str_ship_state);
		}//</setState(string str_property,string str_value)>
	//-------------------------------------------------------------------------
    }/*</class::ship>*/
//=============================================================================
/// <summary>
/// Author: Darkstrumn:\created::160112.12
/// Function: provides DB functionality for use with macro scripts, improved IPC finctionality over the use of the registry for complexe macro logic
/// >>>>>if voicebot complains that the provider is not register on the local machine, then instll the access engine for your system [32|64]bit:: https://www.microsoft.com/en-us/download/details.aspx?id=13255
/// </summary>
public static class dbs
    {
    public static DataTable getData(string str_query = "SELECT * FROM `Salvage`;")
        {
        string str_path = BFS.General.GetAppInstallPath();
        str_path += "\\ScriptExtension\\";//<<--this must be created in voicebot install folder and the .mdb files should be stored in here so the macroscripts have access to a standard location.
                                            //
                                            //<diagnositcs>BFS.Speech.TextToSpeech("Application Path determined to be " + str_path);
        DataTable dt_result = new DataTable();
        //string str_connectionstring = "Provider='Microsoft.ACE.OLEDB.12.0'; Data Source='R:\\Downloads\\LogBook.mdb'; Persist Security Info=False";
        string str_connectionstring = "Provider='Microsoft.ACE.OLEDB.12.0'; Data Source='{PATH}LogBook.mdb'; Persist Security Info=False".Replace("{PATH}", str_path);
        try
            {
            //>>>>>Open OleDb Connection using MSAccess type localdb file
            OleDbConnection db_connection = new OleDbConnection();
            db_connection.ConnectionString = str_connectionstring;
            db_connection.Open();
            //>>>>>Execute Queries
            OleDbCommand db_context = db_connection.CreateCommand();
            db_context.CommandText = str_query;
            OleDbDataReader db_reader = db_context.ExecuteReader(CommandBehavior.CloseConnection); //>>>>>close connection after complete
                                                                                                    //>>>>>Load the result into a DataTable
            dt_result.Load(db_reader);
            }
        catch ( Exception error )
            {
            String str_error_message = "getData::Commander, OLEDB Connection FAILED: {ERRORMSG}".Replace("{ERRORMSG}", error.Message);
            str_error_message += "getData::The derived path information was {PATH}".Replace("{PATH}", str_path);
            //<replaced>BFS.Speech.TextToSpeech(str_error_message);
            BFS.Dialog.ShowMessageError(str_error_message);
            }//</try>
        return ( dt_result );
        }
    }/*</class::dbs>*/
//=============================================================================
//==/Support Classes
//=============================================================================
#endregion
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
}/*</namespace::VoiceBotScriptTemplate>*/
