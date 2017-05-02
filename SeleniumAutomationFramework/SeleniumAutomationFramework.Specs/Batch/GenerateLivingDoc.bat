@echo off

call Config.bat

echo ::: Generating Pickles Report
%PicklesExe% --feature-directory=%FeatureFolder% --output-directory=%LivingDocFolder% --documentation-format=Dhtml

echo ::: Opening Pickles Report
%LivingDocFolder%\Index.html
