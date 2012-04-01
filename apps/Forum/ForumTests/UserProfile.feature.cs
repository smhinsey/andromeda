﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.239
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ForumTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("User Profiles")]
    [NUnit.Framework.CategoryAttribute("ForumAgentSpecs")]
    public partial class UserProfilesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UserProfile.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "User Profiles", "In order to interact with a Forum\r\nAs a Forum User\r\nI want to create and maintain" +
                    " a Profile", ProgrammingLanguage.CSharp, new string[] {
                        "ForumAgentSpecs"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register a Profile")]
        public virtual void RegisterAProfile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register a Profile", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("the agent ForumAgent");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "PasswordHash",
                        "PasswordSalt",
                        "ForumIdentifier"});
            table1.AddRow(new string[] {
                        "johndoe",
                        "hash",
                        "salt",
                        "22222222-2222-2222-2222-222222222222"});
#line 10
 testRunner.When("I publish the command RegisterUser:", ((string)(null)), table1);
#line 13
 testRunner.And("the command is complete");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username"});
            table2.AddRow(new string[] {
                        "johndoe"});
#line 15
 testRunner.Then("run FindByUsername on UserQueries with:", ((string)(null)), table2);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "PasswordHash",
                        "PasswordSalt",
                        "ForumIdentifier"});
            table3.AddRow(new string[] {
                        "johndoe",
                        "hash",
                        "salt",
                        "22222222-2222-2222-2222-222222222222"});
#line 19
 testRunner.Then("the User has values:", ((string)(null)), table3);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a Profile")]
        public virtual void UpdateAProfile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a Profile", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("the agent ForumAgent");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "PasswordHash",
                        "PasswordSalt",
                        "ForumIdentifier"});
            table4.AddRow(new string[] {
                        "johndoe",
                        "hash",
                        "salt",
                        "22222222-2222-2222-2222-222222222222"});
#line 27
 testRunner.When("I publish the command RegisterUser:", ((string)(null)), table4);
#line 30
 testRunner.And("the command is complete");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "AvatarUrl"});
            table5.AddRow(new string[] {
                        "johndoe@doejohn.com",
                        "http://avatar/johndoe"});
#line 32
 testRunner.When("I publish the command UpdateUserProfile:", ((string)(null)), table5);
#line 35
 testRunner.And("the command is complete");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username"});
            table6.AddRow(new string[] {
                        "johndoe"});
#line 37
 testRunner.Then("run UserProfileByUsername on UserQueries with:", ((string)(null)), table6);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "AvatarUrl"});
            table7.AddRow(new string[] {
                        "johndoe@doejohn.com",
                        "http://avatar/johndoe"});
#line 41
 testRunner.And("the UserProfile has values:", ((string)(null)), table7);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Authenticate as User")]
        public virtual void AuthenticateAsUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Authenticate as User", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
 testRunner.Given("the agent ForumAgent");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "PasswordHash",
                        "PasswordSalt",
                        "ForumIdentifier"});
            table8.AddRow(new string[] {
                        "johndoe",
                        "hash",
                        "hash",
                        "22222222-2222-2222-2222-222222222222"});
#line 48
 testRunner.When("I publish the command RegisterUser:", ((string)(null)), table8);
#line 51
 testRunner.And("the command is complete");
#line 53
 testRunner.Then("running Authenticate on  UserQueries will return true");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
