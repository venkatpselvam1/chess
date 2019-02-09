.\Nuget.exe restore chess.sln
$path = (Get-Item -Path ".\").FullName + "\output"
msbuild chess.sln /p:Configuration=Release /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=$path