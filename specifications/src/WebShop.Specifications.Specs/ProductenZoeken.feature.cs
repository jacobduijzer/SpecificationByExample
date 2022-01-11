﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WebShop.Specifications.Specs
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ZoekenInDeProductCatalogusFeature : object, Xunit.IClassFixture<ZoekenInDeProductCatalogusFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ProductenZoeken.feature"
#line hidden
        
        public ZoekenInDeProductCatalogusFeature(ZoekenInDeProductCatalogusFeature.FixtureData fixtureData, WebShop_Specifications_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("nl-NL"), "", "Zoeken in de product catalogus", "    Als klant\n    Wil ik de product catalogus kunnen doorzoeken op producten die " +
                    "ik wil kopen\n    Zodat ik kan kijken of het product leverbaar is", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Een boek zoeken in een bepaalde categorie")]
        [Xunit.TraitAttribute("FeatureTitle", "Zoeken in de product catalogus")]
        [Xunit.TraitAttribute("Description", "Een boek zoeken in een bepaalde categorie")]
        public virtual void EenBoekZoekenInEenBepaaldeCategorie()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Een boek zoeken in een bepaalde categorie", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 9
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 10
        testRunner.Given("Simone wil het boek \"Specification By Example\" kopen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeven ");
#line hidden
#line 11
        testRunner.When("Simone zoekt in de categorie \"SoftwareDevelopment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Als ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Titel",
                            "Auteur",
                            "Formaat"});
                table6.AddRow(new string[] {
                            "Specification By Example",
                            "Gojko Adzic",
                            "PDF"});
                table6.AddRow(new string[] {
                            "Specification By Example",
                            "Gojko Adzic",
                            "Hard copy"});
#line 12
        testRunner.Then("krijgt ze de keuze uit de volgende boeken", ((string)(null)), table6, "Dan ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ZoekenInDeProductCatalogusFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ZoekenInDeProductCatalogusFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
