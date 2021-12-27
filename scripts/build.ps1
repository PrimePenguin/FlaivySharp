dotnet restore;
dotnet build -c Release;
dotnet pack --no-build -c Release FlaivySharp/FlaivySharp.csproj;

$nupkg = (Get-ChildItem FlaivySharp/bin/Release/*.nupkg)[0];

# Push the nuget package to AppVeyor's artifact list.
Push-AppveyorArtifact $nupkg.FullName -FileName $nupkg.Name -DeploymentName "FlaivySharp.nupkg"