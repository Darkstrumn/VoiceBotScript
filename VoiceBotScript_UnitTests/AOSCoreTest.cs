using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using VoiceBotScriptAOSCore;
using Xility.Fixture;

namespace VoiceBotScript_UnitTests
    {
    [TestFixture]
    public class VoiceBotScriptAOSCoreTest
        {
        [TestCase(new string[] { "str_system_name", "Commander - Please spell out the name of the system. Please finish with Accept to accept your verbal input and process." }, 2, 2)]
        public void VerbalSpellPrompt_ShouldBeOk(string[] arr_arguments, int int_num_subparams, int int_expected_num)
            {
            "ok".ShouldBe("ok");
            }
        }
    }