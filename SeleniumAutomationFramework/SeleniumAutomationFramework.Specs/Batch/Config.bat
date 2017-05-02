@echo off

COLOR 0a

:: PROJECT FILES
SET ProjectHome=C:\Users\TechTeam\Source\Repos\SeleniumAutomationFramework\SeleniumAutomationFramework
SET LivingDocFolder=%ProjectHome%\SeleniumAutomationFramework.Specs\bin\LivingDoc
SET FeatureFolder=%ProjectHome%\SeleniumAutomationFramework.Specs\Features
SET SpecsDLL=\SeleniumAutomationFramework.Specs\bin\Debug\SeleniumAutomationFramework.Specs.dll
SET BDDTestProject="%ProjectHome%\SeleniumAutomationFramework.Specs\SeleniumAutomationFramework.Specs.csproj"

:: UTILITIES
SET PicklesExe=%ProjectHome%\packages\Pickles.CommandLine.2.2.0\tools\pickles.exe
SET MSTestExe="%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\Common7\IDE\MSTest.exe"
SET SpecflowExecutable=%ProjectHome%\packages\SpecFlow.2.1.0\tools\specflow.exe

:: FILE NAMES
SET StepDefHTMLOutput=StepDefinitionReport.html
SET MsTestResultFile="TestResults.trx"
SET HTMLTestOutput="TestResults.html"

